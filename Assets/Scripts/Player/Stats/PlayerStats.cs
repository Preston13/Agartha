using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStatus{ idle, moving, attacking, paralyzed, frozen, talking };

    public PlayerStatus status = PlayerStatus.idle;

    public float maxHealth = 100f;
    public float curHealth = 100f;
    public int level;
    public ThirdPersonCamera cam;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case PlayerStatus.idle:
                cam.enabled = true;
                break;

            case PlayerStatus.moving:
                cam.enabled = true;
                
                Debug.Log(anim.gameObject.name);
                break;

            case PlayerStatus.talking:
                cam.enabled = false;
                break;
        }
    }
}
