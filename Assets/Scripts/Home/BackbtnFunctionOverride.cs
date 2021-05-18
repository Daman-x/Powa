using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackbtnFunctionOverride : MonoBehaviour
{
    public GameObject mainmenu, discover;


    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && discover.activeSelf == true)
            {
                discover.SetActive(false);
                mainmenu.SetActive(true);
                return;
            }

            if (Input.GetKey(KeyCode.Escape) && mainmenu.activeSelf == true)
            {
                Application.Quit();
                return;
            }



        }
    }
}