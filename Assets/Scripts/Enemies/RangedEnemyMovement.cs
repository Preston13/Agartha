using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float minDistance;
    public GameObject player;

    private float angleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeAngle", 0, Random.Range(2, 5));
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player is close enough to target
        if(Vector3.Distance(player.transform.position, this.transform.position) < minDistance)
        {
            transform.RotateAround( player.transform.position, player.transform.up,angleSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(player.transform.position, this.transform.position) < 10)
        {
            transform.RotateAround(player.transform.position, player.transform.up, angleSpeed * 3 * Time.deltaTime);
        }
    }

    void ChangeAngle()
    {
        angleSpeed = Random.Range(-moveSpeed, moveSpeed);
        if(angleSpeed < 7f && angleSpeed > -7f)
        {
            angleSpeed = Random.Range(-moveSpeed, moveSpeed);
        }
    }
}
