using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public bool talkable;
    public GameObject lb;

    private void Start()
    {
        talkable = false;
        lb = gameObject.transform.GetChild(0).gameObject;
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
            lb.SetActive(false);
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }

    public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}


    public void Update()
    {
        if(talkable && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }
}
