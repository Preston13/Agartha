using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbility : Ability
{
    public bool moveForward;
    public bool jumpForward;
    public float blocking;

    public GuardianAbility(string[] data)
    {
        id = int.Parse(data[0]);
        name = data[1];
        cooldown = float.Parse(data[2]);
        range = float.Parse(data[3]);
        healing = float.Parse(data[4]);
        damage = float.Parse(data[5]);
        CCDuration = float.Parse(data[6]);
        animationName = data[7];
        passive1 = float.Parse(data[8]);
        passive2 = float.Parse(data[9]);
        passive3 = float.Parse(data[10]);
        moveForward = int.Parse(data[11]) == 1;
        jumpForward = int.Parse(data[12]) == 1;
        blocking = float.Parse(data[13]); //holds seconds to block
 
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
                PlayerStats.S.maxHealth += (int)(PlayerStats.S.baseHealth * passive1 / 100);
                PlayerStats.S.curHealth += (int)(PlayerStats.S.baseHealth * passive1 / 100);
            }
            if (passive2 != 0)
            {
                PlayerStats.S.healthRegenRate += passive2;
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
                PlayerAbilityController.S.playAnimation(animationName);
            }

            if (moveForward)
            {

                //Vector3 target = (PlayerAbilityController.S.transform.forward * range) + PlayerAbilityController.S.transform.position;
                PlayerAbilityController.S.MoveForward(range);
            }
            else if (jumpForward)
            {

            }
            else if (blocking != 0)
            {
                PlayerAbilityController.S.blocking = true;
                PlayerAbilityController.S.blockLifeStart = Time.time;
                PlayerAbilityController.S.blockLifeTime = blocking;
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
            PlayerStats.S.healthRegenRate -= passive2;
        }
        if (passive3 != 0)
        {
            PlayerStats.S.tenacity -= passive3;
        }
        enabled = false;
    }
}
