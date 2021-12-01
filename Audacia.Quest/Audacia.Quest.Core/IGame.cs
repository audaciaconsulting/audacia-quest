namespace Audacia.Quest.Core
{
    public interface IGame
    {
        void Init();
        void ContentLoaded();
        bool Update();
        void Draw();
    }
}
