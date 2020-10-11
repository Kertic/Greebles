using Code.Management;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour, IServiceResolvable
    {
        private InputManager _inputManager;

        public void ResolveServices()
        {
            _inputManager = ServiceManager.Instance.Resolve<InputManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            ResolveServices();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputManager.GetButton(InputManager.InputTypes.UP_TAP))
            {
                Debug.Log("Up tapped");
            }
        }
    }
}