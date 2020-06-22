using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerCam;
    private float mouseX, mouseY;

    public float mouseSensitivity = 4f;

    // The current distance of the zoom
    private float zoom;

    // The minimum and maximum distance at which the user can zoom in and out
    public float zoomMin = -10f;
    public float zoomMax = -40f;

    // The distance at which the zoom starts
    public float zoomStart = -15f;

    // The speed at which the zoom scrolls
    public float zoomSpeed = 2;


    // Start is called before the first frame update
    void Start()
    {
        zoom = zoomStart;
    }


    // Update is called once per frame
    void Update()
    {
        cameraZoom();
        cameraRotation();
        cameraPanning();
    }


    // Used to zoom in and out of the scene
    void cameraZoom()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
        {
            zoom = zoomMin;
        }

        if (zoom < zoomMax)
        {
            zoom = zoomMax;
        }

        playerCam.localPosition = new Vector3(0, zoom, 0);
    }


    // Used to rotate the camera around the scene
    void cameraRotation()
    {
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        }

        mouseY = Mathf.Clamp(mouseY, -60f, 60f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }


    private void cameraPanning()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Translate(new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")), Space.Self);
        }
    }
}
