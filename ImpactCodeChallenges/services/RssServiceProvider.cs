using ImpactCodeChallenges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace ImpactCodeChallenges.services
{
    public class RssServiceProvider : IRssServiceProvider
    {

        public Response<List<Item>> Get(string source = "")
        {
            try
            {

                if (string.IsNullOrEmpty(source))
                {
                    var result = DummyRssContent();
                    return Response<List<Item>>.GetSuccessfulResponse(result);
                }
                var url = source;
                using var reader = XmlReader.Create(url);
                var feed = SyndicationFeed.Load(reader);
                var thirdPartyResult = feed.AsItemsListExtensionMethod();
                return Response<List<Item>>.GetSuccessfulResponse(thirdPartyResult);
            }
            catch (Exception ex)
            {
                return new Response<List<Item>>
                {
                    HasError = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        public List<Item> DummyRssContent()
        {
             return new List<Item>
            {
                GetRandom(1),GetRandom(2),GetRandom(3),GetRandom(4),GetRandom(5),
                GetRandom(6),GetRandom(7),GetRandom(8),GetRandom(9),GetRandom(10),
            };
        }



        private Item GetRandom(int index)
        {
            return new Item
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"Random Title {index}",
                Copyright = "all rights reserved 2020 - 2021",
                Description = "This is random description just for proof of concept",
                PubDate = DateTime.Now.AddYears(-index)
            };
        }

        public Response<bool> VerifySource(string source)
        {
            return new Response<bool>
            {
                HasError = string.IsNullOrEmpty(source)
            };
        }
    }
}
