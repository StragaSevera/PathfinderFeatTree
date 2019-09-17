using System;
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
        public string Name { get; }
        public string Category { get; }
        public string Prereq { get; }
        public string Benefit { get; }
        public string Source { get; }

        public Link NameLink { get; }
        public IReadOnlyList<Link> PrereqLinks { get; }
        public IReadOnlyList<Link> BenefitLinks { get; }
        public Link SourceLink { get; }

        public ParsedFeat(IElement name, IElement category, IElement prereq,
            IElement benefit, IElement source)
        {
            Name = name.TextContent;
            Category = category.TextContent;
            Prereq = prereq.TextContent;
            Benefit = benefit.TextContent;
            Source = source.TextContent;

            NameLink = Link.Create(name.QuerySelectorAll<IHtmlAnchorElement>("a").FirstOrDefault());
            PrereqLinks = prereq
                .QuerySelectorAll<IHtmlAnchorElement>("a")
                .Select(Link.Create).ToList();
            BenefitLinks = benefit
                .QuerySelectorAll<IHtmlAnchorElement>("a")
                .Select(Link.Create).ToList();
            NameLink =
                Link.Create(source.QuerySelectorAll<IHtmlAnchorElement>("a").FirstOrDefault());
        }

        public override string ToString()
        {
            string prereqs = PrereqLinks.Any()
                ? string.Join("\n", PrereqLinks.Select(l => l.ToString()))
                : Link.Empty.ToString();
            string benefits = BenefitLinks.Any()
                ? string.Join("\n", BenefitLinks.Select(l => l.ToString()))
                : Link.Empty.ToString();
            return $"Name: {Name}\n{NameLink}\n" +
                   $"Category: {Category}\n" +
                   $"Prerequisites: {Prereq}\n{prereqs}\n" +
                   $"Benefit: {Benefit}\n{benefits}\n" +
                   $"Source: {Source}\n{NameLink}";
        }
    }

    public class Link
    {
        public Uri Uri { get; }
        public string Name { get; }

        private static readonly Uri EmptyUri = new Uri("https://www.d20pfsrd.com");
        public static readonly Link Empty = new Link();

        private Link(IHtmlAnchorElement anchor)
        {
            Uri = new Uri(anchor.Href);
            Name = anchor.TextContent;
        }

        private Link()
        {
            Uri = EmptyUri;
            Name = "Empty";
        }

        public static Link Create(IHtmlAnchorElement anchor)
        {
            return anchor != null ? new Link(anchor) : Empty;
        }

        public override string ToString()
        {
            return Uri == EmptyUri ? "    Empty link" : $"    Link \"{Name}\": {Uri}";
        }
    }
}