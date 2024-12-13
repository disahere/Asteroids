using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase._GAME.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;

        private IInputService _inputService;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _inputService = Game.InputService;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 movementInput = _inputService.Axis;

            Vector2 movementVector = movementInput.normalized * movementSpeed;

            _rigidbody2D.velocity = movementVector;
            
            if (movementVector.magnitude > 0.1f)
            {
                float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }
    }
}