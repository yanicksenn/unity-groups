using NUnit.Framework;
using Tests;

namespace Groups.Tests
{
    public class TogglableEventTest
    {
        private UnityEventListener _listener;
        private TogglableEvent _event;
        
        [SetUp]
        public void SetUp()
        {
            _listener = new UnityEventListener("Event");
            _event = new TogglableEvent();
            _event.UnityEvent.AddListener(_listener.Invoke);
        }

        [Test]
        public void AssertEventIsInvokedWhenActive()
        {
            _event.Active = true; 
            Assert.IsTrue(_event.Invoke());
            _listener.AssertInvocations(1);
        }

        [Test]
        public void AssertEventIsNotInvokedWhenInactive()
        {
            _event.Active = false; 
            Assert.IsFalse(_event.Invoke());
            _listener.AssertNoInvocation();
        }
    }
}