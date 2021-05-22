using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackbtnFunctionOverride : MonoBehaviour
{
    public GameObject mainmenu, discover, blogs;

    public Canvas registrysingle, itemsingle;


    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && itemsingle.enabled)
            {
                itemsingle.enabled = false;
                return;
            }
            if (Input.GetKey(KeyCode.Escape) && registrysingle.enabled)
            {
                registrysingle.enabled = false;
                return;
            }
           
            if (Input.GetKey(KeyCode.Escape) && discover.activeSelf == true && !registrysingle.enabled && !itemsingle.enabled)
            {
                discover.SetActive(false);
                mainmenu.SetActive(true);
                return;
            }

            if (Input.GetKey(KeyCode.Escape) && mainmenu.activeSelf == true && !registrysingle.enabled && !itemsingle.enabled)
            {
                Application.Quit();
                return;
            }

            if (Input.GetKey(KeyCode.Escape) && blogs.activeSelf == true)
            {
                blogs.SetActive(false);
                mainmenu.SetActive(true);
                return;
            }
           
            
        }
    }
}
