using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public FloatValue RingValue;
    public FloatValue RingCapacity;
    public FloatValue CoreValue;
    public float RegenerationRate;

    private void Update()
    {
        if (Math.Abs(CoreValue.Value) < float.Epsilon)
            return;

        if (Math.Abs(RingValue.Value - RingCapacity.Value) < float.Epsilon)
            return;

        var newValue = RingValue.Value + CoreValue.Value * RegenerationRate * Time.deltaTime;

        RingValue.Value = Math.Min(newValue, RingCapacity.Value);
    }
}
