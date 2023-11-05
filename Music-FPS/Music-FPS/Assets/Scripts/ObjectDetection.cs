using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Field size")]
    public int x;
    public int y;
    public int z;

    [Header("Other")]
    public GameObject textBoxObject;
    public GameObject playerOrientation;
    public Camera mainCamera;

    void Start()
    {
        //Setting the scale of the interaction field
        Vector3 newScale = new Vector3(x, y, z);
        this.transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("item")) // Checking if the object that entered the trigger field has the "item" tag
        {
            //Instantiate textbox holder and attach a TextBoxController to it
            GameObject textBox = (GameObject)Instantiate(textBoxObject, other.gameObject.transform.position, Quaternion.identity);
            textBox.transform.SetParent(other.gameObject.transform);

            TextBoxController tbc = textBox.AddComponent<TextBoxController>();
            tbc.setText("Hello world");
            tbc.setLookAt(mainCamera.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("item"))
        {
            //Destroying the textbox holder
            GameObject textBox = other.transform.GetChild(0).gameObject;
            Destroy(textBox);
        }
    }
}
