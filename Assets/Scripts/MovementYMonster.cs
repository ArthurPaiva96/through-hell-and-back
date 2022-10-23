using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class MovementYMonster : BasicMonster
{
    [SerializeField]
    private float turnHeightVariation = 1;
    [SerializeField]
    private float upDownVelocity = 1;
    

    private float initialYPosition;


   
    void Start()
    {
        this.MonstersStartConfiguration();
        this.initialYPosition = this.transform.position.y;
    }

    
    void Update()
    {
        this.MoveLeft();   
        this.MoveUpAndDown();
    }

    private void MoveUpAndDown()
    {
        
        this.transform.Translate(Vector3.up * Time.deltaTime * this.upDownVelocity);
        
        if (this.transform.position.y >= this.initialYPosition + turnHeightVariation || this.transform.position.y <= this.initialYPosition - turnHeightVariation)
        {
            this.upDownVelocity *= -1;
        }
    }
}
