using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Core
{
    public class SceneManager
    {
        private static List<IScene> _scenes = new List<IScene>();
        private static IScene _currentScene;
        private static bool _shouldLoad = false;

        public static int Add(IScene scene)
        {
            var index = _scenes.Count;

            _scenes.Add(scene);

            if (index == 0)
            {
                SetCurrentScene(0);
            }

            return index;
        }

        public static bool Load()
        {
            if (_shouldLoad)
            {
                _currentScene.Init();
                _currentScene.LoadContent();

                _shouldLoad = false;
                return true;
            }

            return false;
        }

        public static void SetCurrentScene(int index)
        {
            _currentScene = _scenes[index];
            _shouldLoad = true;
        }

        public static IScene GetCurrentScene()
        {
            return _currentScene;
        }
    }
}
