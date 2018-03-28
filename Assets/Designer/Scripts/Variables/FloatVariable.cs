using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float", order = 0)]
public class FloatVariable : ScriptableObject
{
    [Tooltip("Description of the variable.")]
    [TextArea] [SerializeField] private string description;

    [SerializeField] private float defaultValue;

    [SerializeField] private List<FloatEventToRaiseAtValue> valueEvents = new List<FloatEventToRaiseAtValue>();

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
        foreach (FloatEventToRaiseAtValue valueEvent in valueEvents)
            valueEvent.CheckEvent(CurrentValue);
    }
}

[Serializable]
public class EventToRaiseAtValue<T> where T : IComparable
{
    public T Value;
    public GameEvent eventToRaise;

    public void CheckEvent(T CurrentValue)
    {
        if (CurrentValue.CompareTo(Value) == 0)
            eventToRaise.Raise();
    }
}

[Serializable]
public class FloatEventToRaiseAtValue : EventToRaiseAtValue<float>
{

}