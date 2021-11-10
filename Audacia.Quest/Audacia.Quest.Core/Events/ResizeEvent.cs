using Audacia.Quest.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Events
{
    public class ResizeEvent : IEvent<ScreenDimensions>
    {
        private PerformEvent<ScreenDimensions> _performEvent { get; set; }

        public void PerformEvent(ScreenDimensions param)
        {
            _performEvent?.Invoke(param);
        }

        public void Subscribe(PerformEvent<ScreenDimensions> method)
        {
            _performEvent += method;
        }
    }
}
