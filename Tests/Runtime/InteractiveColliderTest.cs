using System.Collections;
using Tests;
using UnityEngine;
using UnityEngine.TestTools;

namespace Groups.Tests
{
    public class InteractiveColliderTest
    {
        private static readonly Vector3 Left = Vector3.left * 10;
        private static readonly Vector3 Right = Vector3.right * 10;
        private static readonly Vector3 Up = Vector3.up * 10;

        private const float WaitingPeriod = 0.5f;
        
        private Group _groupA;
        private Group _groupB;
        private Group _groupC;
        
        private UnityEventListener listenerEnter;
        private UnityEventListener listenerLeave;
        private InteractiveCollider _interactiveCollider;

        private GameObject _gameObjectA;
        private GameObject _gameObjectB;
        private GameObject _gameObjectC;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            _groupA = ScriptableObject.CreateInstance<Group>();
            _groupB = ScriptableObject.CreateInstance<Group>();
            _groupC = ScriptableObject.CreateInstance<Group>();
            
            listenerEnter = new UnityEventListener("Enter");
            listenerLeave = new UnityEventListener("Leave");

            _gameObjectA = new GameObject();
            _gameObjectA.name = "A";
            _gameObjectA.transform.position = Left;
            _gameObjectA.transform.localScale = Vector3.one;
            _gameObjectA.AddComponent<BoxCollider>();
            var groupContainerA = _gameObjectA.AddComponent<GroupContainer>();
            groupContainerA.AddGroup(_groupA);
            _interactiveCollider = _gameObjectA.AddComponent<InteractiveCollider>();
            _interactiveCollider.OnEnterEvent.UnityEvent.AddListener(listenerEnter.Invoke);
            _interactiveCollider.OnLeaveEvent.UnityEvent.AddListener(listenerLeave.Invoke);
            var rigidbodyA = _gameObjectA.AddComponent<Rigidbody>();
            rigidbodyA.useGravity = false;

            _gameObjectB = new GameObject();
            _gameObjectB.name = "B";
            _gameObjectB.transform.position = Right;
            _gameObjectB.transform.localScale = Vector3.one;
            _gameObjectB.AddComponent<BoxCollider>();
            var groupContainerB = _gameObjectB.AddComponent<GroupContainer>();
            groupContainerB.AddGroup(_groupB);
            
            _gameObjectC = new GameObject();
            _gameObjectC.name = "C";
            _gameObjectC.transform.position = Up;
            _gameObjectC.transform.localScale = Vector3.one;
            var boxColliderC = _gameObjectC.AddComponent<BoxCollider>();
            boxColliderC.isTrigger = true;
            var groupContainerC = _gameObjectC.AddComponent<GroupContainer>();
            groupContainerC.AddGroup(_groupC);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AssertEnterAndLeaveWithAnyObject()
        {
            yield return CollisionEnter();
            yield return CollisionLeave();
            yield return AssertInvocations(2);
        }

        [UnityTest]
        public IEnumerator AssertEnterAndLeaveWithTargetedGroup()
        {
            _interactiveCollider.AddGroupToCollide(_groupB);
            _interactiveCollider.AddGroupToCollide(_groupC);
            
            yield return CollisionEnter();
            yield return CollisionLeave();
            yield return AssertInvocations(2);
        }

        [UnityTest]
        public IEnumerator AssertEnterAndLeaveOnlyWithGroupB()
        {
            _interactiveCollider.AddGroupToCollide(_groupB);
            
            yield return CollisionEnter();
            yield return CollisionLeave();
            yield return AssertInvocations(1);
        }

        [UnityTest]
        public IEnumerator AssertEnterAndLeaveOnlyWithGroupC()
        {
            _interactiveCollider.AddGroupToCollide(_groupC);
            
            yield return CollisionEnter();
            yield return CollisionLeave();
            yield return AssertInvocations(1);
        }
        
        [UnityTearDown]
        public IEnumerator TearDown()
        {
            Object.Destroy(_groupA);
            Object.Destroy(_groupB);
            Object.Destroy(_groupC);

            Object.Destroy(_gameObjectA);
            Object.Destroy(_gameObjectB);
            Object.Destroy(_gameObjectC);
            yield return null;
        }

        private IEnumerator CollisionEnter()
        {
            _gameObjectA.transform.position = Vector3.zero;
            _gameObjectB.transform.position = Vector3.zero;
            _gameObjectC.transform.position = Vector3.zero;
            yield return new WaitForSeconds(WaitingPeriod);
        }
        
        private IEnumerator CollisionLeave()
        {
            _gameObjectA.transform.position = Left;
            _gameObjectB.transform.position = Right;
            _gameObjectC.transform.position = Up;
            yield return new WaitForSeconds(WaitingPeriod);
        }
        
        private IEnumerator AssertInvocations(int invocations)
        {
            listenerEnter.AssertInvocations(invocations);
            listenerLeave.AssertInvocations(invocations);
            yield return null;
        }
    }
}