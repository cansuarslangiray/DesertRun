using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private GameObject disDisplay;
    [SerializeField] private int disRun;
    [SerializeField] private bool addingDis = false;
    [SerializeField] private float disDilay = 0.35f;

    private void Start()
    {
        StartCoroutine(AddingDis());
    }


    IEnumerator AddingDis()
    {
        while (!Payer.IsDead)
        {
            disRun++;
            disDisplay.GetComponent<Text>().text = "" + disRun;
            yield return new WaitForSeconds(disDilay);
        }

        yield break;
    }
}