using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldProgressController : MonoBehaviour
{
    public DialogueHolder dh;

    public void updateWorld(int code)
    {
        switch (code)
        {
            case 1:
                dh.startNode = 5;
                break;
            default:
                break;
        }
    }
}
