using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject storeCanvas;
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private TextMeshProUGUI coinPerSecondText;
    [SerializeField] private GameObject coinObj;
    public GameObject coinTextPopUp;
    [SerializeField] private GameObject bgObj;

    [Space]
    public CoinUpgrade[] coinUpgrades;
    [SerializeField] private GameObject storeUIToSpawn;
    [SerializeField] private Transform storeUIToParent;
    public GameObject coinPerSecondOBJToSpawn;

    public double CurrentCoinCount { get; set; }
    public double CurrentCoinPerSeocnd { get; set; }

    public double CoinPerClickUpgrade { get; set; }

    private InitializeUpgrades intializeUpgrades;
    private CoinDisplay coinDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        coinDisplay = GetComponent<CoinDisplay>();

        UpdateCoinUI();
        UpdateCoinPerSecondUI();

        storeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);

        intializeUpgrades = GetComponent<InitializeUpgrades>();
        intializeUpgrades.Intialize(coinUpgrades, storeUIToSpawn, storeUIToParent);

    }


    //Update UI
    private void UpdateCoinUI()
    {
        //coinCounterText.text = CurrentCoinCount.ToString();
        coinDisplay.UpdateCoinText(CurrentCoinCount, coinCounterText);
    }

    private void UpdateCoinPerSecondUI()
    {
        //coinPerSecondText.text = CurrentCoinPerSeocnd.ToString() + "P/S";
        coinDisplay.UpdateCoinText(CurrentCoinPerSeocnd, coinPerSecondText, " P/S");
    }

    public void OnCoinClicked()
    {
        IncreaseCoin();
        coinObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CoinScaleBack);
        bgObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 00.05f), 0.05f).OnComplete(BackgroundScaleBack);

        PopupText.Create(1 + CoinPerClickUpgrade);
    }

    private void CoinScaleBack()
    {
        coinObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    private void BackgroundScaleBack()
    {
        bgObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    public void IncreaseCoin()
    {
        CurrentCoinCount += 1 + CoinPerClickUpgrade;
        UpdateCoinUI();
    }

    public void onStoreButtonPress()
    {
        MainGameCanvas.SetActive(false);
        storeCanvas.SetActive(true);
    }

    public void onResumeButtonPress()
    {
        MainGameCanvas.SetActive(true);
        storeCanvas.SetActive(false);
    }

    public void SimpleCoinIncrease(double amount)
    {
        CurrentCoinCount += amount;
        UpdateCoinUI();
    }

    public void SimpleCoinPerSecondIncrease(double amount)
    {
        CurrentCoinCount += amount;
        UpdateCoinUI();
    }

    public void OnUpgradeButtonClick(CoinUpgrade upgrade, UpgradeButtonReference buttonRef)
    {
        if (CurrentCoinCount >= upgrade.currentUpgradeCost)
        {
            upgrade.ApplyUpgrade();
            CurrentCoinCount -= upgrade.currentUpgradeCost;
            UpdateCoinUI();

            upgrade.currentUpgradeCost = Mathf.Round((float)(upgrade.currentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));

            buttonRef.upgradeCostText.text = "Cost: " + upgrade.currentUpgradeCost;
        }
    }
}
