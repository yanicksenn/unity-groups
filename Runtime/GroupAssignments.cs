using System.Collections.Generic;
using UnityEngine;

namespace Groups
{
    public class GroupAssignments : MonoBehaviour
    {
        [SerializeField] 
        private List<Group> assignments = new List<Group>();
        public IEnumerable<Group> Assignments => assignments.AsReadOnly();

        private void OnEnable() {
            foreach (var assignment in Assignments)
                assignment.AddGameObject(gameObject);
        }
        private void OnDisable()
        {
            foreach (var assignment in Assignments)
                assignment.RemoveGameObject(gameObject);
        }

        public void AddAssignment(Group group)
        {
            assignments.Add(group);
            if (group != null)
                group.AddGameObject(gameObject);
        }

        public void RemoveAssignment(Group group)
        {
            assignments.Remove(group);
            if (group != null)
                group.RemoveGameObject(gameObject);
        }
    }
}