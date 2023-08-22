using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float LeftSide = -4.5f;//3,5
    public static float RightSide = 4.5f;

    [SerializeField] private float internalLeft;
    [SerializeField] private float internalRight;

    void Update()
    {
        internalRight = RightSide;
        internalLeft = LeftSide;
    }
}