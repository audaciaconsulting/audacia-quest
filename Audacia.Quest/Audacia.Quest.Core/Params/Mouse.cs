namespace Audacia.Quest.Core.Params
{
    public class Mouse
    {
        public int ButtonCode { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Mouse(int buttonCode, int x, int y)
        {
            ButtonCode = buttonCode;
            X = x;
            Y = y;
        }
    }
}
