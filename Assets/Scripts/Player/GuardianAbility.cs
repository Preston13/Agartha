﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbility : Ability
{
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
                Player.S.maxHealth += (int)(Player.S.baseHealth * (double)passive1 / 100);
                Player.S.currentHealth += (int)(Player.S.baseHealth * (double)passive1 / 100);
            }
            if (passive2 != 0)
            {
                Debug.Log("I have passive 2!");
            }
            if (passive3 != 0)
            {
                Debug.Log("I have passive 3!");
            }
        }
    }

    public override void terminate()
    {
        if (passive1 != 0)
        {
            Player.S.currentHealth -= (int)(Player.S.baseHealth * (double)passive1 / 100);
            Player.S.maxHealth -= (int)(Player.S.baseHealth * (double)passive1 / 100);
        }
        if (passive2 != 0)
        {
            Debug.Log("Removing passive 2!");
        }
        if (passive3 != 0)
        {
            Debug.Log("Removing passive 3!");
        }
        enabled = false;
    }
}