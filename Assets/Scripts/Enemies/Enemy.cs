using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float stopDistance = 10f;
    public float minDistance = 30f;
    public float moveSpeed = 5f;
    GameObject player;

    public bool playerInRange;
    private float timer;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float endX;
    private float endZ;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        //InvokeRepeating("findEndPosition", 0, 5);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        timer += Time.deltaTime;

        //if player is close enough, move toward them
        if (Vector3.Distance(player.transform.position, this.transform.position) < minDistance && !playerInRange)
        {
            this.transform.LookAt(player.transform);
            Move();
            this.transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }
        else if(playerInRange)
        {
            //Attack or something
        }

        
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }




    /*void findEndPosition()
    {
        startPosition = this.transform.position;
        endX = Random.Range(startPosition.x - 30f, startPosition.x + 30f);
        endZ = Random.Range(startPosition.z - 30f, startPosition.z + 30f);
        endPosition = new Vector3(endX, startPosition.y, endZ);
        Debug.Log(endPosition);
        transform.position = Vector3.Lerp(startPosition, endPosition, 0.1f);
    } */
}
