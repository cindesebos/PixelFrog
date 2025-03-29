using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Bootstrap.Runtime
{
    public class BootService
    {
        private const Scene FirstSceneToLoad = Scene.Menu;

        private readonly SceneLoader _sceneLoader;

        public BootService(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _sceneLoader.LoadScene(FirstSceneToLoad);
        }
    }
}