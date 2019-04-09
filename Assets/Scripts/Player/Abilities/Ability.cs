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
    public float range;
    public float healing;
    public float damage;
    public float CCDuration;
    public string animationName;
    public float passive1;
    public float passive2;
    public float passive3;

    public bool enabled;
    public float timeStart = 0;

    public abstract void init();
    public abstract void terminate();
    public abstract void trigger();
}
