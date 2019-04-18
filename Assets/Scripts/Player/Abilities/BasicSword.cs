using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == PlayerAbilityController.S.Ability1.animationName)
        //    Debug.Log("Do " + PlayerAbilityController.S.Ability1.damage + " damage.");
        //else if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == PlayerAbilityController.S.Ability2.animationName)
        //{
        //    Debug.Log("Do " + PlayerAbilityController.S.Ability2.damage + " damage.");
        //}
    }
}
