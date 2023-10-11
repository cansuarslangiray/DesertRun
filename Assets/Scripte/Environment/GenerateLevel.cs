using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private int zPosition = 150;
    [SerializeField] private bool creatingSection = false;
    [SerializeField] private int secNumber;
    [SerializeField] private GameObject player;
    [SerializeField] private float playerPosition;
    public GameObject DestoyGameObject;
   

   
    void Update()
    {
        
        if (player.transform.position.z >= playerPosition)
        {
            playerPosition += 50;
            GenerateSection();
        }
    }

    private void GenerateSection()
    {
        secNumber = Random.Range(0, 3);
       var platform = Instantiate(section[secNumber], new Vector3(0, 0, zPosition),Quaternion.identity);
        platform.transform.SetParent(DestoyGameObject.transform);
        zPosition += 50;
        creatingSection = false;
        Destroy(DestoyGameObject.transform.GetChild(0).gameObject);
        
    }
}
