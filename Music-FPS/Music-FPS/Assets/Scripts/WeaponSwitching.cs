using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1 || Input.GetKeyDown(KeyCode.Keypad1) && transform.childCount >= 1)
        {
            selectedWeapon = 0;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 || Input.GetKeyDown(KeyCode.Keypad2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 || Input.GetKeyDown(KeyCode.Keypad3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 || Input.GetKeyDown(KeyCode.Keypad4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5 || Input.GetKeyDown(KeyCode.Keypad5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        //Loop through each child of weapon switching
        foreach(Transform weapon in transform)
        {
            //If you're on selected weapon
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
