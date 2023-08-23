using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int _collectedCoin = 0;
   // [SerializeField] private AudioSource coinFx;
    private void OnTriggerEnter(Collider other)
    {
      //coinFx.Play() 
      _collectedCoin++;
      this.gameObject.SetActive(false);
    }
}
