using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PFScrapper
{
    public class ParsedFeat
    {
        private string Name { get; }
        private string Category { get; }
        private string Prereq { get; }
        private string Benefit { get; }
        private string Source { get; }

        private readonly Link _nameLink;
        private readonly IReadOnlyList<Link> _prereqLinks;
        private readonly IReadOnlyList<Link> _benefitLinks;
        private readonly Link _sourceLink;

        private readonly IList<ParsedFeat> _prereqFeats = new List<ParsedFeat>();
        private readonly IList<ParsedFeat> _dependentFeats = new List<ParsedFeat>();

        public ParsedFeat(IElement name, IElement category, IElement prereq,
            IElement benefit, IElement source)
        {
            Name = name.TextContent;
            Category = category.TextContent;
            Prereq = prereq.TextContent;
            Benefit = benefit.TextContent;
            Source = source.TextContent;

            _nameLink = Link.Create(name.QuerySelectorAll<IHtmlAnchorElement>("a").FirstOrDefault());
            _prereqLinks = prereq
                .QuerySelectorAll<IHtmlAnchorElement>("a")
                .Select(Link.Create).ToList();
            _benefitLinks = benefit
                .QuerySelectorAll<IHtmlAnchorElement>("a")
                .Select(Link.Create).ToList();
            _sourceLink =
                Link.Create(source.QuerySelectorAll<IHtmlAnchorElement>("a").FirstOrDefault());
        }

        public string FormatWithLinks()
        {
            string prereqs = _prereqLinks.Any()
                ? string.Join("\n", _prereqLinks.Select(l => l.ToString()))
                : Link.Empty.ToString();
            string benefits = _benefitLinks.Any()
                ? string.Join("\n", _benefitLinks.Select(l => l.ToString()))
                : Link.Empty.ToString();
            return $"Name: {Name}\n{_nameLink}\n" +
                   $"Category: {Category}\n" +
                   $"Prerequisites: {Prereq}\n{prereqs}\n" +
                   $"Benefit: {Benefit}\n{benefits}\n" +
                   $"Source: {Source}\n{_sourceLink}";
        }

        public override string ToString()
        {
            string prereqs = _prereqFeats.Any()
                ? string.Join("\n", _prereqFeats.Select(l => "    " + l.Name))
                : "    No prerequisite feats";
            return $"Name: {Name}\n" +
                   $"Category: {Category}\n" +
                   $"Prerequisites: {Prereq}\n{prereqs}\n" +
                   $"Benefit: {Benefit}\n" +
                   $"Source: {Source}\n";
        }

        public void MapLinks(IEnumerable<ParsedFeat> feats)
        {
            var prereqFeats = feats.Where(f => _prereqLinks.Contains(f._nameLink));

            foreach (ParsedFeat feat in prereqFeats)
            {
                AddPrereqFeat(feat);
            }
        }

        private void AddPrereqFeat(ParsedFeat feat)
        {
            _prereqFeats.Add(feat);
            feat._dependentFeats.Add(this);
        }
    }
}