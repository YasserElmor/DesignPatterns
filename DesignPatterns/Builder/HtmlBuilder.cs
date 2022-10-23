using System.Text;

namespace DesignPatterns.HtmlBuilder
{
    // Basic fluent builder interface
    public class HtmlBuilder
    {
        private readonly string _rootName;

        public HtmlElement Root { get; private set; }

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            Root = new(_rootName, "");
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            HtmlElement childElement = new(childName, childText);
            Root.Elements.Add(childElement);
            return this;
        }

        public HtmlBuilder AddChild(HtmlElement child)
        {
            Root.Elements.Add(child);
            return this;
        }

        public override string ToString()
        {
            return Root.ToString();
        }

        public void Clear()
        {
            Root = new(_rootName, "");
        }

    }



    public class HtmlElement
    {
        public List<HtmlElement> Elements = new();

        private const int indentLength = 2;

        public string Text { get; set; }
        public string Name { get; set; }

        public HtmlElement(string name, string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        private string ToStringImpl(int noOfIndents)
        {
            StringBuilder sb = new();

            string indentation = new(' ', indentLength * noOfIndents);

            sb.AppendLine($"{indentation}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentLength * (noOfIndents + 1)));
                sb.AppendLine(Text);
            }

            foreach (HtmlElement child in Elements)
            {
                sb.Append(child.ToStringImpl(noOfIndents + 1));
            }

            sb.AppendLine($"{indentation}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }
}
