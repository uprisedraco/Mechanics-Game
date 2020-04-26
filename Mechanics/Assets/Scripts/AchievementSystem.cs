using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointOfInterest.OnPointOfInterestEntered += POI_OnPointOfInterestEntered;
    }

    private void POI_OnPointOfInterestEntered(PointOfInterest poi)
    {
        string achievementKey = "Achievement " + poi.name;

        if (PlayerPrefs.GetInt(achievementKey) == 1)
            return;

        PlayerPrefs.SetInt(achievementKey, 1);
        Debug.Log("Unlocked achievement: " + poi.name);
    }
}
