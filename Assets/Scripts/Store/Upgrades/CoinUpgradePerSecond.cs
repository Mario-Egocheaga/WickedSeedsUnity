using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Coin Upgrade/Coin Per Second", fileName ="Coin per Second")]
public class CoinUpgradePerSecond : CoinUpgrade
{
    public override void ApplyUpgrade()
    {
        GameObject go = Instantiate(CoinManager.instance.coinPerSecondOBJToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<CoinPerSecondTimer>().coinPerSecond = upgradeAmount;

        CoinManager.instance.SimpleCoinPerSecondIncrease(upgradeAmount);
    }

}
