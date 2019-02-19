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
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == Player.S.QAbility.animationName)
            Debug.Log("Do " + Player.S.QAbility.damage + " damage.");
        else if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == Player.S.WAbility.animationName)
            Debug.Log("Do " + Player.S.WAbility.damage + " damage.");
    }
}
