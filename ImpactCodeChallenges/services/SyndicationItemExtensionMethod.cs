using ImpactCodeChallenges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.services
{
    public static class SyndicationItemExtensionMethod
    {
        public static List<Item> AsItemsListExtensionMethod(this SyndicationFeed feeds)
        {
            if (feeds.Items.Any())
            {
                var result = new List<Item>();
                foreach (var item in feeds.Items)
                {
                    result.Add(new Item
                    {
                        Title = item.Title?.Text,
                        Description = item.Content?.ToString(),
                        Copyright = item.Copyright?.Text,
                        PubDate = item.PublishDate.UtcDateTime,
                        Id = item.Id
                    });
                }
                return result;
            }
            else
            {
                return new List<Item>();
            }
        }
    }
}
