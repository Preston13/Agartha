using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public enum Status { attacking, hit, frozen, stunned};
    public float maxHealth;

    public float curHealth;

   
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            //Will pass in whatever damage the weapon does
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }
}
