using System;
using Code.Management;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour
    {
        private InputManager _inputManager;
        private bool _isFacingRight;
        private static readonly int _isWalking = Animator.StringToHash("isWalking");

        [SerializeField] public float movementSpeed;
        [SerializeField] public Animator animator;
        [SerializeField] public SpriteRenderer sprite;
        [SerializeField] public Rigidbody2D rigidBody;

        private void ResolveServices()
        {
            _inputManager = ServiceManager.Instance.Resolve<InputManager>();
        }

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            ResolveServices();
            _isFacingRight = true;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateMotion();
        }

        private void UpdateMotion()
        {
            void UpdateDirection(InputManager.InputTypes type, Vector3 movementDirection)
            {
                if (!_inputManager.GetButton(type)) return;
                gameObject.transform.position += movementDirection * movementSpeed;
                animator.SetBool(_isWalking, true);
            }

            animator.SetBool(_isWalking, false);
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

            sprite.flipX = !_isFacingRight;
        }
    }
}