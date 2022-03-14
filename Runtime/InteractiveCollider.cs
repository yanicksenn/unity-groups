using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Groups
{
    /// <summary>
    /// Interactive collider for any type of collider.
    /// Allows for adding interactions without an additional script.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class InteractiveCollider : MonoBehaviour
    {
        [SerializeField] 
        private List<Group> groupsToCollide = new List<Group>();
        
        [SerializeField]
        private TogglableEvent onEnterEvent = new TogglableEvent();
        
        /// <summary>
        /// Toggleable on enter UnityEvent.
        /// </summary>
        public TogglableEvent OnEnterEvent => onEnterEvent;

        [SerializeField]
        private TogglableEvent onLeaveEvent = new TogglableEvent();
        
        /// <summary>
        /// Toggleable on leave UnityEvent.
        /// </summary>
        public TogglableEvent OnLeaveEvent => onLeaveEvent;

        /// <summary>
        /// Adds the provided group to groups which should handle collisions.
        /// </summary>
        /// <param name="group">Group to add</param>
        public void AddGroupToCollide(Group group) => groupsToCollide.Add(group);
        
        /// <summary>
        /// Removes the provided group from groups which should handle collisions.
        /// </summary>
        /// <param name="group">Group to remove</param>
        public void RemoveGroupToCollide(Group group) => groupsToCollide.Remove(group);

        [ContextMenu(nameof(Enter))]
        private void Enter() => OnEnterEvent.Invoke();

        [ContextMenu(nameof(Leave))]
        private void Leave() => OnLeaveEvent.Invoke();

        private void OnCollisionEnter(Collision other) => DetermineEnter(other.gameObject);
        private void OnCollisionExit(Collision other) => DetermineLeave(other.gameObject);

        private void OnTriggerEnter(Collider other) => DetermineEnter(other.gameObject);
        private void OnTriggerExit(Collider other) => DetermineLeave(other.gameObject);

        private void OnCollisionEnter2D(Collision2D other) => DetermineEnter(other.gameObject);
        private void OnCollisionExit2D(Collision2D other) => DetermineLeave(other.gameObject);

        private void OnTriggerEnter2D(Collider2D other) => DetermineEnter(other.gameObject);
        private void OnTriggerExit2D(Collider2D other) => DetermineLeave(other.gameObject);

        private void DetermineEnter(GameObject gameObject) => Determine(gameObject, Enter);
        private void DetermineLeave(GameObject gameObject) => Determine(gameObject, Leave);

        private void Determine(GameObject gameObject, Action func)
        {
            if (groupsToCollide.Count == 0)
                func.Invoke();
            
            else if (groupsToCollide.Any(group => group.IsRelevant(gameObject)))
                func.Invoke();
        }
    }
}