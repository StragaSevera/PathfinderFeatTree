using System;
using AngleSharp.Html.Dom;

namespace PFScrapper
{
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

        private bool Equals(Link other)
        {
            return Equals(Uri, other.Uri);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Link) obj);
        }

        public override int GetHashCode()
        {
            return Uri != null ? Uri.GetHashCode() : 0;
        }

        public static bool operator ==(Link lhs, Link rhs)
        {
            return lhs != null ? lhs.Equals(rhs) : rhs == null;
        }

        public static bool operator !=(Link lhs, Link rhs)
        {
            return !(lhs == rhs);
        }
    }
}