using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntializeSeeds : MonoBehaviour
{
    public void Intialize(SeedPayment[] seeds, GameObject UIToSpawn, Transform spawnParent)
    {
        for (int i = 0; i < seeds.Length; i++)
        {
            int currentIndex = i;
            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            seeds[currentIndex].currentSeedCost = seeds[currentIndex].originalSeedCost;

            //set text
            SeedUpdateReference buttonRef = go.GetComponent<SeedUpdateReference>();
            buttonRef.upgradeDescText.SetText(seeds[currentIndex].seedButtonDesc, seeds[currentIndex].seedAmount);
            buttonRef.upgradeCostText.text = "Cost: " + seeds[currentIndex].currentSeedCost;

            //set onClick
            buttonRef.upgradeButton.onClick.AddListener(delegate { CoinManager.instance.OnSeedButtonClick(seeds[currentIndex], buttonRef); });
        }
    }
}
