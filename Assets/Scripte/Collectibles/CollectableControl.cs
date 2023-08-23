using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int CoinNumber;
    [SerializeField] private GameObject coinCounterDisplay;
  
    void Update()
    {
        coinCounterDisplay.GetComponent<Text>().text = " " + CoinNumber;
    }
}
