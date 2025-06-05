using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute _condHide = (ConditionalHideAttribute)attribute;
        SerializedProperty _sourcePropertyValue = GetConditionalSourcePropertyValue(_condHide, property);

        bool _enabled = CheckCondition(_condHide, _sourcePropertyValue);

        bool _wasEnabled = GUI.enabled;
        GUI.enabled = _enabled;

        if (_enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }

        GUI.enabled = _wasEnabled;

        if (property.serializedObject.targetObject != null)
        {
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute _condHide = (ConditionalHideAttribute)attribute;
        SerializedProperty _sourcePropertyValue = GetConditionalSourcePropertyValue(_condHide, property);

        bool _enabled = CheckCondition(_condHide, _sourcePropertyValue);

        if (_enabled)
            return EditorGUI.GetPropertyHeight(property, label, true);
        else
            return -2;
    }

    private SerializedProperty GetConditionalSourcePropertyValue(ConditionalHideAttribute condHide, SerializedProperty property)
    {
        string[] _path = condHide.ConditionalSourceField.Split('.');
        SerializedProperty _sourceProperty = property.serializedObject.FindProperty(_path[0]);

        for (int i = 1; i < _path.Length; ++i)
        {
            if (_sourceProperty != null)
            {
                _sourceProperty = _sourceProperty.FindPropertyRelative(_path[i]);
            }
        }

        return _sourceProperty;
    }


    private bool CheckCondition(ConditionalHideAttribute condHide, SerializedProperty sourcePropertyValue)
    {
        bool _result = false;

        if (sourcePropertyValue.propertyType == SerializedPropertyType.Enum)
        {
            int _enumValue = sourcePropertyValue.enumValueIndex;

            if (condHide.CompareValue is InputHandler.InputType _compareEnumType)
            {
                _result = _enumValue == (int)_compareEnumType;
            }
            else if (condHide.CompareValue is string compareString)
            {
                int _enumIndex = sourcePropertyValue.enumValueIndex;
                string[] _enumNames = sourcePropertyValue.enumNames;

                if (_enumIndex >= 0 && _enumIndex < _enumNames.Length)
                {
                    _result = _enumNames[_enumIndex] == compareString;
                }
            }
        }
        else if (sourcePropertyValue.propertyType == SerializedPropertyType.Boolean)
        {
            _result = sourcePropertyValue.boolValue;
        }
        else
        {
            _result = true;
        }

        return condHide.Inverse ? !_result : _result;
    }
}