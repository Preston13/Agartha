using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public bool talkable;
    public bool talking;
    public DialogueManager dm;
    public GameObject lb;

    public int sCount;

    private void Start()
    {
        talkable = false;
        talking = false;
        lb = gameObject.transform.GetChild(0).gameObject;
        sCount = 0;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            talkable = true;
            lb.SetActive(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            talkable = false;
            talking = false;
            lb.SetActive(false);
            dm.EndDialogue();
        }
    }

    public void TriggerDialogue ()
	{
		dm.StartDialogue(dialogue);
	}


    public void Update()
    {
        if(talkable && Input.GetKeyDown(KeyCode.E))
        {
            if(!talking)
            {
                sCount = 0;
                TriggerDialogue();
                talking = true;
            }
            else
            {
                dm.DisplayNextSentence();
                sCount++;
                if(sCount >= dialogue.sentences.Length)
                {
                    dm.EndDialogue();
                    talking = false;
                }
            }
            
        }
    }
}
