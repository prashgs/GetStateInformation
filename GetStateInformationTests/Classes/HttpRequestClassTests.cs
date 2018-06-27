using NUnit.Framework;
using GetStateInformation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStateInformation.Classes.Tests
{
    [TestFixture()]
    public class HttpRequestClassTests
    {
        private const string url = @"http://services.groupkt.com/state/get/USA/all";
        [Test()]
        public void submitRequestGoodResponseTest()
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            Assert.That(request.statusCode, Is.EqualTo("OK"));
            Assert.That(request.statusDescription, Is.EqualTo("200"));
        }
        [Test()]
        public void submitRequestBadUrlTest()
        {
            string url = @"http://vices.groupkt.com/state/get/USA/all";
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            Assert.AreNotEqual(request.statusCode, "OK");
            Assert.AreNotEqual(request.statusDescription, "200");
        }

        [Test()]
        [TestCase("AS")]
        public void GetCapitalLargestCityTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, "Pago Pago");
            Assert.AreEqual(request.largestCity, null);
        }

        [Test()]
        [TestCase("az")]
        public void GetCapitalLargestCityLowerCaseAbbrTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, "Phoenix");
            Assert.AreEqual(request.largestCity, "Phoenix");
        }

        [Test()]
        [TestCase("aZ")]
        public void GetCapitalLargestCityLowerUpperCaseAbbrTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, "Phoenix");
            Assert.AreEqual(request.largestCity, "Phoenix");
        }

        [Test()]
        [TestCase("MaryLand")]
        public void GetCapitalLargestCityLowerUpperCaseStateTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, "Annapolis");
            Assert.AreEqual(request.largestCity, "Baltimore");
        }

        [Test()]
        [TestCase("maryland")]
        public void GetCapitalLargestCityLowerCaseStateTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, "Annapolis");
            Assert.AreEqual(request.largestCity, "Baltimore");
        }

        [Test()]
        [TestCase("")]
        public void GetCapitalLargestCityBlankTest(string inputString)
        {
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, null);
            Assert.AreEqual(request.largestCity, null);
        }

        [Test()]
        [TestCase("")]
        public void GetCapitalLargestCitySpacesTest(string inputString)
        {
            inputString = string.Empty;
            StateRequest request = new StateRequest();
            request.submitRequest(url);
            request.GetCapitalLargestCity(inputString);
            Assert.AreEqual(request.capital, null);
            Assert.AreEqual(request.largestCity, null);
        }
    }
}