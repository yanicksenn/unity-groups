using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Groups.Tests
{
    public class GroupAssignmentsTest
    {
        [UnityTest]
        public IEnumerator AssertGameObjectIsAddedWhenActiveTrue()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupAssignments>();
            affiliations.AddAssignment(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            
            Assert.AreEqual(1, group.GameObjects.Count());
            Assert.IsTrue(group.GameObjects.Contains(gameObject));
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertGameObjectIsRemovedWhenActiveFalse()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupAssignments>();
            affiliations.AddAssignment(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            gameObject.SetActive(false);
            
            Assert.AreEqual(0, group.GameObjects.Count());
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertGameObjectIsRemovedWhenAffiliationIsRemoved()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupAssignments>();
            affiliations.AddAssignment(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);

            affiliations.RemoveAssignment(group);
            Assert.AreEqual(0, group.GameObjects.Count());
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertGameObjectIsAddedWhenAffiliationIsAdded()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupAssignments>();
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            
            affiliations.AddAssignment(group);
            Assert.AreEqual(1, group.GameObjects.Count());
            Assert.IsTrue(group.GameObjects.Contains(gameObject));
            yield return null;
        }
    }
}