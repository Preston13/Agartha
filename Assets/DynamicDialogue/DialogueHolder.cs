﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string name;
    public DialogueNode[] dialogue;
    public int startNode;

    public bool talkable;
    public bool talking;
    private GameObject lb;
    public DialogueController dc;

    private void Start()
    {
        startNode = 0;
        talkable = false;
        talking = false;
        lb = gameObject.transform.GetChild(0).gameObject;
        dc = FindObjectOfType<DialogueController>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            talkable = true;
            lb.SetActive(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            talkable = false;
            talking = false;
            lb.SetActive(false);
            dc.EndDialogue();
        }
    }

    public void TriggerDialogue()
    {
        dc.StartDialogue(name, dialogue, startNode);
    }

    public void Update()
    {
        if (talkable && Input.GetKeyDown(KeyCode.E))
        {
            if (!talking)
            {
                TriggerDialogue();
                talking = true;
            }
        }
    }
}
