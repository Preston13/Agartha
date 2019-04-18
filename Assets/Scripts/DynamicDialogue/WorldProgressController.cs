using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldProgressController : MonoBehaviour
{
    public DialogueHolder dh;
    public int enemiesKilled = -999;
    public Animator animator;
    public Text enemiesSlain;

    public void updateWorld(int code)
    {
        switch (code)
        {
            case 1:
                dh.startNode = 5;
                break;
            case 2:
                enemiesKilled = 0;
                StartQuest();
                break;
            default:
                break;
        }
    }

    private void Update()
    {

    }

    private void StartQuest()
    {
        animator.SetBool("IsOpen", true);
        enemiesKilled = 0;
        enemiesSlain.text = 0.ToString();
    }

    public void EnemySlain()
    {
        enemiesKilled++;
        enemiesSlain.text = enemiesKilled.ToString();
    }

    public void QuestCompleted()
    {
        animator.SetBool("IsOpen", false);
    }
}