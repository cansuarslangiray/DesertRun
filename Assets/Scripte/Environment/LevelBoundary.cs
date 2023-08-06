using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float LeftSide;
    public static float RightSide;

    [SerializeField] private float internalLeft;
    [SerializeField] private float internalRight;

    void Update()
    {
        internalRight = RightSide;
        internalLeft = LeftSide;
    }
}