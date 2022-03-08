using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Groups
{
    /// <summary>
    /// Group container for GameObjects.
    /// </summary>
    public class GroupContainer : MonoBehaviour, IReadOnlyList<Group>
    {

        [SerializeField] 
        private List<Group> groups = new List<Group>();

        public int Count => groups.Count;
        public Group this[int index] => groups[index];

        private void OnEnable() {
            foreach (var group in groups)
                group.Add(gameObject);
        }
        
        private void OnDisable()
        {
            foreach (var group in groups)
                group.Remove(gameObject);
        }

        /// <summary>
        /// Adds the provided group to this group container. The groupable object will automatically be added to the
        /// group if the GameObject is active and this behaviour enabled.
        /// </summary>
        /// <param name="group">Group to add</param>
        public void AddGroup(Group group)
        {
            groups.Add(group);
            if (CanInteractWithGroup(group))
                group.Add(gameObject);
        }
        
        /// <summary>
        /// Removes the provided group to this group container. The groupable object will automatically be removed from
        /// the group if the GameObject is active and this behaviour enabled.
        /// </summary>
        /// <param name="group">Group to add</param>
        public void RemoveGroup(Group group)
        {
            groups.Remove(group);
            if (CanInteractWithGroup(group))
                group.Remove(gameObject);
        }

        private bool CanInteractWithGroup(Group group)
        {
            return group != null && isActiveAndEnabled;
        }

        public IEnumerator<Group> GetEnumerator()
        {
            return groups.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}