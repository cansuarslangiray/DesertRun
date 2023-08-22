using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private int zPosition;
    [SerializeField] private bool creatingSection = false;
    [SerializeField] private int secNumber;
   

   
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNumber = Random.Range(0, 3);
        Instantiate(section[secNumber], new Vector3(0, 0, zPosition),Quaternion.identity);
        zPosition += 50;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
