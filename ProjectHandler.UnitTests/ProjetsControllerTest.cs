using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProjectHandler.Controllers;
using System.Web.Mvc;

namespace ProjectHandler.UnitTests
{
    /// <summary>
    /// Summary description for ProjetsControllerTest
    /// </summary>
    [TestFixture]
    public class ProjetsControllerTest
    {
        [Test]
        public void Edit_Called_ReturnsHttpNotFound()
        {
            var controller = new ProjetsController();

            var result = controller.Edit(0);

            NUnit.Framework.Assert.That(result, Is.TypeOf<HttpNotFoundResult>());
        }

        [Test]
        public void Edit_Called_ReturnsView()
        {
            var controller = new ProjetsController();

            var result = controller.Edit(65);

            NUnit.Framework.Assert.That(result, Is.TypeOf<ViewResult>());
        }


        [Test]
        public void Create_Called_ReturnsView()
        {
            var controller = new ProjetsController();

            var result = controller.Create();

            NUnit.Framework.Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
