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
        if (sourcePropertyValue == null)
        {
            Debug.LogError("ConditionalHide: Could not find source property " + condHide.ConditionalSourceField);
            return true; // Или false, в зависимости от логики
        }

        bool result = false;

        if (sourcePropertyValue.propertyType == SerializedPropertyType.Enum)
        {
            int enumValue = sourcePropertyValue.enumValueIndex;
            if (condHide.CompareValue is InputHandler.InputType compareEnumType)
            {
                result = enumValue == (int)compareEnumType; // Corrected to compare as integers
            }
            else if (condHide.CompareValue is string compareString)
            {
                int enumIndex = sourcePropertyValue.enumValueIndex;
                string[] enumNames = sourcePropertyValue.enumNames;
                if (enumIndex >= 0 && enumIndex < enumNames.Length)
                {
                    result = enumNames[enumIndex] == compareString;
                }
            }
        }
        else if (sourcePropertyValue.propertyType == SerializedPropertyType.Boolean)
        {
            result = sourcePropertyValue.boolValue;
        }
        else
        {
            Debug.LogWarning("ConditionalHide: Unsupported property type for conditional source field " + condHide.ConditionalSourceField + ". Supported types are Enum and Boolean.");
            result = true; // Или false, в зависимости от логики. По умолчанию показываем, если тип не поддерживается.
        }

        return condHide.Inverse ? !result : result;
    }
}