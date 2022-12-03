using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 1000;
    
        private PlayerInputActions _playerInput;
        private Vector2 _movementInput;
        private Rigidbody2D _rigidbody;

        public float CurrentSpeed
        {
            get => _movementSpeed;
            set
            {
                _movementSpeed = value;
            }
        }

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void Update()
        {
            _movementInput = _playerInput.Player.Movement.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _movementInput * _movementSpeed * Time.fixedDeltaTime;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}
