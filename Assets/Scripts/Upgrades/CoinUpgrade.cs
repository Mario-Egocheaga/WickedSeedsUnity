using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinUpgrade : ScriptableObject
{
    public float upgradeAmount = 1f;

    public double originalUpgradeCost = 100;
    public double currentUpgradeCost = 100;
    public double CostIncreaseMultiplierPerPurchase = 0.05f;

    public string upgradeButtonText;
    [TextArea(3, 10)]
    public string upgradeButtonDesc;

    public abstract void ApplyUpgrade();

    private void OnValidate()
    {
        currentUpgradeCost = originalUpgradeCost;
    }
}
