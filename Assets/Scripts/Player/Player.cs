using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player S;

    public TextAsset[] classFiles;

    //current level of health
    public int currentHealth;
    //base health that the max health is calculated from
    public int baseHealth;
    //displayed health on ui
    public int maxHealth;

    //bool for attacking
    public bool attacking = false;
    public Vector3 target;

    //Abilities
    public Ability QAbility;
    public float QAbilityCooldown = 0;
    public Ability WAbility;
    public float WAbilityCooldown = 0;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        anim = GetComponent<Animator>();
        AbilityManager.S.init(classFiles);

        maxHealth = baseHealth;
        currentHealth = maxHealth;

        //All we need to get an ability is something like "Paladin-25"
        QAbility = AbilityManager.S.classAbilities["Guardian"][1];
        QAbility.enabled = true;
        QAbility.init();
        
        WAbility = AbilityManager.S.classAbilities["Guardian"][6];
        WAbility.enabled = true;
        WAbility.init();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && QAbilityCooldown <= Time.time)
        {
            QAbility.terminate();
            QAbility = AbilityManager.S.classAbilities["Guardian"][QAbility.id + 1];
            QAbility.enabled = true;
            QAbility.init();
            QAbilityCooldown = Time.time + QAbility.cooldown;
        }
        if (Input.GetKeyDown(KeyCode.W) && WAbilityCooldown <= Time.time)
        {
            anim.Play(WAbility.animationName);
            WAbilityCooldown = Time.time + WAbility.cooldown;
            attacking = true;
            target = (transform.forward * WAbility.range);
            target += transform.position;
        }

        if (attacking)
        {
            transform.position = Vector3.Lerp(transform.position, target, .075f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
