using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private readonly List<EventListener> _eventListeners = new List<EventListener>();

        public void Raise()
        {
            foreach (var t in _eventListeners)
            {
                t.OnEventRaised();
            }
        }

        public void Register(EventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnRegister(EventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}
