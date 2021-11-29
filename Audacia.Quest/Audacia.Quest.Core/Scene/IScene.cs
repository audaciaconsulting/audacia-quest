using Audacia.Quest.Core.Components;

namespace Audacia.Quest.Core.Scene
{
    public interface IScene
    {
        void AddComponent(IComponent component);
        void Init();
        void LoadContent();
        void Reset();
        void Update();
        void Draw();
    }
}
