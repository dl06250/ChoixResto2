using ChoixResto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto2.Tests
{
    public class DalEnDur : IDal
    {
        private List<Resto> listeDesRestaurants;
        private List<Utilisateur> listeDesUtilisateurs;
        private List<Sondage> listeDesSondages;

        public DalEnDur()
        {
            listeDesRestaurants = new List<Resto>
            {
                new Resto {Id=1, Nom="Resto pinambour", Telephone="0102030405"},
                new Resto {Id=2, Nom="Resto pinière", Telephone="0102030405"},
                new Resto {Id=3,Nom="Resto toro", Telephone="0102030405"}
            };
            listeDesUtilisateurs = new List<Utilisateur>();
            listeDesSondages = new List<Sondage>();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            int id = listeDesRestaurants.Count == 0 ? 1 : listeDesRestaurants.Max(r => r.Id) + 1;
            listeDesRestaurants.Add(new Resto { Id = id, Nom = nom, Telephone = telephone });
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto resto = listeDesRestaurants.FirstOrDefault(r => r.Id == id);
            if (resto != null)
            {
                resto.Nom = nom;
                resto.Telephone = telephone;
            }
        }

        public bool RestaurantExiste(string nom)
        {
            return listeDesRestaurants.Any(resto => string.Compare(resto.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string idstr)
        {
            int id;
            if (int.TryParse(idstr, out id))
                return ObtenirUtilisateur(id);
            return null;
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return listeDesRestaurants;
        }

        public int AjouterUtilisateur(string prenom, string motdepasse)
        {
            int id = listeDesUtilisateurs.Count == 0 ? 1 : listeDesUtilisateurs.Max(u => u.Id) + 1;
            listeDesUtilisateurs.Add(new Utilisateur { Id = id, Prenom = prenom, MotDePasse = motdepasse });

            return id;
        }

        public Utilisateur Authentifier(string prenom, string motdepasse)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Prenom == prenom && u.MotDePasse == motdepasse);
        }

        public int CreerUnSondage()
        {
            throw new NotImplementedException();
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            throw new NotImplementedException();
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            throw new NotImplementedException();
        }

        public bool ADejaVote(int idSondage, string idStr)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
