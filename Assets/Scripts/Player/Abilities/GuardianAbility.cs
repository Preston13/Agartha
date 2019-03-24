using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbility : Ability
{
    public bool moveForward;
    public bool jumpForward;

    public GuardianAbility(string[] data)
    {
        id = int.Parse(data[0]);
        name = data[1];
        cooldown = float.Parse(data[2]);
        range = int.Parse(data[3]);
        healing = int.Parse(data[4]);
        damage = int.Parse(data[5]);
        CCDuration = double.Parse(data[6]);
        animationName = data[7];
        passive1 = int.Parse(data[8]);
        passive2 = int.Parse(data[9]);
        passive3 = int.Parse(data[10]);
        moveForward = int.Parse(data[11]) == 1;
        jumpForward = int.Parse(data[12]) == 1;
        //get from player prefs?
        enabled = false;
        init();
    }

    public override void init()
    {
        if (enabled)
        {
            if (passive1 != 0)
            {
                PlayerStats.S.maxHealth += (int)(PlayerStats.S.baseHealth * (double)passive1 / 100);
                PlayerStats.S.curHealth += (int)(PlayerStats.S.baseHealth * (double)passive1 / 100);
            }
            if (passive2 != 0)
            {
                Debug.Log("I have passive 2!");
            }
            if (passive3 != 0)
            {
                PlayerStats.S.tenacity += passive3;
            }
        }
    }

    public override void trigger()
    {
        //Attack or perform whatever

        //if the ability is not a passive
        if (passive1 == 0 && passive2 == 0 && passive3 == 0)
        {
            //if we do damage then we are attacking
            if (damage > 0)
                PlayerAbilityController.S.attacking = true;
            //if we have an animation then play it
            if(animationName != "")
            {
                //PlayerAbilityController.S.playAnimation(Type.Guardian, animationName);
            }

            if (moveForward)
            {
                Vector3 target = (PlayerAbilityController.S.transform.forward * range) + PlayerAbilityController.S.transform.position;
                Debug.Log(target);
                PlayerAbilityController.S.target = target;
            }
            else if (jumpForward)
            {

            }
            else
            {

            }
        }
    }

    public override void terminate()
    {
        if (passive1 != 0)
        {
            PlayerStats.S.curHealth -= (int)(PlayerStats.S.baseHealth * (double)passive1 / 100);
            PlayerStats.S.maxHealth -= (int)(PlayerStats.S.baseHealth * (double)passive1 / 100);
        }
        if (passive2 != 0)
        {
            Debug.Log("Removing passive 2!");
        }
        if (passive3 != 0)
        {
            PlayerStats.S.tenacity -= passive3;
        }
        enabled = false;
    }
}
