using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
