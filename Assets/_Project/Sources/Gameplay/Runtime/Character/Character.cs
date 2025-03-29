using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Gameplay.Runtime.Character
{
    [RequireComponent(typeof(CharacterMovement), typeof(CharacterGravityHandler))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _data;
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterGravityHandler _gravityHandler;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private CharacterInput _input;

        private void OnValidate()
        {
            _movement ??= GetComponent<CharacterMovement>();
            _gravityHandler ??= GetComponent<CharacterGravityHandler>();
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _input = ServiceLocator.Instance.Get<CharacterInput>();

            _movement.Init(_data, _input, _rigidbody2D);
            _gravityHandler.Init(_data, _rigidbody2D);

            _input.Enable();
        }

        private void OnDestroy() => _input.Disable();
    }
}