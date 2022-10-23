using UnityEngine;

public class AttackMonster : BasicMonster
{
    [SerializeField]
    private GameObject attackPrefab;
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float chanceOfAttack;

    private float timeUntilNextAttack;

    private void Start()
    {
        this.MonstersStartConfiguration();
        this.timeUntilNextAttack = this.attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        this.MoveLeft();
        this.ConfigureAttack();
    }

    private void ConfigureAttack()
    {
        this.timeUntilNextAttack -= Time.deltaTime;
       if(this.timeUntilNextAttack <= 0){
            this.timeUntilNextAttack = this.attackCooldown;
            if (Random.Range(0, 10) <= chanceOfAttack - 1) this.Attack();
            
        }
    }

    private void Attack()
    {
        Instantiate(this.attackPrefab, new Vector3(this.transform.position.x - 0.5f,
                                                    this.transform.position.y,
                                                    this.transform.position.z), Quaternion.identity);
    }
}
