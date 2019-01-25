using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [Header("Set")]
    public int level = 1;
    public int currentXP = 0;
    public float XPGainLifetime;
    public Slider XPSlider;
    public Text XPText;
    public Text LevelText;

    //Dynamic
    [Header("Dynamic")]
    public int XPToNextLevel;

    private float UIMoveTime;
    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        calculateLevelXP(level);
        XPSlider.value = 0;
        XPText.text = "0 / " + XPToNextLevel;
        LevelText.text = "" + level;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            XPGained(50);
        }

        float value = Mathf.Clamp01((float)currentXP / XPToNextLevel);

        if (XPSlider.value != value && !moving)
        {
            UIMoveTime = Time.time;
            moving = true;
        }

        if (moving)
        {
            float u = (Time.time - UIMoveTime) / XPGainLifetime;
            if (u > .5)
            {
                XPSlider.value = value;
                moving = false;
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

    void calculateLevelXP(int n)
    {
        XPToNextLevel = Mathf.RoundToInt(Mathf.Sqrt((Mathf.Pow(n, 3) * 8)) + 10);
    }

    void XPGained(int xp)
    {
        currentXP += xp;
        UIMoveTime = Time.time;
        XPText.text = "" + Mathf.Clamp(currentXP, 0, XPToNextLevel) + " / " + XPToNextLevel;
    }
}
