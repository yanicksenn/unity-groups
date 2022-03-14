using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Groups
{
    /// <summary>
    /// Group providing functionality GameObject add and remove GameObjects.
    /// </summary>
    [CreateAssetMenu(menuName = GroupConstants.RootMenu + "/Create group", fileName = "Group")]
    public class Group : ScriptableObject, IReadOnlyList<GameObject>
    {
        private readonly List<GameObject> groupedObjects = new List<GameObject>();

        public int Count => groupedObjects.Count;
        public GameObject this[int index] => groupedObjects[index];

        /// <summary>
        /// The description.
        /// </summary>
        [SerializeField, TextArea] 
        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }

        /// <summary>
        /// The events.
        /// </summary>
        [SerializeField, Space]
        private GroupEventsWrapper events = new GroupEventsWrapper();
        public GroupEventsWrapper Events => events;

        /// <summary>
        /// Adds the provided object GameObject this group.
        /// </summary>
        /// <param name="obj">GameObject to add</param>
        public void Add(GameObject obj)
        {
            if (obj == null)
                return;
            
            groupedObjects.Add(obj);
            Events.OnAddEvent.Invoke(obj);
        }

        /// <summary>
        /// Removes the provided object from this group.
        /// </summary>
        /// <param name="obj">GameObject to remove</param>
        public void Remove(GameObject obj)
        {
            if (obj == null)
                return;
            
            groupedObjects.Remove(obj);
            Events.OnRemoveEvent.Invoke(obj);
        }

        /// <summary>
        /// Returns if the provided GameObject is part of this group.
        /// </summary>
        /// <param name="obj">GameObject to check</param>
        /// <returns>If GameObject is part of this group</returns>
        public bool IsRelevant(GameObject obj)
        {
            var groupContainer = obj.GetComponent<GroupContainer>();
            return groupContainer != null && groupContainer.Contains(this);
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return groupedObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}