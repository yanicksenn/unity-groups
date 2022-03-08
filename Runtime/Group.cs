using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Groups
{
    /// <summary>
    /// Group providing functionality GameObject add and remove GameObjects.
    /// </summary>
    [CreateAssetMenu(menuName = GroupConstants.RootMenu + "/Create group", fileName = "Group")]
    public class Group : ScriptableObject, IReadOnlyList<GameObject>
    {
        private readonly List<GameObject> _groupedObjects = new List<GameObject>();

        public int Count => _groupedObjects.Count;
        public GameObject this[int index] => _groupedObjects[index];

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
        /// <param name="obj">Object GameObject add</param>
        public void Add(GameObject obj)
        {
            if (obj == null)
                return;
            
            _groupedObjects.Add(obj);
            Events.OnAddEvent.Invoke(obj);
        }

        /// <summary>
        /// Removes the provided object from this group.
        /// </summary>
        /// <param name="obj">Object GameObject remove</param>
        public void Remove(GameObject obj)
        {
            if (obj == null)
                return;
            
            _groupedObjects.Remove(obj);
            Events.OnRemoveEvent.Invoke(obj);
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return _groupedObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}