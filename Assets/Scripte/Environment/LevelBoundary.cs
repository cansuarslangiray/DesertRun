using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float LeftSide = -3.5f;
    public static float RightSide = 3.5f;

    [SerializeField] private float internalLeft;
    [SerializeField] private float internalRight;

    void Update()
    {
        internalRight = RightSide;
        internalLeft = LeftSide;
    }
}