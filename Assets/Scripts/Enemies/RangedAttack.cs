using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private PlayerStats playerStats;
    private Rigidbody rigid;
    private GameObject player;

    public float minDamage = 5;
    public float maxDamage = 15;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * 30, ForceMode.Impulse);

        Invoke("DestroyThis", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerStats.getRekt(Random.Range(minDamage, maxDamage));
        }
        DestroyThis();
    }
}
