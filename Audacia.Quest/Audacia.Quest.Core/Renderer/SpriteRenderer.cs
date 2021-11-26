using System.Numerics;

namespace Audacia.Quest.Core.Renderer
{
    public class SpriteRenderer : IRenderer
    {
        public SpriteRenderer(string imageSource)
        {
            ImageSource = imageSource;
        }

        public string ImageSource { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Vector2 Origin { get; set; }
    }
}
