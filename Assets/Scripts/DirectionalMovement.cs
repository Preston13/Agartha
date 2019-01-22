using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float moveSpeed;
    public float jumpSpeed;
    public float rotateSpeed;

    private Rigidbody rigid;
    private Vector3 movement;
    private Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        //forward.Normalize();
        //right.Normalize();

        Vector3 movement = (forward * inputZ + right * inputX) * Time.deltaTime * moveSpeed;
        
        /*if(Input.GetAxis("Vertical") == 1)
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }
        else if(Input.GetAxis("Vertical") == -1)
        {
            transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;
        }*/
        
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= 2;
        }
        if (movement.magnitude > 1f) movement.Normalize();

        transform.position += movement;

        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotateSpeed * Time.deltaTime);
        }
        

        //rigid.MovePosition(transform.position + movement);
    }
}
