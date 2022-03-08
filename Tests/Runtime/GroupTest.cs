using System.Collections;
using System.Linq;
using NUnit.Framework;
using Tests;
using UnityEngine;
using UnityEngine.TestTools;

namespace Groups.Tests
{
    public class GroupTest
    {
        [UnityTest]
        public IEnumerator AssertRuntimeSetHasInitiallyNoGameObjects()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            Assert.AreEqual(0, group.Count);
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertRuntimeSetBehaviour()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            
            var addListener = new UnityEventListener("Add-Event");
            group.Events.OnAddEvent.AddListener(addListener.Invoke);
            
            var removeListener = new UnityEventListener("Remove-Event");
            group.Events.OnRemoveEvent.AddListener(removeListener.Invoke);
            
            var gameObject1 = new GameObject();
            group.Add(gameObject1);
            
            var gameObject2 = new GameObject();
            group.Add(gameObject2);
            
            Assert.AreEqual(2, group.Count);
            Assert.IsTrue(group.Contains(gameObject1));
            Assert.IsTrue(group.Contains(gameObject2));
            
            addListener.AssertInvocationsWithPayload(gameObject1, 1);
            addListener.AssertInvocationsWithPayload(gameObject2, 1);
            removeListener.AssertNoInvocation();

            group.Remove(gameObject2);
            Assert.AreEqual(1, group.Count);
            Assert.IsTrue(group.Contains(gameObject1));
            
            addListener.AssertInvocationsWithPayload(gameObject1, 1);
            addListener.AssertInvocationsWithPayload(gameObject2, 1);
            removeListener.AssertNoInvocationWithPayload(gameObject1);
            removeListener.AssertInvocationsWithPayload(gameObject2, 1);
            yield return null;
        }
    }
}
