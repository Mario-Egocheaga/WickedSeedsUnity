using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPerSecondTimer : MonoBehaviour
{
    public float timerDuration = 1f;

    public double coinPerSecond { get; set; }

    private float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= timerDuration)
        {
            CoinManager.instance.SimpleCoinIncrease(coinPerSecond);

            counter = 0;
        }
    }
}
