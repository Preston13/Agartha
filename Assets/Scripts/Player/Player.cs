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

    //Abilities
    public Ability QAbility;
    public Ability WAbility;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QAbility.enabled = false;
            QAbility.terminate();
            QAbility = AbilityManager.S.classAbilities["Guardian"][QAbility.id + 1];
            QAbility.enabled = true;
            QAbility.init();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play(WAbility.animationName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
