using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{

    private GameObject Canvas;
    public GameObject Options;
    private GameObject UIOptions;

    private bool Isclose = true;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        UIOptions = Canvas.transform.Find("UIOptions").gameObject;
    }

    #region side panel functions

    public void OnOptionsClicked()
    {
        Debug.Log("she");
        if(Isclose)
        {
            Debug.Log("her");
            UIOptions.SetActive(true);
          //  UIOptions.transform.position = new Vector3(-209f, UIOptions.transform.position.y, 0f);
            Options.transform.position = new Vector3(Options.transform.position.x + 290f, Options.transform.position.y, 0f);
            Isclose = false;
        }
        else
        {
            Debug.Log("he");
            UIOptions.SetActive(false);
           // UIOptions.transform.position = new Vector3(-209f, UIOptions.transform.position.y, 0f);
            Options.transform.position = new Vector3(Options.transform.position.x - 290f, Options.transform.position.y, 0f);
            Isclose = true;
        }
       
    }

    #endregion

    // todo  add other ui functions from another script

}
