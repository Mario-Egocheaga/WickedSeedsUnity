using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WateringBar : MonoBehaviour
{
    public Slider fillBar;
    public float water;
    public float waterValue;
    float elapsed = 0f;
    float fulltimer = 120f;

    public void WaterLose(float value)
    {
        if (water <= 0)
        {
            GardenPlacement.instance.FinishedPlanted(this.GetComponent<GardenSpot>().ID);
            return;
        }

        water -= value;
        fillBar.value = water / 100;
    }

    public void Watering(float value)
    {
        if (water >= 100)
        {
            return;
        }

        water += value;
        fillBar.value = water / 100;

    }

    void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= fulltimer)
        {
            elapsed = elapsed % 1f;
            WaterLose(waterValue);
        }
    }
}
