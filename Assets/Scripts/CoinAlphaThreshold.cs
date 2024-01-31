using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAlphaThreshold : MonoBehaviour
{
    private Image coinImage;

    private void Awake()
    {
        coinImage = GetComponent<Image>();
        coinImage.alphaHitTestMinimumThreshold = .001f;
    }
}
