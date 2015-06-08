using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        private ICollection<IElement> childElements;

        public HTMLElement(string name, string textContent)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name) : this(name, null) { }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(this.childElements); }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.Append(string.Format("<{0}>", this.Name));
            }
            if (!string.IsNullOrEmpty(this.TextContent))
            {
                output.Append(string.Format("{0}", this.TextContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")));
            }
            if (childElements.Count != 0)
            {
                foreach (var child in this.ChildElements)
                {
                    if (child != null)
                    {
                        output.Append(string.Format("{0}", child.ToString()));  
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.Append(string.Format("</{0}>", this.Name));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
