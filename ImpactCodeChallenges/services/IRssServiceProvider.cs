using ImpactCodeChallenges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace ImpactCodeChallenges.services
{
    public interface IRssServiceProvider
    {
        Response<List<Item>> Get(string source = null);

        List<Item> DummyRssContent();
        Response<bool> VerifySource(string sources);
    }
}
