using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsInCSharpAnddotNet
{
    public class HtmlElement
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int IndentSize = 4;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indent * IndentSize);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', (indent + 1) * IndentSize));
                sb.AppendLine(Text);
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    
    public class HtmlBuilder
    {
        private readonly string _rootName;
        private HtmlElement _root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            _root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string ChildText)
        {
            var e = new HtmlElement(childName, ChildText);
            _root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return _root.ToString();
        }

        public void Clear()
        {
            _root = new HtmlElement {Name = _rootName};
        }
    }
}