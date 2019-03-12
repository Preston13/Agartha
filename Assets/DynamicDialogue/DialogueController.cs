using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    DialogueNode[] dialogue;

    public Text nameText;
    public Text dialogueText;

    public Text option1Text;
    public Text option2Text;
    public Text option3Text;
    public Text option4Text;

    private Text[] optionTexts;
    public int curNode;

    public Animator animator;

    public WorldProgressController wpc;

    public PlayerStats playerStats;

    void Start()
    {
        dialogue = new DialogueNode[0];
        optionTexts = new Text[4];
        optionTexts[0] = option1Text;
        optionTexts[1] = option2Text;
        optionTexts[2] = option3Text;
        optionTexts[3] = option4Text;
        curNode = 0;

        foreach (Text text in optionTexts)
            text.text = "";

        wpc = FindObjectOfType<WorldProgressController>();
    }

    public void StartDialogue(string name, DialogueNode[] inDialogue, int startNode)
    {
        dialogue = inDialogue;
        animator.SetBool("IsOpen", true);
        nameText.text = name;
        DisplayNode(startNode);
        curNode = startNode;
    }

    public void DisplayNode(int nodeInt)
    {
        curNode = nodeInt;

        if (nodeInt >= dialogue.Length)
        {
            EndDialogue();
            return;
        }

        foreach (Text text in optionTexts)
            text.text = "";

        DialogueNode dNode = dialogue[nodeInt];
        StopAllCoroutines();
        StartCoroutine(TypeNode(dNode));

        if (dNode.worldProgressNum != -1)
        {
            wpc.updateWorld(dNode.worldProgressNum);
        }
    }

    IEnumerator TypeNode(DialogueNode dNode)
    {
        dialogueText.text = "";
        foreach (char letter in dNode.text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        int counter = 0;
        foreach (Text text in optionTexts)
        {
            if(dNode.options.Length > counter)
                text.text = dNode.options[counter].text;

            counter++;
        }
    }

    public void Opt1()
    {
        DisplayNode(dialogue[curNode].options[0].pointer);
    }
    public void Opt2()
    {
        DisplayNode(dialogue[curNode].options[1].pointer);
    }
    public void Opt3()
    {
        DisplayNode(dialogue[curNode].options[2].pointer);
    }
    public void Opt4()
    {
        DisplayNode(dialogue[curNode].options[3].pointer);
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    private void Update()
    {
        if (animator.GetBool("IsOpen"))
        {
            playerStats.status = PlayerStats.PlayerStatus.talking;
        }
    }
}
