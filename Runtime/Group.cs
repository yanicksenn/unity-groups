using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Groups
{
    [CreateAssetMenu(menuName = Groups.RootMenu + "/Create group", fileName = "Group")]
    public class Group : ScriptableObject, IEnumerable<GameObject>
    {
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        public IEnumerable<GameObject> GameObjects => _gameObjects.AsReadOnly();

        [SerializeField, TextArea]
        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject != null)
                _gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (gameObject != null)
                _gameObjects.Remove(gameObject);
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return GameObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}