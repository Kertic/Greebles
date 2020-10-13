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

        protected void Start()
        {
            ResolveServices();
        }

        protected abstract void ResolveServices();

        public virtual void AddToServiceManager()
        {
            
        }
    }
}