using UnityEngine;

namespace Sources.Gameplay.Runtime.Character
{
    [CreateAssetMenu(menuName = "Sources/Datas/Character", fileName = "CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public float FallSpeedMultiplier { get; private set; }
        [field: SerializeField] public float LowJumpSpeedMultiplier { get; private set; }
        [field: SerializeField] public float CheckGroundRadius { get; private set; }
        [field: SerializeField] public LayerMask GroundLayer { get; private set; }
    }
}