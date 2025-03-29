using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Sources.Architecture.Services;

namespace Sources.UI
{
    public class SceneLoaderButton : MonoBehaviour
    {
        [SerializeField] private Scene _sceneToLoad;
        [SerializeField] private Button _button;

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();
        }

        private async UniTask Start()
        {
            SceneLoader sceneLoader = ServiceLocator.Instance.Get<SceneLoader>();

            _button.onClick.AddListener( delegate {
                LoadScene(sceneLoader);
            });
        }

        private async UniTask LoadScene(SceneLoader sceneLoader)
        {
            await sceneLoader.LoadSceneAsync(_sceneToLoad);
        }
    }
}