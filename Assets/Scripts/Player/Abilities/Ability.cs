using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Guardian,
    Fighter,
    Mystic
}
public abstract class Ability
{ 
    public int id;
    public string name;
    public Type type;
    public float cooldown;
    public int range;
    public int healing;
    public int damage;
    public double CCDuration;
    public string animationName;
    public int passive1;
    public int passive2;
    public int passive3;

    public bool enabled;
    public float timeStart = 0;

    public abstract void init();
    public abstract void terminate();
    public abstract void trigger();
}
