using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Groups.Tests
{
    public class GroupContainerTest
    {
        [UnityTest]
        public IEnumerator AssertGameObjectIsAddedWhenActiveTrue()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupContainer>();
            affiliations.AddGroup(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            
            Assert.AreEqual(1, group.Count);
            Assert.IsTrue(group.Contains(gameObject));
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertGameObjectIsRemovedWhenActiveFalse()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupContainer>();
            affiliations.AddGroup(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            gameObject.SetActive(false);
            
            Assert.AreEqual(0, group.Count);
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertGameObjectIsRemovedWhenAffiliationIsRemoved()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupContainer>();
            affiliations.AddGroup(group);
            gameObject.SetActive(false);
            gameObject.SetActive(true);

            affiliations.RemoveGroup(group);
            Assert.AreEqual(0, group.Count);
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertGameObjectIsAddedWhenAffiliationIsAdded()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var gameObject = new GameObject();
            var affiliations = gameObject.AddComponent<GroupContainer>();
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            
            affiliations.AddGroup(group);
            Assert.AreEqual(1, group.Count);
            Assert.IsTrue(group.Contains(gameObject));
            yield return null;
        }
    }
}