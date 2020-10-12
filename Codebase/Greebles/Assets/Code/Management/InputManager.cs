using System.Collections.Generic;
using Code.Management.Services;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Management
{
    public class InputManager : BaseService
    {
        public enum InputTypes
        {
            UP_HELD,
            DOWN_HELD,
            LEFT_HELD,
            RIGHT_HELD,
            INVENTORY_HELD,
            PLACE_HELD,
            BREAK_HELD,
            UP_TAP,
            DOWN_TAP,
            LEFT_TAP,
            RIGHT_TAP,
            INVENTORY_TAP,
            PLACE_TAP,
            BREAK_TAP,
            NUMOFINPUTS
        }

        private Dictionary<InputTypes, bool> _inputDictionary = new Dictionary<InputTypes, bool>();

        private void Start()
        {
            for (int i = 0; i < (int) InputTypes.NUMOFINPUTS; i++)
            {
                _inputDictionary[(InputTypes) i] = false;
            }
        }
        
        public override void AddToServiceManager()
        {
           ServiceManager.Instance.AddService(this); 
        }

        protected override void ResolveServices()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            CheckHeldButtons();
            CheckTapButton();
        }

        private void CheckTapButton()
        {
            _inputDictionary[InputTypes.UP_TAP] = Input.GetButtonDown("up");
            _inputDictionary[InputTypes.DOWN_TAP] = Input.GetButtonDown("down");
            _inputDictionary[InputTypes.LEFT_TAP] = Input.GetButtonDown("left");
            _inputDictionary[InputTypes.RIGHT_TAP] = Input.GetButtonDown("right");
        }

        private void CheckHeldButtons()
        {
            _inputDictionary[InputTypes.UP_HELD] = Input.GetButton("up");
            _inputDictionary[InputTypes.DOWN_HELD] = Input.GetButton("down");
            _inputDictionary[InputTypes.LEFT_HELD] = Input.GetButton("left");
            _inputDictionary[InputTypes.RIGHT_HELD] = Input.GetButton("right");
        }

        public bool GetButton(InputTypes type)
        {
            return _inputDictionary[type];
        }
    }
}