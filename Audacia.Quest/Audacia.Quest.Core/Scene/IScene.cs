namespace Audacia.Quest.Core.Core
{
    public interface IScene
    {
        void Init();
        void LoadContent();
        void ContentLoaded();
        void Update();
        void Draw();
    }
}
