using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f, Y_ANGLE_MAX = 50.0f;

    [Header("Set in Inspector")]
    public GameObject player;
    public float distanceFromPlayer;
    public float height;
    public float lookAngle;
    public float cameraSensitivity;
    public float turnSpeed;
    public float heightDamping;
    public float rotationDamping;
    public float lastCamx;
    public Transform lastPos;


    private Rigidbody playerRigidbody;
    public float currentX;
    private float currentY = 25f;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;

        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerRigidbody.IsSleeping())
        {
            currentX += Input.GetAxis("Mouse X") * cameraSensitivity;
            currentY += Input.GetAxis("Mouse Y") * cameraSensitivity;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
        else
        {
            //currentX = player.transform.position.x;
            //currentY = 22;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        
        //if player isn't moving, be able to move the camera around
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            Vector3 dir = new Vector3(0, 0, -distanceFromPlayer);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            //transform.position = player.transform.position + rotation * dir;
            transform.position = player.transform.position;
            transform.position += rotation * dir;
            transform.LookAt(player.transform);
        }
        else
        {

            // Calculate the current rotation angles
            float wantedRotationAngle = player.transform.eulerAngles.y;
            float wantedHeight = player.transform.position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = player.transform.position;
            transform.position -= currentRotation * Vector3.forward * distanceFromPlayer;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(player.transform);

            lastCamx = this.transform.rotation.y;

            lastPos = player.transform;
        }
        

        
    }
}
