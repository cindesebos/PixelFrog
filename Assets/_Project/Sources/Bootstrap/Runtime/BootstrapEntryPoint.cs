using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Bootstrap.Runtime
{
    public class BootstrapEntryPoint : GlobalEntryPoint
    {
        protected override void Awake()
        {
            base.Awake();

            BootService bootService = new BootService(ServiceLocator.Instance.Get<SceneLoader>());

            bootService.Initialize();
        }
    }
}
