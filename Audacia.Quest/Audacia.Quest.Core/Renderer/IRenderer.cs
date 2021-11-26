using System.Numerics;

namespace Audacia.Quest.Core.Renderer
{
    public interface IRenderer
    {
        string ImageSource { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        Vector2 Origin { get; set; }
    }
}
