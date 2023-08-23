using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private GameObject disDisplay;
    [SerializeField] private int disRun;
    [SerializeField] private bool addingDis =false;
   

    
    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun++;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(0.25f);
        addingDis = false;
    }
}
