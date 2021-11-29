namespace Audacia.Quest.Core.Params
{
    public class ScreenDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ScreenDimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
