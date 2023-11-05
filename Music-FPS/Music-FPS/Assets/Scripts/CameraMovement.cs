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
    public GameObject buttonCrossHair;

    // Start is called before the first frame update
    void Start()
    {
        buttonCrossHair.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Lock cursor unless holding LeftAlt
        if (Input.GetKeyDown(KeyCode.LeftAlt)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
