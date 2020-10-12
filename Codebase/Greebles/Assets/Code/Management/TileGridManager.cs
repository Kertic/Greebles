using System;
using Code.Management.Services;
using Code.Player;
using UnityEngine;

namespace Code.Management
{
    public class TileGridManager : BaseService
    {
        private PlayerController _player;

        [SerializeField] private Grid _grid;

        public override void AddToServiceManager()
        {
            ServiceManager.Instance.AddService(this);
        }

        protected override void ResolveServices()
        {
            _player = ServiceManager.Instance.Resolve<GameManager>().Player;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(_grid.WorldToCell(_player.transform.position));
        }
    }
}