using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float timeUntilNextSpawn;
    [SerializeField]
    private float timeBetweenSpawn;
    [SerializeField]
    private float initialY;
    [SerializeField]
    private float initialX;

    // Start is called before the first frame update
    void Start()
    {
        this.timeUntilNextSpawn = this.timeBetweenSpawn;
        this.transform.position = new Vector3(this.initialX, this.initialY, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.timeUntilNextSpawn -= Time.deltaTime;
        if(timeUntilNextSpawn <= 0)
        {
            this.GenerateMonsten();
            this.timeUntilNextSpawn = this.timeBetweenSpawn;
        }
    }


    private void GenerateMonsten()
    {
        GameObject.Instantiate(this.prefab, this.transform.position, Quaternion.identity);
    }
}
