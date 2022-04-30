using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.color = Random.ColorHSV();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("按下空白件");
            spriteRenderer.color = Random.ColorHSV();
        }
    }
}
