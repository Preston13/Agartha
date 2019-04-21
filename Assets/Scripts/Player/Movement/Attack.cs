using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //This is for testing attacks
    public EnemyStats enemy;
    public Animator swordAnim;

    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && playerStats.status != PlayerStats.PlayerStatus.talking) 
        {
            DoDamage();
        }

        
    }

    public void DoDamage()
    {
        swordAnim.Play("TestSwordAttack");


    }
}
