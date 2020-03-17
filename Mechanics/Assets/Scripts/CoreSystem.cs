using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSystem : MonoBehaviour
{
    public FloatValue RingValue;
    public FloatValue RingCapacity;
    public FloatValue CoreValue;
    public float RegenerationRate;
    public float DepletionRate;

    private void Awake()
    {
        RingValue.Value = RingValue.DefaultValue;
        RingCapacity.Value = RingCapacity.DefaultValue;
        CoreValue.Value = CoreValue.DefaultValue;
    }

    private void Update()
    {
        if (Math.Abs(CoreValue.Value) < float.Epsilon)
            return;

        CoreValue.Value = Math.Max(0, CoreValue.Value - DepletionRate * Time.deltaTime);

        if (Math.Abs(RingValue.Value - RingCapacity.Value) < float.Epsilon)
            return;

        RingValue.Value = Math.Min(RingValue.Value + CoreValue.Value * RegenerationRate * Time.deltaTime, RingCapacity.Value);
    }
}
