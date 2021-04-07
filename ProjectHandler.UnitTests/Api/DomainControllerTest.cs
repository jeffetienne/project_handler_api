using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProjectHandler.Controllers.Api;
using ProjectHandler.Controllers;
using System.Web.Http.Results;
using System.Web.Http;
using ProjectHandler.Models;
using ProjectHandler.Models.DTOs;

namespace ProjectHandler.UnitTests
{
    /// <summary>
    /// Summary description for DomainControllerTest
    /// </summary>
    [TestFixture]
    public class DomainControllerTest
    {
       
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Test]
        public void GetDomaines_CalledWhenNotNull_ReturnsOk()
        {
            var controller = new DomaineController();

            IHttpActionResult result = controller.GetDomaines();

            NUnit.Framework.Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<IEnumerable<DomaineDTO>>>());
        }

        [Test]
        public void GetDomaines_CalledWhenNull_ReturnsNotFound()
        {
            var controller = new DomaineController();

            IHttpActionResult result = controller.GetDomaines();

            NUnit.Framework.Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void GetDomaine_CalledWhenDomainNotNull_ReturnsOk()
        {
            AutoMapperConfiguration.Configure();
            var controller = new DomaineController();

            var result = controller.GetDomaine(1);

            NUnit.Framework.Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<DomaineDTO>>());
        }

        [Test]
        public void GetDomaine_CalledWhenDomainNull_ReturnsNotFound()
        {
            var controller = new DomaineController();

            var result = controller.GetDomaine(0);

            NUnit.Framework.Assert.That(result, Is.TypeOf<NotFoundResult>());
        }


    }
}
