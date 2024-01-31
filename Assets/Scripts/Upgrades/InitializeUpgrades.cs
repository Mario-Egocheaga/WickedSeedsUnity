using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeUpgrades : MonoBehaviour
{
    public void Intialize(CoinUpgrade[] upgrades, GameObject UIToSpawn, Transform spawnParent)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int currentIndex = 1;
            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            upgrades[currentIndex].currentUpgradeCost = upgrades[currentIndex].originalUpgradeCost;

            //set text
            UpgradeButtonReference buttonRef = go.GetComponent<UpgradeButtonReference>();
            buttonRef.upgradeButtonText.text = upgrades[currentIndex].upgradeButtonText;
            buttonRef.upgradeDescText.SetText(upgrades[currentIndex].upgradeButtonDesc, upgrades[currentIndex].upgradeAmount);
            buttonRef.upgradeCostText.text = "Cost: " + upgrades[currentIndex].currentUpgradeCost;

            //set onClick
            buttonRef.upgradeButton.onClick.AddListener(delegate { CoinManager.instance.OnUpgradeButtonClick(upgrades[currentIndex], buttonRef); });
        }
    }
}
