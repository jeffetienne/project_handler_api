using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProjectHandler.Controllers.Api;
using System.Web.Http.Results;

namespace ProjectHandler.UnitTests
{
    /// <summary>
    /// Summary description for ProjetControllerTest
    /// </summary>
    [TestFixture]
    public class ProjetControllerTest
    {

        [Test]
        public void GetProjets_Called_ReturnsOk()
        {
            var controller = new ProjetController();

            var result = controller.GetProjets();

            NUnit.Framework.Assert.That(result, Is.TypeOf<OkResult>());
        }
    }
}
