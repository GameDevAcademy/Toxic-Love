using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float CurrentValue
    {
        get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        set {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.CurrentValue = value;
        }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.CurrentValue;
    }
}