using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointOfInterest : MonoBehaviour
{
    public static event Action<PointOfInterest> OnPointOfInterestEntered;

    private void OnTriggerEnter(Collider other)
    {
        if(OnPointOfInterestEntered != null)
        {
            OnPointOfInterestEntered(this);
        }
    }
}
