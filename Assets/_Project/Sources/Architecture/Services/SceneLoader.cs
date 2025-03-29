using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Architecture.Services
{
    public class SceneLoader
    {
        public void LoadScene(Scene scene) => LoadSceneAsync(scene).Forget();

        public async UniTask LoadSceneAsync(Scene scene)
        {
            string sceneName = scene.ToString();

            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            
            await UniTask.WaitUntil(() => loadSceneOperation.isDone);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}