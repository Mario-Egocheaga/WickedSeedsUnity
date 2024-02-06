using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Coin Upgrade/Coin Per Click", fileName ="Coin Per Click")]
public class CoinUpgradePerClick : CoinUpgrade
{
    public override void ApplyUpgrade()
    {
        CoinManager.instance.CoinPerClickUpgrade += upgradeAmount;
    }
}
