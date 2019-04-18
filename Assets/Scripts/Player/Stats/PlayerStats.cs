using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    static public PlayerStats S;

    public enum PlayerStatus{ idle, moving, attacking, paralyzed, frozen, talking };

    public PlayerStatus status;

    [Header("Player Stats")]
    public float maxHealth = 100f;
    public float curHealth = 100f;

    private Color matColor;
    private SkinnedMeshRenderer body;


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
    public Animator swordAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        status = PlayerStatus.idle;
        calculateLevelXP(level);
        XPSlider.value = 0;
        XPText.text = "0 / " + XPToNextLevel;
        LevelText.text = "" + level;
        body = FindObjectOfType<SkinnedMeshRenderer>();
        matColor = body.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case PlayerStatus.idle:
                swordAnim.enabled = true;
                break;

            case PlayerStatus.moving:
                swordAnim.enabled = true;
                break;

            case PlayerStatus.talking:
                swordAnim.enabled = false;
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

        //For testing death
        if(curHealth <= 0)
        {
            Debug.Log("Ded");
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

    //Function for taking damage (name subject to change to takeDamage)
    public void getRekt(float damage)
    {
        curHealth -= damage;
        body.material.color = new Color(1f, 0f, 0f);
        Invoke("NormalColorChange", .5f);

    }

    void NormalColorChange()
    {
        body.material.color = matColor;
    }
}
