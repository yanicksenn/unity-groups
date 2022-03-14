using System;
using UnityEngine;
using UnityEngine.Events;

namespace Groups
{
    /// <summary>
    /// Represents a toggleable wrapper for an empty UnityEvent.
    /// </summary>
    [Serializable]
    public class TogglableEvent
    {
        [SerializeField]
        private bool active = true;
        
        /// <summary>
        /// If the UnityEvent can be invoked.
        /// </summary>
        public bool Active
        {
            get => active;
            set => active = value;
        }

        [SerializeField]
        private UnityEvent unityEvent = new UnityEvent();
        
        /// <summary>
        /// UnityEvent to listen to.
        /// </summary>
        public UnityEvent UnityEvent => unityEvent;

        /// <summary>
        /// Invokes the UnityEvent if it is active.
        /// </summary>
        public bool Invoke()
        {
            if (Active)
                UnityEvent.Invoke();
            return Active;
        }
    }
}