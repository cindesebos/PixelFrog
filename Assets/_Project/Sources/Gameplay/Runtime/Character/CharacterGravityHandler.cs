using UnityEngine;
using Sources.Architecture.Services;

namespace Sources.Gameplay.Runtime.Character
{
    public class CharacterGravityHandler : MonoBehaviour
    {
        private CharacterData _data;

        private float _fallSpeedMultiplier;
        private float _lowJumpSpeedMultiplier;

        private Rigidbody2D _rigidbody2D;

        public void Init(CharacterData data, Rigidbody2D rigidbody2D)
        {
            _data = data;

            _fallSpeedMultiplier = _data.FallSpeedMultiplier;
            _lowJumpSpeedMultiplier = _data.LowJumpSpeedMultiplier;
            
            _rigidbody2D = rigidbody2D;
        }

        private void Update()
        {
            if(_rigidbody2D.linearVelocity.y < 0) _rigidbody2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (_fallSpeedMultiplier - 1) * Time.deltaTime;
            else if(_rigidbody2D.linearVelocity.y > 0) _rigidbody2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (_lowJumpSpeedMultiplier - 1) * Time.deltaTime;
        }
    }
}