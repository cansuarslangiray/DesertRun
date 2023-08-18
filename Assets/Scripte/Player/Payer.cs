using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Payer : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float leftRightSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.LeftSide)
            {
                transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
            }
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.RightSide)
            {
                transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
            }
        }
    }
}