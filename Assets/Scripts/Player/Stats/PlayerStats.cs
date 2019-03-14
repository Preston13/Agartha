using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStatus{ idle, moving, attacking, paralyzed, frozen, talking };

    public PlayerStatus status;

    public float maxHealth = 100f;
    public float curHealth = 100f;
    public int level;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        status = PlayerStatus.idle; 
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case PlayerStatus.idle:
                break;

            case PlayerStatus.moving:
                
                Debug.Log(anim.gameObject.name);
                break;

            case PlayerStatus.talking:
                break;
        }
    }
}
