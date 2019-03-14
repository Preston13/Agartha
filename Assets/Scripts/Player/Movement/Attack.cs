using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //This is for testing attacks
    public EnemyStats enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoDamage();
        }

        
    }

    public void DoDamage()
    {
        enemy.TakeDamage(10);


    }
}
