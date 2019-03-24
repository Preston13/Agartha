using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStatus{ idle, moving, attacking, paralyzed, frozen, talking };

    static public PlayerStats S;

    public PlayerStatus status;

    [Header("Player Stats")]
    //displayed health on ui
    public float maxHealth = 100;
    //base health that the max health is calculated from
    public float baseHealth = 100;
    public float curHealth = 100;
    public float healthRegenRate; //no idea what to do here
    public float tenacity = 0;


    [Header("XP Setup")]
    public int level = 1;
    public int currentXP = 0;
    public float XPGainLifetime = 1;
    public Slider XPSlider;
    public Text XPText;
    public Text LevelText;
    public int XPToNextLevel;

    private float UIMoveTime;
    private bool XPMoving = false;


    public ThirdPersonCamera cam;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        S = this;

        status = PlayerStatus.idle;
        //anim = GetComponentInChildren<Animator>();

        calculateLevelXP(level);
        XPSlider.value = 0;
        XPText.text = "0 / " + XPToNextLevel;
        LevelText.text = "" + level;
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
                break;

            case PlayerStatus.talking:
                cam.enabled = false;
                break;
        }

        //XP BAR MOVING AND ANIMATIONS
        if(status != PlayerStatus.talking){
          if (Input.GetKeyDown(KeyCode.Space))
          {
              XPGained(5);
          }
        }

        float value = Mathf.Clamp01((float)currentXP / XPToNextLevel);

        if (XPSlider.value != value && !XPMoving)
        {
            UIMoveTime = Time.time;
            XPMoving = true;
        }

        if (XPMoving)
        {
            float u = (Time.time - UIMoveTime) / XPGainLifetime;
            if (u > .5)
            {
                XPSlider.value = value;
                XPMoving = false;
                if (value == 1)
                {
                    levelUp();
                }
            }
            else
            {
                XPSlider.value = (1 - u) * XPSlider.value + u * value;
            }
        }
    }

    //FUNCTION TO LEVEL UP PLAYER
    void levelUp()
    {
        int overflow = currentXP - XPToNextLevel;
        ++level;
        currentXP = overflow;
        calculateLevelXP(level);
        XPText.text = "" + Mathf.Clamp(currentXP, 0, XPToNextLevel) + " / " + XPToNextLevel;
        LevelText.text = "" + level;
        XPSlider.value = 0;
    }

    //FUNCTION TO GIVE XP TO PLAYER
    void XPGained(int xp)
    {
        currentXP += xp;
        UIMoveTime = Time.time;
        XPText.text = "" + Mathf.Clamp(currentXP, 0, XPToNextLevel) + " / " + XPToNextLevel;
    }

    //FUNCTION TO CALCULATE THE NEXT XP LEVEL UP REQUIREMENT
    void calculateLevelXP(int n)
    {
        XPToNextLevel = Mathf.RoundToInt(Mathf.Sqrt((Mathf.Pow(n, 3) * 8)) + 10);
    }
}
