using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    void Update()
    {
        StartCoroutine(DestoyGameObject());
    }

    IEnumerator DestoyGameObject()
    {
        yield return new WaitForSeconds(5);
        if (_gameObject.transform.childCount > 5)
        {
            GameObject gameObject = _gameObject.transform.GetChild(0).gameObject;
            Destroy(gameObject);
        }
    }
}