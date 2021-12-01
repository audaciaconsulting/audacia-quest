using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Components;

namespace Audacia.Quest.Core
{
    public interface IGameContext
    {
        void LoadContent(List<Sprite> sprites);

        bool ContentLoaded();

        Task Draw(IComponent component);
    }
}
