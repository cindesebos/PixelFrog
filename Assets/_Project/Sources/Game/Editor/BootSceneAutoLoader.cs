#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Game.Editor
{
    [InitializeOnLoad]
    public class BootSceneAutoLoader
    {
        private static string BootstrapSceneName = Scene.Bootstrap.ToString();

        static BootSceneAutoLoader() => EditorApplication.playModeStateChanged += OnPlayModeChanged;

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if(state != PlayModeStateChange.EnteredPlayMode) return;

            if(SceneManager.GetActiveScene().name != BootstrapSceneName) SceneManager.LoadScene(BootstrapSceneName);
        }
    }
}
#endif