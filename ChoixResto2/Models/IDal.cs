using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto2.Models
{
    public interface IDal : IDisposable
    {
        void CreerRestaurant(string nom, string telephone);
        void ModifierRestaurant(int id, string nom, string telephone);
        bool RestaurantExiste(string nom);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idstr);
        List<Resto> ObtientTousLesRestaurants();
        int AjouterUtilisateur(string prenom, string motdepasse);
        Utilisateur Authentifier(string prenom, string motdepasse);
        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUtilisateur);
        bool ADejaVote(int idSondage, string idStr);
    }
}
