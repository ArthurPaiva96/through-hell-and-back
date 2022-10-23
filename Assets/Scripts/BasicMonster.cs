using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BasicMonster : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5;
    [SerializeField]
    private float yVariance;
    [SerializeField]
    private int points;
    [SerializeField]
    private AudioSource deathAudio;

    private Points playerpoints;

    private void Start()
    {
        MonstersStartConfiguration();
    }

    protected void MonstersStartConfiguration()
    {
        this.playerpoints = GameObject.FindObjectOfType<Points>();
        if (yVariance != 0) this.transform.Translate(Vector3.up * Random.Range(-yVariance, yVariance));
    }


    // Update is called once per frame
    void Update()
    {
        this.MoveLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ConfigureMagicShotCollision(collision);
        transform.position = Vector3.one * 9999f;
        Destroy(this.gameObject, 1);

    }

    private void ConfigureMagicShotCollision(Collider2D collision)
    {
        if (collision.gameObject.name.Trim().ToLower().Replace(" ", "").Contains("magicshot"))
        {

            this.deathAudio.Play();
            this.playerpoints.AddPoints(this.points);
            Destroy(collision.gameObject);
        }
    }

    protected void MoveLeft()
    {
        this.transform.Translate(Vector3.left * velocity * Time.deltaTime);
    }
}
