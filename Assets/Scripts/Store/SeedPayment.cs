using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SeedPayment : ScriptableObject
{
    public GameObject seedPrefab;

    public float seedAmount = 1f;

    public double originalSeedCost = 100;
    public double currentSeedCost = 100;
    public double costIncreaseMultiplierPerPurchase = 1f;

    [TextArea(3, 10)]
    public string seedButtonDesc;

    public abstract void ApplySeed();

    private void OnValidate()
    {
        currentSeedCost = originalSeedCost;
    }
}
