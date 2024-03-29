﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStatus{ idle, moving, attacking, paralyzed, frozen, talking };

    public PlayerStatus status = PlayerStatus.idle;

    public float maxHealth = 100f;
    public float curHealth = 100f;
    public int level;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case PlayerStatus.idle:
                Debug.Log("Player is idle.");
                break;

            case PlayerStatus.moving:
                Debug.Log("Player is moving");
                break;

            case PlayerStatus.talking:
                Debug.Log("Player is talking");
                break;
        }
    }
}
