using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float gravityScale = 1f;
    public float GetGravityScale()
    {
        return gravityScale;

    }
}
