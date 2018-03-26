using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float", order = 0)]
public class FloatVariable : ScriptableObject
{
    [Tooltip("Description of the variable.")]
    [TextArea] [SerializeField] private string description;

    [SerializeField] private float defaultValue;

    private float currentValue;

    public float CurrentValue
    {
        get { return currentValue; }
        set {
            OnVariableChanged();
            currentValue = value;
        }
    }

    private void OnEnable()
    {
        currentValue = defaultValue;
    }

    private void OnVariableChanged()
    {

    }


}
