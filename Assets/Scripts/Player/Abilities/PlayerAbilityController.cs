using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour
{
    static public PlayerAbilityController S;

    public TextAsset[] classFiles;

    //bool for attacking
    public bool attacking = false;
    public Vector3 target;

    //Abilities
    public Ability Ability1;
    public float Ability1Cooldown = 0;
    public Ability Ability2;
    public float Ability2Cooldown = 0;

    public Animator GuardianAnimator;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        GuardianAnimator = GetComponent<Animator>();
        AbilityManager.S.init(classFiles);

        //All we need to get an ability is something like "Paladin-25"
        Ability1 = AbilityManager.S.classAbilities["Guardian"][6];
        Ability1.enabled = true;
        Ability1.init();

        Ability2 = AbilityManager.S.classAbilities["Guardian"][16];
        Ability2.enabled = true;
        Ability2.init();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Ability1Cooldown <= Time.time)
        {
            Ability1.terminate();
            Ability1 = AbilityManager.S.classAbilities["Guardian"][Ability1.id + 1];
            Ability1.enabled = true;
            Ability1.init();
            Ability1Cooldown = Time.time + Ability1.cooldown;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Ability2Cooldown <= Time.time)
        {
            //lines to run ability
            Ability2.trigger();
            Ability2Cooldown = Time.time + Ability2.cooldown;
        }

        if (attacking)
        {
            transform.position = Vector3.Lerp(transform.position, target, .1f);
            if(Mathf.Abs(target.x-transform.position.x) < 0.1 && Mathf.Abs(target.z-transform.position.z) < .1)
            {
                attacking = false;
            }
        }
    }

    public void playAnimation(Type type, string animName)
    {
        switch (type)
        {
            case Type.Guardian:
                GuardianAnimator.Play(animName);
                break;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
