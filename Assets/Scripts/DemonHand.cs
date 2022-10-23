using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DemonHand : MonoBehaviour
{
    [SerializeField]
    private int chandeOfLivingAfterCreated = 5;
    [SerializeField]
    private float velocity;


    private void Awake()
    {
        if (Random.Range(0, 10) > this.chandeOfLivingAfterCreated - 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.MoveLeft();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void MoveLeft()
    {
        this.transform.Translate(Vector3.left * this.velocity * Time.deltaTime);
    }
}
