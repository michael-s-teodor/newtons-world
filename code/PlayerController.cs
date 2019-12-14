using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class PlayerController : MonoBehaviour
{
    public float mSpeed = 10f;
    public float rSpeed = 2f;
    private float yaw = 0f;
    private float pitch = 0f;
    public Transform cameraT;
    private Vector3 mDirection=Vector3.zero;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Height") !=0)
        {
            mDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Height"), Input.GetAxisRaw("Vertical"));
            mDirection = cameraT.TransformDirection(mDirection) * mSpeed * Time.deltaTime;
            transform.position += mDirection;
        }
        if (Input.GetKey("mouse 1"))
        {
            yaw += rSpeed * Input.GetAxis("Mouse X");
            pitch -= rSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
