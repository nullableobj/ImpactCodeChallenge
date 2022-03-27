using ImpactCodeChallenges.Controllers;
using ImpactCodeChallenges.services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Net;

namespace ImpactChallengeTest
{
    public class Tests
    {
        IRssServiceProvider _service;
        ImpactRssController _rss;

        [SetUp]
        public void Setup()
        {
            this._service = new RssServiceProvider();
            _rss = new ImpactRssController(_service);

        }

        [Test]
        public void CallEndPointDummySuccess()
        {
            var resultOk = _rss.GetDummy() as OkObjectResult;
            Assert.IsTrue(resultOk.StatusCode == 200);
        }

        [Test]
        public void CallEndPointFromSourceSuccess()
        {
            var url = "https://www.service-public.fr/abonnements/rss/actu-eadministration.rss";
            var resultOk = _rss.GetFromSource(url) as OkObjectResult;
            Assert.IsTrue(resultOk.StatusCode == 200);
        }


        [Test]
        public void CallEndPointFromSourceFailure()
        {
            var url = "non-valid-url";
            var resultNotFound = _rss.GetFromSource(url) as NotFoundResult;
            Assert.IsTrue(resultNotFound.StatusCode == 404);
        }
    }
}