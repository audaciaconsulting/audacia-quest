using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core
{
    public interface IGameContext
    {
        void AddAsset(string assetSource);

        void ClearAssets();

        Task Draw();
    }
}
