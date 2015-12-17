using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoixResto2.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public bool RestaurantExiste(string nom)
        {
            return bdd.Restos.Any(resto => resto.Nom == nom);
        }


        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(user => user.Id == id);
        }

/* En attendant d'implémenter le système d'authentification

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
                return ObtenirUtilisateur(id);
            return null;
        }
*/
        /*En attendant d'implémenter le système d'authentification*/
        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            switch (idStr)
            {
                case "Chrome":
                    return CreeOuRecupere("David", "1234");
                case "IE":
                    return CreeOuRecupere("Evan", "1234");
                case "Firefox":
                    return CreeOuRecupere("Lucas", "1234");
                default:
                    return CreeOuRecupere("Magali", "1234");
            }                       
        }

        /*En attendant d'implémenter le système d'authentification*/
        private Utilisateur CreeOuRecupere(string nom, string motDePasse)
        {
            Utilisateur utilisateur = Authentifier(nom, motDePasse);
            if (utilisateur == null)
            {
                int id = AjouterUtilisateur(nom, motDePasse);
                return ObtenirUtilisateur(id);
            }
            return utilisateur;
        }

        public int AjouterUtilisateur(string prenom, string motdepasse)
        {
            string motDePasseEncode = EncodeMD5(motdepasse);
            Utilisateur utilisateur = new Utilisateur { Prenom = prenom, MotDePasse = motDePasseEncode };
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.Id;
        }

        public Utilisateur Authentifier(string prenom, string motdepasse)
        {
            string motDePasseEncode = EncodeMD5(motdepasse);
            return bdd.Utilisateurs.FirstOrDefault(user => user.Prenom == prenom && user.MotDePasse == motDePasseEncode);
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto2" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

/* En attendant d'implémenter le système d'authentification
        public bool ADejaVote(int idSondage, string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
                if (sondage.Votes == null)
                    return false;

                return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == id);
            }
            return false;
        }
*/

        /*En attendant d'implémenter le système d'authentification*/
        public bool ADejaVote(int idSondage, string idStr)
        {
            Utilisateur utilisateur = ObtenirUtilisateur(idStr);
            if (utilisateur !=null)
            {
                Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
                if (sondage.Votes == null)
                    return false;

                return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == utilisateur.Id);
            }
            return false;
        }

        public int CreerUnSondage()
        {
            Sondage sondage = new Sondage { Date = DateTime.Now };
            bdd.Sondages.Add(sondage);
            bdd.SaveChanges();
            return sondage.Id;
        }


        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = bdd.Restos.First(r => r.Id == idResto),
                Utilisateur = bdd.Utilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            if (sondage.Votes == null)
                sondage.Votes = new List<Vote>();
            sondage.Votes.Add(vote);
            bdd.SaveChanges();
        }

/*        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Resto> restaurants = ObtientTousLesRestaurants();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Resto resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
            }
            return resultats;
        }
 */
    }
}