using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpFireBall : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    
    // Update is called once per frame
    void Update()
    {
        this.MoveLeft();    
    }

    private void MoveLeft()
    {
        this.transform.Translate(Vector3.left * this.velocity * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
