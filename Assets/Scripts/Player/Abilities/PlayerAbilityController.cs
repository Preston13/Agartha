using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour
{
    static public PlayerAbilityController S;

    public TextAsset[] classFiles;

    //bool for attacking
    public bool attacking = false;
    public bool blocking = false;

    //Abilities
    public Ability Ability1;
    public float Ability1Cooldown = 0;
    public Ability Ability2;
    public float Ability2Cooldown = 0;

    public float blockLifeStart;
    public float blockLifeTime;

    private Animator anim;

    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        anim = GetComponent<Animator>();
        AbilityManager.S.init(classFiles);

        //All we need to get an ability is something like "Paladin-25"
        Ability1 = AbilityManager.S.classAbilities["Guardian"][16];
        Ability1.enabled = true;
        Ability1.init();

        Ability2 = AbilityManager.S.classAbilities["Guardian"][21];
        Ability2.enabled = true;
        Ability2.init();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Ability1Cooldown <= Time.time)
        {
            //increment passive ability
            //Ability1.terminate();
            //Ability1 = AbilityManager.S.classAbilities["Guardian"][Ability1.id + 1];
            //Ability1.enabled = true;
            //Ability1.init();
            //Ability1Cooldown = Time.time + Ability1.cooldown;

            //run ability attack
            Ability1.trigger();
            Ability1Cooldown = Time.time + blockLifeTime + Ability1.cooldown;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Ability2Cooldown <= Time.time)
        {
            //lines to run ability
            Ability2.trigger();
            Ability2Cooldown = Time.time + blockLifeTime + Ability2.cooldown;
        }

        if(blocking)
        {
            if(Time.time >= blockLifeStart + blockLifeTime)
            {
                PlayerStats.S.status = PlayerStats.PlayerStatus.idle;
                blockLifeStart = 0;
                blocking = false;
            }
        }
    }

    public void MoveForward(float range){
        initialPos = this.transform.position;
        Debug.Log("range: " + range);
        StartCoroutine(ApplyForce(range));
    }

    IEnumerator ApplyForce(float range){
        Vector3 target = transform.position + (transform.forward * range * 1.5f);
        var dx = target.x - transform.position.x;
        var dz = target.z - transform.position.z;
        while(Mathf.Abs(dx) > .1f && Mathf.Abs(dz) > .1f){
            if(Vector3.Distance(initialPos, transform.position) > range)
            {
                yield break;
            }
            transform.position += transform.forward / 2;
            dx = target.x - transform.position.x;
            dz = target.z - transform.position.z;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
       
    }

    public void playAnimation(string animName)
    {
        anim.Play(animName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyWeapon"){
            if (blocking)
            {
                Debug.Log("blocking hit");
            }
            else
            {
                Debug.Log("Hit");
            }
        }
    }
}
