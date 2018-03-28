using System;

[Serializable]
public class GenericReference<T, G> where T : IComparable where G : GenericVariable<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public G Variable;

    public GenericReference(T value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public T CurrentValue
    {
        get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        set
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.CurrentValue = value;
        }
    }

    public static implicit operator T(GenericReference<T, G> reference)
    {
        return reference.CurrentValue;
    }
}
