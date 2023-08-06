using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Payer : MonoBehaviour
{
    [SerializeField] private float speed =3f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.World);
    }
}
