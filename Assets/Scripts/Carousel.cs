using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5;
    private Vector3 initialPosition;
    private float imageSize;

    private void Awake()
    {
        this.initialPosition = this.transform.position;
        this.imageSize = this.GetComponent<SpriteRenderer>().size.x * this.transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.FloorLoop();
        
    }

    private void FloorLoop()
    {
        float movement = Mathf.Repeat(this.velocity * Time.time, this.imageSize);
        this.transform.position = this.initialPosition + Vector3.left * movement;
    }
}
