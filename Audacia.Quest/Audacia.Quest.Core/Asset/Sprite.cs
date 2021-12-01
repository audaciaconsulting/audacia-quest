using System.Numerics;

namespace Audacia.Quest.Core.Asset
{
    public class Sprite
    {
        public string ImageSource { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Vector2 Origin { get; set; } = Vector2.Zero;

        public Sprite(string imageSource)
        {
            ImageSource = imageSource;
        }
    }
}
