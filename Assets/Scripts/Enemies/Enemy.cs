using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Attacking values
    
    public float timeBetweenAttacks = 3f;

    //Movement values
    public float stopDistance = 10f;
    public float minDistance = 30f;
    public float moveSpeed = 5f;

    GameObject player;

    public bool playerInRange;
    


    //Timer to handle attack frequency
    private float timer;

    private PlayerStats playerStats;
    private EnemyStats enemyStats;
    private Vector3 endPosition;
    private float endX;
    private float endZ;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = player.GetComponent<PlayerStats>();
        enemyStats = GetComponent<EnemyStats>();
        //InvokeRepeating("findEndPosition", 0, 5);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        timer += Time.deltaTime;

        //if player is close enough, move toward them
        if (Vector3.Distance(player.transform.position, this.transform.position) < minDistance && !playerInRange)
        {
            
            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
            Move();
            
        }
        else if(playerInRange)
        {
            
            var lookPos = player.transform.position - this.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
            //Attack 
            if (timer >= timeBetweenAttacks && playerInRange && enemyStats.curHealth > 0)
            {
                Attack();
            }
        }

        
    }

    void Attack()
    {
        timer = 0f;

        if (playerStats.curHealth > 0)
        {
            anim.Play("Enemy_Attack");
            
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    



    /*void findEndPosition()
    {
        startPosition = this.transform.position;
        endX = Random.Range(startPosition.x - 30f, startPosition.x + 30f);
        endZ = Random.Range(startPosition.z - 30f, startPosition.z + 30f);
        endPosition = new Vector3(endX, startPosition.y, endZ);
        Debug.Log(endPosition);
        transform.position = Vector3.Lerp(startPosition, endPosition, 0.1f);
    } */
}
