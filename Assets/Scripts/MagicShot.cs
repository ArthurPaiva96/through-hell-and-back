using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float range;

    private float initialPositionX;

    private void Awake()
    {
        this.initialPositionX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.MoveRight();
        this.Range();
    }


    private void Range()
    {
        if (this.transform.position.x >= range + this.initialPositionX) Destroy(this.gameObject);
    }

    private void MoveRight()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * velocity);
    }
}
