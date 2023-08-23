using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
   // [SerializeField] private AudioSource coinFx;
    private void OnTriggerEnter(Collider other)
    {
      //coinFx.Play() 
      CollectableControl.CoinNumber += 1;
      this.gameObject.SetActive(false);
    }
}
