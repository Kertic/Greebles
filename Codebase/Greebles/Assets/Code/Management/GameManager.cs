using Code.Management.Services;
using Code.Player;
using UnityEngine;

namespace Code.Management
{
    public class GameManager : BaseService
    {
        [SerializeField] private PlayerController _player = null;

        public PlayerController Player
        {
            get { return _player; }
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        protected override void ResolveServices()
        {
            
        }

        public override void AddToServiceManager()
        {
           ServiceManager.Instance.AddService(this); 
        }
    }
}