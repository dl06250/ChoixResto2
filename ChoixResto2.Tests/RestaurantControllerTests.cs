using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ChoixResto2.Controllers;
using ChoixResto2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChoixResto2.Tests
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void RestaurantController_Index_LeControleurEstOk()
        {
            using (IDal dal = new DalEnDur())
            {
                RestaurantController controller = new RestaurantController(dal);

                ViewResult resultat = (ViewResult)controller.Index();

                List<Resto> modele = (List<Resto>)resultat.Model;
                Assert.AreEqual("Resto pinambour", modele[0].Nom);
            }
        }
    }
}
