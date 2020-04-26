using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    public float DefaultValue;

    public float Value;

    public static implicit operator float(FloatValue floatValue)
    {
        return floatValue.Value;
    }
}
