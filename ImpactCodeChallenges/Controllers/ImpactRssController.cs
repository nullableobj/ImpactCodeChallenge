using ImpactCodeChallenges.Models;
using ImpactCodeChallenges.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace ImpactCodeChallenges.Controllers
{
    [ApiController]
    [Route(@"/")]
    [Route(@"impactchallenge/get-rss")]
    public class ImpactRssController : Controller
    {
        private readonly IRssServiceProvider _serviceProvider;

        public ImpactRssController(IRssServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Route("api/rss/dummy")]
        [ProducesResponseType(StatusCodes.Status226IMUsed, Type= typeof(List<Item>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDummy()
        {
            var result = this._serviceProvider.Get();
            if (result.HasError)
            {
                return NotFound(result);
            }
            return Ok(result.ResponseObject);
        }

        [Route("api/rss/external")]
        [ProducesResponseType(StatusCodes.Status226IMUsed, Type = typeof(List<Item>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFromSource([FromQuery]string source = "")
        {
            var verificationResult = this._serviceProvider.VerifySource(source);
            if (verificationResult.HasError)
            {
                return BadRequest("Source is not valid. Random source retriveied");
            }
            var result = this._serviceProvider.Get(source);
            if (result.HasError)
            {
                return NotFound();
            }
            return Ok(result.ResponseObject);
        }

    }
}
