using Code.Management;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour, IServiceResolvable
    {
        private InputManager _inputManager;
        private bool _isFacingRight;
        private static readonly int _isWalking = Animator.StringToHash("isWalking");

        [SerializeField] public float movementSpeed;
        [SerializeField] public Animator _animator;
        [SerializeField] public SpriteRenderer _sprite;

        public void ResolveServices()
        {
            _inputManager = ServiceManager.Instance.Resolve<InputManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            ResolveServices();
            _isFacingRight = true;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateMotion();
        }

        private void UpdateMotion()
        {
            void UpdateDirection(InputManager.InputTypes type, Vector3 movementDirection)
            {
                if (!_inputManager.GetButton(type)) return;
                gameObject.transform.position += movementDirection * movementSpeed;
                _animator.SetBool(_isWalking, true);
            }

            _animator.SetBool(_isWalking, false);
            UpdateDirection(InputManager.InputTypes.UP_HELD, Vector3.up);
            UpdateDirection(InputManager.InputTypes.DOWN_HELD, Vector3.down);
            UpdateDirection(InputManager.InputTypes.LEFT_HELD, Vector3.left);
            UpdateDirection(InputManager.InputTypes.RIGHT_HELD, Vector3.right);
            if (_inputManager.GetButton(InputManager.InputTypes.LEFT_HELD))
            {
                _isFacingRight = false;
            }

            if (_inputManager.GetButton(InputManager.InputTypes.RIGHT_HELD))
            {
                _isFacingRight = true;
            }

            _sprite.flipX = !_isFacingRight;
        }
    }
}