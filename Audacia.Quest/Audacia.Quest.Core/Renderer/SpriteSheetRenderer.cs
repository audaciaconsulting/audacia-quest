using System.Numerics;

namespace Audacia.Quest.Core.Renderer
{
    public class SpriteSheetRenderer : IRenderer
    {
        private int _currentFrameIndex { get; set; }
        private long _lastUpdate = 0;

        public Frame[] Frames { get; }
        public int FramesPerSecond { get; }

        public string ImageSource { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Vector2 Origin { get; set; }

        public SpriteSheetRenderer(string imageSource, Frame[] frames, int framesPerSecond)
        {
            ImageSource = imageSource;
            Frames = frames;
            FramesPerSecond = framesPerSecond;

            _currentFrameIndex = 0;
        }

        public void NextFrame()
        {
            if(Time.TotalMiliseconds - _lastUpdate > 1000f / FramesPerSecond)
            {
                _lastUpdate = Time.TotalMiliseconds;

                if (Frames.Length <= _currentFrameIndex + 1)
                {
                    _currentFrameIndex = 0;
                }
                else
                {
                    _currentFrameIndex++;
                }
            }
        }

        public Frame GetCurrentFrame()
        {
            return Frames[_currentFrameIndex];
        }
    }
}
