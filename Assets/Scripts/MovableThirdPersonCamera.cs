using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    [Header("Set in Inspector")]
    public float cameraSens = 5f;
    public Transform lookAt;
    public float height = 3;
    public float distance = 10.0f;
    public Vector3 thingBuffer = new Vector3(10.0f, 10.0f, 10.0f);
    public float sensitivityX = 4.0f;
    public float sensitivityY = 2.0f;

    [Header("Set Dynamically")]
    public Transform camTransform;
    public float currentX = 0.0f;
    public float currentY = 25.0f;
    public Vector3 camPos;
    public bool showTheThing = false;
    public GameObject thingToShow;

    private Camera cam;







    // Use this for initialization
    void Awake()
    {
        camTransform = transform;
        cam = Camera.main;

        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


    }


    void LateUpdate()
    {


        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt);



        if (showTheThing)
        {
            camTransform.position = Vector3.Lerp(camTransform.position, thingToShow.transform.position + thingBuffer, 2.0f);

            ///showTheThing = false;
        }
    }
}
