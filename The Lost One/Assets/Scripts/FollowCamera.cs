using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;
    public float sensitivity;
    private Vector3 rotationX;
    private Vector3 zoom;
    private Vector3 positionFree;
    private bool freeCam;
    // Start is called before the first frame update
    void Start()
    {
        rotationX = new Vector3(5, 10, 0);
        freeCam = false;
    }

    // Camera movement and lock based on the input
    void Update()
    {
        bool changed = false;
        if (Input.mouseScrollDelta.y != 0)
        {
            if (transform.position.y > 8 && transform.position.y < 40)
            {
                zoom += new Vector3(0, Input.mouseScrollDelta.y * (-1), 0);
            }
            else if (transform.position.y < 8 && Input.mouseScrollDelta.y < 0)
            {
                zoom += new Vector3(0, Input.mouseScrollDelta.y * (-1), 0);
            }
            else if (transform.position.y > 40 && Input.mouseScrollDelta.y > 0)
            {
                zoom += new Vector3(0, Input.mouseScrollDelta.y * (-1), 0);
            }
        }
        if (Input.GetMouseButton(2))
        {
            rotationX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up) * rotationX;
        }
        if (Input.GetKeyDown("z"))
        {
            freeCam = false;
        }
        if (Input.GetKey("w"))
        {
            if(!freeCam)
            {
                positionFree = new Vector3(0, 0, 0);
                changed = true;
            }
            freeCam = true;
            positionFree += new Vector3(-0.3f, 0, 0);
        }
        else if (Input.GetKey("s"))
        {
            if (!freeCam)
            {
                positionFree = new Vector3(0, 0, 0);
                changed = true;
            }
            freeCam = true;
            positionFree += new Vector3(0.3f, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            if (!freeCam)
            {
                positionFree = new Vector3(0, 0, 0);
                changed = true;
            }
            freeCam = true;
            positionFree += new Vector3(0, 0, -0.3f);
        }
        else if (Input.GetKey("d"))
        {
            if (!freeCam)
            {
                positionFree = new Vector3(0, 0, 0);
                changed = true;
            }
            freeCam = true;
            positionFree += new Vector3(0, 0, 0.3f);
        }
        if (changed)
        {
            positionFree += target.position;
        }

    }


    //Updates camera position differently dementing whether the camera is following user or not
    void LateUpdate()
    {
        if (freeCam)
        {
            Vector3 wantedPosition = rotationX + zoom + positionFree;
            transform.position = wantedPosition;
        }
        else
        {
            Vector3 wantedPosition = target.position + rotationX + zoom;
            transform.position = wantedPosition;
            transform.LookAt(target);
        }
    }
}
