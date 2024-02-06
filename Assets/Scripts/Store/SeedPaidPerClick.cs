using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Seed Payment/Seed Paid Per Minute", fileName ="Seed Per Click")]
public class SeedPaidPerClick : SeedPayment
{
    public override void ApplySeed()
    {
        Debug.Log("Adding Seed To Garden");

        //GameObject seed = Instantiate(seedPrefab);
       // GardenPlacement.instance.items.Add(seed);
    }
}
