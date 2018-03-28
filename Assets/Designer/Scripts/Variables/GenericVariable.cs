using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class GenericVariable<T> : ScriptableObject where T : IComparable
{
    [Tooltip("Description of the variable.")]
    [TextArea]
    [SerializeField]
    private string description;

    [SerializeField] protected T defaultValue;

    [SerializeField]protected T currentValue;

    public T CurrentValue
    {
        get { return currentValue; }
        set
        {
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
        Debug.Log("Variabile was changed. This will be removed in a future version");
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

