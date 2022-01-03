using UnityEditor;
using UnityEngine;

namespace EventSystem.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var @event = target as GameEvent;

            if (GUILayout.Button("Raise") && @event != null)
            {
                @event.Raise();
            }
        }
    }
}