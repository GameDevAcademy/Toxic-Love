using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float", order = 0)]
public class FloatVariable : GenericVariable<float>
{

}

[Serializable]
public class FloatEventToRaiseAtValue : EventToRaiseAtValue<float>
{

}
