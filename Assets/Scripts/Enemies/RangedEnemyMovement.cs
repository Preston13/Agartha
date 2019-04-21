using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float minDistance;
    public GameObject player;
    public GameObject rangedWeapon;
    public float timeBetweenAttacks = 3.0f;

    private EnemyStats enemyStats;
    private float angleSpeed;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeAngle", 0, Random.Range(2, 5));

        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //Check if the player is close enough to target
        if(Vector3.Distance(player.transform.position, this.transform.position) < minDistance)
        {
            timer += Time.deltaTime;

            transform.RotateAround( player.transform.position, player.transform.up,angleSpeed * Time.deltaTime);

            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);

            if (timer >= timeBetweenAttacks && enemyStats.curHealth > 0)
            {
                Attack();
            }
        }

        if(Vector3.Distance(player.transform.position, this.transform.position) < 10)
        {
            timer += Time.deltaTime;

            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);

            transform.RotateAround(player.transform.position, player.transform.up, angleSpeed * 3 * Time.deltaTime);

            if (timer >= timeBetweenAttacks && enemyStats.curHealth > 0)
            {
                Attack();
            }
        }
    }

    void ChangeAngle()
    {
        angleSpeed = Random.Range(-moveSpeed, moveSpeed);
        if(angleSpeed < 7f && angleSpeed > -7f)
        {
            angleSpeed = Random.Range(-moveSpeed, moveSpeed);
        }
    }

    void Attack()
    {
        timer = 0f;
        Instantiate(rangedWeapon, this.transform.position + new Vector3(1, -1, 0), this.transform.rotation);

        
    }

}
