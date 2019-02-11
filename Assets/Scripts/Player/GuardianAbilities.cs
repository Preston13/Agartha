using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbilities : MonoBehaviour
{
    private int VIGOR_ID = 0;
    private int RESURGENCE_ID = 1;
    private int TENACITY_ID = 2;

    public Dictionary<int, int> abilityList = new Dictionary<int, int>();

    public int vigorLevel;
    public int resLevel;
    public int tenacityLevel;
    public int abilityCount;

    private void Update()
    {
        vigorLevel = abilityList[VIGOR_ID];
        resLevel = abilityList[RESURGENCE_ID];
        tenacityLevel = abilityList[TENACITY_ID];
    }

    public void init()
    {
        Debug.Log("Ability Count: " + abilityCount);
        for(int i = 0; i < abilityCount; i++)
        {
            string s = "GuardianAbility" + i;
            abilityList[i] = 0;

            if (i == VIGOR_ID)
                setVigor(PlayerPrefs.GetInt(s, 0));
            else if (i == RESURGENCE_ID)
                setResurgence(PlayerPrefs.GetInt(s, 0));
            else if (i == TENACITY_ID)
                setTenacity(PlayerPrefs.GetInt(s, 0));

        }
    }

    public void setVigor(int level)
    {
        //undo previous level to not stack
        Player.S.maxHealth -= (int)(Player.S.baseHealth * (0.03 * abilityList[VIGOR_ID]));

        abilityList[VIGOR_ID] = level;
        Player.S.maxHealth += (int)(Player.S.baseHealth * (0.03 * level));
    }
    public void addVigorLevel()
    {
        setVigor(abilityList[VIGOR_ID] + 1);
    }

    public void setResurgence(int level)
    {
        //undo previous level to not stack
        Player.S.healthRegenRate -= 0.002 * abilityList[RESURGENCE_ID];

        abilityList[RESURGENCE_ID] = level;
        Player.S.healthRegenRate += 0.002 * level;
    }
    public void addResurgenceLevel()
    {
        setResurgence(abilityList[RESURGENCE_ID] + 1);
    }

    public void setTenacity(int level)
    {
        //undo previous level to not stack on top of each other
        Player.S.tenacity -= .05 * abilityList[TENACITY_ID];

        abilityList[TENACITY_ID] = level;
        Player.S.tenacity += .05*level;
    }
    public void addTenacityLevel()
    {
        setTenacity(abilityList[TENACITY_ID] + 1);
    }
}
