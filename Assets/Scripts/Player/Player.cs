using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player S;

    public int baseHealth;
    public double currentHealth;
    public int maxHealth;
    public double healthRegenRate;
    //tenacity is the resistance to status effects.  A percentage of 0-1 that reduces the time of status effects by that percent
    public double tenacity;

    public bool guarding = false;

    public GuardianAbilities guardianAbilities;

    // Start is called before the first frame update
    void Start()
    {
        S = this;

        maxHealth = baseHealth;
        currentHealth = maxHealth;

        guardianAbilities = GetComponent<GuardianAbilities>();
        guardianAbilities.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            guardianAbilities.addVigorLevel();
        if (Input.GetKeyDown(KeyCode.W))
            guardianAbilities.addResurgenceLevel();
        if (Input.GetKeyDown(KeyCode.E))
            guardianAbilities.addTenacityLevel();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("Guarding", !guarding);
            guarding = !guarding;
        }
    }
}
