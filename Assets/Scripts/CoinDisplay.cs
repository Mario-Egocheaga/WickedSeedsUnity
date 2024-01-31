using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public void UpdateCoinText(double coinCount, TextMeshProUGUI textToChange, string optionalEndText = null)
    {
        string[] suffixes = { "", "k", "M", "B", "T", "Q" };
        int index = 0;

        while (coinCount >= 1000 && index < suffixes.Length - 1)
        {
            coinCount /= 1000;
            index++;

            if (index >= suffixes.Length - 1 && coinCount >= 1000)
            {
                break;
            }
        }

        string formattedText;

        if (index == 0)
        {
            formattedText = coinCount.ToString();
        }
        else
        {
            formattedText = coinCount.ToString("F1") + suffixes[index];
        }

        textToChange.text = formattedText + optionalEndText;
    }
}
