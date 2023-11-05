using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject lookAtObject;
    private string text;
    private bool objectEnabled = false;
    private TextMesh textMesh;

    public void setLookAt(GameObject lookAt)
    {
        this.lookAtObject = lookAt;
        objectEnabled = true;
    }

    public void setText(string text)
    {
        this.text = text;
    }
    void Start()
    {
        textMesh = this.transform.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectEnabled)
        {
            //Calculating the highest point of the object so that the text stays above the object
            float highestPoint = this.transform.parent.position.y + (this.transform.parent.localScale.y);
            Vector3 textBoxPos = new Vector3(this.transform.parent.position.x, highestPoint, this.transform.parent.position.z);

            //Changing the rotation so the text always faces the player
            //Somehow this makes the text appear mirrored
            //That is why the X scale of the text is set to -1.
            textMesh.transform.LookAt(lookAtObject.transform.position);
            textMesh.transform.position = textBoxPos;
            textMesh.transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f); //Unmirror text
            textMesh.text = this.text;
        }        
    }
}
