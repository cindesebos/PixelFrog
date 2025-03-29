using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Gameplay.Runtime
{
    public class GameplayEntryPoint : GlobalEntryPoint
    {
        protected override void Awake()
        {
            base.Awake();

            ServiceLocator.Instance.Register(new CharacterInput());
        }
    }
}
