using UnityEngine;

namespace Sources.Architecture.Services
{
    public class GlobalEntryPoint : MonoBehaviour
    {
        protected ServiceLocator ServiceLocator;

        protected virtual void Awake()
        {
            ServiceLocator = new ServiceLocator();

            ServiceLocator.Instance.Register(new SceneLoader());
        }
    }
}