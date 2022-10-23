using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour{
    
    private Rigidbody2D playerRigidBody;

    private Director director;

    private Vector3 initialPosition;

    [SerializeField]
    private GameObject magicShot;

    [SerializeField]
    private int force = 7;

    [SerializeField]
    private float magicCooldownTime;

    private float timeUntilNextMagic;

    private void Awake()
    {
        this.playerRigidBody = this.GetComponent<Rigidbody2D>();
        this.initialPosition = this.transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.FindObjectOfType<Director>();
        this.timeUntilNextMagic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ConfigureMovement();
        this.ConfigureMagicShot();
        this.MagicCooldownCalc();
    }

    private void MagicCooldownCalc()
    {
        this.timeUntilNextMagic -= Time.deltaTime;
    }

    private void ConfigureMagicShot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.timeUntilNextMagic <= 0)
        {
            
            Instantiate(this.magicShot, new Vector3(this.transform.position.x + 0.5f, 
                                                    this.transform.position.y, 
                                                    this.transform.position.z), Quaternion.identity);

            this.timeUntilNextMagic = this.magicCooldownTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        String collisionName = collision.gameObject.name.ToLower().Replace(" ", "");
        if (!(collisionName.Contains("floor") || collisionName.Contains("barrier")))
            this.playerRigidBody.simulated = false;
        this.director.EndGame();
        
    }

    private void ConfigureMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.playerRigidBody.velocity = Vector2.zero;
            this.playerRigidBody.AddForce(Vector2.up* force, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    public void Restart()
    {
        this.transform.position = this.initialPosition;
        this.playerRigidBody.simulated = true;
    }
}
