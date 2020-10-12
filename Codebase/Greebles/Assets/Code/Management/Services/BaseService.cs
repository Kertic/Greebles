using System;
using System.Runtime.CompilerServices;
using Code.Management.Interfaces;
using UnityEngine;

namespace Code.Management.Services
{
    public abstract class BaseService : MonoBehaviour, IService
    {
        protected virtual void Awake()
        {
            AddToServiceManager();
        }

        private void Start()
        {
            ResolveServices();
        }

        protected abstract void ResolveServices();

        public abstract void AddToServiceManager();
    }
}