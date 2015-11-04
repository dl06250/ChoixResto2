using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChoixResto2.Controllers;
using System.Web.Mvc;

namespace ChoixResto2.Tests
{
    /// <summary>
    /// Description résumée pour AccueilControlerTests
    /// </summary>
    [TestClass]
    public class AccueilControlerTests
    {
        [TestMethod]
        public void AccueilControler_Index_RenvoiVueParDefaut()
        {
            AccueilController controller = new AccueilController();
            ViewResult resultat = (ViewResult)controller.Index();
            Assert.AreEqual(string.Empty, resultat.ViewName);
        }
    }
}
