using Audacia.Quest.Core.Asset;
using System.Numerics;

namespace Audacia.Quest.Core.Components.Shared
{
    public delegate void AnimationCompleted();

    public class AnimationComponent : BaseComponent
    {
        public AnimationCompleted AnimationCompletedHandler;

        public Sprite AnimationSprite { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int FramesPerSecond { get; }

        private long _lastUpdate = 0;
        private int _currentFrameIndex = 0;

        private Frame[] _frames;

        public AnimationComponent(Sprite sprite, int width, int height, int framesPerSecond)
            : this(sprite, width, height, null, framesPerSecond) { }

        public AnimationComponent(Sprite sprite, int width, int height, Frame[] frames, int framesPerSecond)
        {
            AnimationSprite = sprite;
            Width = width;
            Height = height;
            FramesPerSecond = framesPerSecond;

            if (frames == null)
            {
                var frameCount = (int)(AnimationSprite.Width / Width);
                _frames = new Frame[frameCount];

                for (int i = 0; i < frameCount; i++)
                {
                    _frames[i] = new Frame();
                    _frames[i].X = i * Width;
                    _frames[i].Y = 0;
                    _frames[i].Width = Width;
                    _frames[i].Height = Height;
                }
            }
            else
            {
                _frames = frames;
            }
        }

        public override void Init()
        {
            AnimationSprite.CurrentFrame.X = 0;
            AnimationSprite.CurrentFrame.Y = 0;
            AnimationSprite.CurrentFrame.Width = Width;
            AnimationSprite.CurrentFrame.Height = Height;
            AnimationSprite.Origin = new Vector2(-Width / 2, -Height / 2);
            Parent.Sprite = AnimationSprite;
        }

        public override void Update()
        {
            NextFrame();
        }

        public void ResetAnimation()
        {
            _currentFrameIndex = 0;
        }


        private void NextFrame()
        {
            if (Time.TotalMiliseconds - _lastUpdate > 1000f / FramesPerSecond)
            {
                _lastUpdate = Time.TotalMiliseconds;

                if (_frames.Length <= _currentFrameIndex + 1)
                {
                    _currentFrameIndex = 0;
                    Parent.Sprite.CurrentFrame = _frames[_currentFrameIndex];
                    AnimationCompletedHandler?.Invoke();
                }
                else
                {
                    _currentFrameIndex++;
                    Parent.Sprite.CurrentFrame = _frames[_currentFrameIndex];
                }
            }
        }
    }
}
