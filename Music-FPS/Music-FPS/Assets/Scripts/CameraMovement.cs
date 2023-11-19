using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Sensitivity
    public float xSens;
    public float ySens;

    //Controlle Sensitivity
    public float controllerXSens;
    public float controllerYSens;

    //Rotation of Camera
    float xRot;
    float yRot;

    public Transform orientation;
    public GameObject buttonCrossHair;
    public PlayerMovement player;

    PlayerControls controls;
    Vector2 yInputController;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Gameplay.Enable();
        buttonCrossHair.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
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
        //Vector2 r = new Vector2(yInputController.x * controllerXSens, yInputController.y * controllerYSens);
        //r.y = Mathf.Clamp(r.y, -70f, 70f);
        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Rotate both Camera and Player
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

    }

    private void FixedUpdate()
    {
        //Controller Look Around
        //controls.Gameplay.Look.performed += ctx => yInputController += ctx.ReadValue<Vector2>();
        yInputController += controls.Gameplay.Look.ReadValue<Vector2>();
        //controls.Gameplay.Look.canceled += ctx => yInputController = Vector2.zero;
    }
}
