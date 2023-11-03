using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Sensitivity
    public float xSens;
    public float ySens;

    //Rotation of Camera
    float xRot;
    float yRot;

    public Transform orientation;

    [Header("ADS")]
    public Camera cam;
    public float fov;
    public GameObject buttonCrossHair;

    // Start is called before the first frame update
    void Start()
    {
        cam.fieldOfView = fov;
        buttonCrossHair.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Lock cursor unless holding LeftAlt
        if (Input.GetKeyDown(KeyCode.LeftAlt)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = fov * 0.75f;
            buttonCrossHair.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = fov;
            buttonCrossHair.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        }

        //Get Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;
        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Rotate both Camera and Player
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
