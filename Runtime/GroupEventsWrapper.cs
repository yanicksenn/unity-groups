using System;
using UnityEngine;

namespace Groups
{
    /// <summary>
    /// Wrapper class containing the UnityEvents for Group.
    /// </summary>
    [Serializable]
    public class GroupEventsWrapper
    {
        /// <summary>
        /// Event for added GameObjects.
        /// </summary>
        [SerializeField]
        private GroupEvent onAddEvent = new GroupEvent();
        public GroupEvent OnAddEvent => onAddEvent;

        /// <summary>
        /// Event for removed GameObjects.
        /// </summary>
        [SerializeField]
        private GroupEvent onRemoveEvent = new GroupEvent();
        public GroupEvent OnRemoveEvent => onRemoveEvent;
    }
}