using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float moveSpeed;
    public float jumpSpeed;
    public float rotateSpeed;
    public float gravity = 20.0f;

    private Vector3 movement = Vector3.zero;
    private Camera cam;
    private CharacterController controller;
    private PlayerStats stats;
    public Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();
        anim.speed = .75f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (controller.isGrounded)
        {

            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            movement = transform.TransformDirection(movement);
            movement *= moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= 1.5f;
            }
            

            if (controller.velocity.magnitude > 0)
            {
                stats.status = PlayerStats.PlayerStatus.moving;
            }
            else
            {
                stats.status = PlayerStats.PlayerStatus.idle;
            }
        }

        movement.y -= (gravity * Time.deltaTime);

        controller.Move(movement * Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
           // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotateSpeed * Time.deltaTime);
        }

        //Needs Fix
        //anim.SetFloat("Turn", Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 0.1f, Time.deltaTime);

        anim.SetFloat("Forward", Input.GetAxis("Vertical"), 0.1f, Time.deltaTime);
        anim.gameObject.transform.localPosition = new Vector3(0f, -1.05f, 0f);



        //Testing moving something
        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.SimpleMove(transform.forward * 300);
        }
         
       
    }
}
