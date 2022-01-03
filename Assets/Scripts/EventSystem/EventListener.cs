using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public class EventListener : MonoBehaviour
    {
        public GameEvent @event;
        public UnityEvent response;

        private void OnEnable() => @event.Register(this);
        private void OnDisable() => @event.UnRegister(this);
        public void OnEventRaised() => response.Invoke();
    }
}