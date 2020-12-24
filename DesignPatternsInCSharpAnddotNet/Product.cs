using System;

namespace DesignPatternsInCSharpAnddotNet
{
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
            Size = size;
        }
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Huge
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }
}