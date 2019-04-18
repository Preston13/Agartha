using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    [TextArea(3, 10)]
    public string text;
    public Option[] options;
    public int worldProgressNum = -1;
}
