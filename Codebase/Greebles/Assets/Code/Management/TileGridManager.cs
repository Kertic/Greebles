using System;
using Code.Management.Services;
using Code.Player;
using UnityEngine;

namespace Code.Management
{
    public class TileGridManager : BaseService
    {
        private GameManager _gameManager;

        [SerializeField] private Grid _grid = null;
        [SerializeField] private Camera _mainCamera = null;

        private Vector3Int _mousedOverCell;

        public override void AddToServiceManager()
        {
            ServiceManager.Instance.AddService(this);
        }

        protected override void ResolveServices()
        {
            _gameManager = ServiceManager.Instance.Resolve<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            _mousedOverCell = _grid.WorldToCell(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}