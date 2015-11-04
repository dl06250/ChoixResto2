using ChoixResto2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto2.Controllers
{
    public class AccueilController : Controller
    {
        //
        // GET: /Accueil/

        public ActionResult Index()
        {
            //AccueilViewModel vm = new AccueilViewModel
            //{
            //    Message = "Bonjour depuis le contrôleur",
            //    Date = DateTime.Now,
            //    Resto = new Models.Resto { Nom = "La bonne fourchette", Telephone = "1122334455" },
            //    Login = "David" 
            //};

            //List<Models.Resto> listeDesRestos = new List<Models.Resto>
            //{
            //    new Models.Resto {Id=1,Nom="Resto pinambour", Telephone="1234"},
            //    new Models.Resto {Id=2, Nom="Resto tologie", Telephone="1234"},
            //    new Models.Resto {Id=5, Nom="Resto ride", Telephone="5678"},
            //    new Models.Resto {Id=9, Nom="Resto toro", Telephone="555"}
            //};

            //ViewBag.ListeDesRestos = new SelectList(listeDesRestos, "Id", "Nom");

            //return View(vm);
            return View();
        }

        [ChildActionOnly]
        public ActionResult AfficheListeRestaurant()
        {
            List<Models.Resto> listeDesRestos = new List<Models.Resto>
            {
                new Models.Resto {Id=1,Nom="Resto pinambour", Telephone="0102030405"},
                new Models.Resto {Id=2, Nom="Resto tologie", Telephone="0102030405"},
                new Models.Resto {Id=5, Nom="Resto ride", Telephone="0102030405"},
                new Models.Resto {Id=9, Nom="Resto toro", Telephone="0102030405"}
            };
            return PartialView(listeDesRestos);
        }

    }
}
