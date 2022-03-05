using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
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
            Assert.AreEqual(0, group.GameObjects.Count());
            yield return null;
        }

        [UnityTest]
        public IEnumerator AssertRuntimeSetBehaviour()
        {
            var group = ScriptableObject.CreateInstance<Group>();
            var gameObject1 = new GameObject();
            var gameObject2 = new GameObject();
            group.AddGameObject(gameObject1);
            group.AddGameObject(gameObject2);
            Assert.AreEqual(2, group.GameObjects.Count());
            Assert.IsTrue(group.GameObjects.Contains(gameObject1));
            Assert.IsTrue(group.GameObjects.Contains(gameObject2));

            group.RemoveGameObject(gameObject2);
            Assert.AreEqual(1, group.GameObjects.Count());
            Assert.IsTrue(group.GameObjects.Contains(gameObject1));
            yield return null;
        }
    }
}
