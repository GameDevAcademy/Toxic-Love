using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FloatReference : GenericReference<float, FloatVariable>
{
    public FloatReference(float value) : base(value)
    {

    }
}
