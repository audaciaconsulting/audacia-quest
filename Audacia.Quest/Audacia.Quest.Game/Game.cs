using Audacia.Quest.Core;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;

namespace Audacia.Quest
{
    public class Game
    {
        private readonly IGameContext _conext;

        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;

        public Game(IGameContext conext)
        {
            _conext = conext;

            EventsCollection.Subscribe<Keyboard>(EventConstants.KEY_DOWN, OnKeyDown);
        }

        private void OnKeyDown(Keyboard keyboard)
        {
        }

        public void Init()
        {
        }

        public void LoadContent()
        {
        }

        public void Update()
        {
            End = DateTime.Now;
            Time.DeltaTime = End.Ticks - Start.Ticks;

            // Do Some Stuff

            Start = End;
        }

        public void Draw()
        {

        }
    }
}
