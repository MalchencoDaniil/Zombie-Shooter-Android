using UnityEngine;
using UnityEditor;

public class ConditionalHideAttribute : PropertyAttribute
{
    public string ConditionalSourceField = "";
    public object CompareValue = null;

    public bool Inverse = false;

    public ConditionalHideAttribute(string conditionalSourceField)
    {
        this.ConditionalSourceField = conditionalSourceField;
    }

    public ConditionalHideAttribute(string conditionalSourceField, object compareValue)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.CompareValue = compareValue;
    }

    public ConditionalHideAttribute(string conditionalSourceField, object compareValue, bool inverse)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.CompareValue = compareValue;
        this.Inverse = inverse;
    }
}