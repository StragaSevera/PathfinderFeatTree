using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using PFScrapper.Vendor;

namespace PFScrapper
{
    internal static class Program
    {
        private const string Address = "https://www.d20pfsrd.com/feats/Combat-feats/";
        private static readonly Url _url = new Url(Address);

        public static async Task Main(string[] args)
        {
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(_url);

            const string selector = "table";
            IElement table = document.QuerySelectorAll(selector).First();
            IElement tbody = table.QuerySelector("tbody");

            var feats = ParseFeats(tbody);

            foreach ((ParsedFeat item, int i) in feats.WithIndex())
            {
                Console.WriteLine(item);
                if (i < feats.Count - 1) Console.WriteLine("\n");
            }
        }

        private static List<ParsedFeat> ParseFeats(IElement tbody)
        {
            var parsedFeats = tbody.Children.Select(
                    tr => new ParsedFeat
                    (
                        name: tr.Children[0],
                        category: tr.Children[1],
                        prereq: tr.Children[2],
                        benefit: tr.Children[3],
                        source: tr.Children[4]
                    ))
                .ToList();

            foreach (ParsedFeat feat in parsedFeats)
            {
                feat.MapLinks(parsedFeats);
            }
            return parsedFeats;
        }
    }
}