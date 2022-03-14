using Groups;
using UnityEditor;
using UnityEngine;

namespace Workspace.unity_groups.Editor
{
    [CustomPropertyDrawer(typeof(TogglableEvent))]
    public class TogglableEventDrawer : PropertyDrawer
    {
        private static readonly float SingleLineHeight = EditorGUIUtility.singleLineHeight;

        public override void OnGUI(Rect totalPosition, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(totalPosition, label, property);

            EditorGUI.BeginChangeCheck();

            var activeProperty = property.FindPropertyRelative("active");
            var unityEventProperty = property.FindPropertyRelative("unityEvent");
            
            var fullEventPosition = new Rect(totalPosition);
            EditorGUI.PropertyField(fullEventPosition, unityEventProperty, new GUIContent(" "));
            
            var fullTogglePosition = new Rect(totalPosition);
            fullTogglePosition.height = SingleLineHeight;
            fullTogglePosition.y += 1;
            fullTogglePosition.x += 8;

            var togglePosition = EditorGUI.PrefixLabel(fullTogglePosition, label);
            activeProperty.boolValue = EditorGUI.ToggleLeft(togglePosition, $"{property.displayName} ()", activeProperty.boolValue);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var unityEventProperty = property.FindPropertyRelative("unityEvent");
            return EditorGUI.GetPropertyHeight(unityEventProperty, false);
        }
    }
}