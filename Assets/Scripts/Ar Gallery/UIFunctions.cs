using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// THIS SCRIPT HAVE ALL THE UI FUNCTIONS ON THE SCENE
public class UIFunctions : MonoBehaviour
{

    [SerializeField]
    Text txt;         // toast txt
    [SerializeField]
    GameObject PlaceBtn; // invisble btn on screen to place object


    private ObjectPlacement objectPlacement; // objectplacement class reference
    private GameObject Canvas;
    public GameObject Options;
    private GameObject UIOptions;

    private bool Isclose = true; // options panel open or not

    private void Start() // run as scene starts once only
    {
        Canvas = GameObject.Find("Canvas");
        UIOptions = Canvas.transform.Find("UIOptions").gameObject;
        objectPlacement = GameObject.Find("AR Session Origin").GetComponent<ObjectPlacement>(); // gather all components
        PlaceBtn.SetActive(true);
    }

    #region side panel functions

    public void OnOptionsClicked() // when small icon on side of the screen is  -- open the panels of other options ike remove etc.
    {
       
        if(Isclose)
        {
          
            UIOptions.SetActive(true);
            Options.transform.position = new Vector3(Options.transform.position.x + 310f, Options.transform.position.y, 0f);
            Isclose = false;
        }
        else
        {
            UIOptions.SetActive(false);
            Options.transform.position = new Vector3(Options.transform.position.x - 310f, Options.transform.position.y, 0f);
            Isclose = true;
        }
       
    }


    public void OnClickPlaceButton() // when touch on the screen to place the object
    {
        if (objectPlacement.placed == false)
        {
            objectPlacement.placed = true;
            objectPlacement.ActivePlanes(false);
            PlaceBtn.SetActive(false);
            objectPlacement.enabled = false;
        }
    }

    public void OnRemove() // when reomve button is clicked removes object on scene
    {
        if (objectPlacement.remove && objectPlacement.placed == true)
        {
            Destroy(objectPlacement.prefabs);
            objectPlacement.ActivePlanes(false);
            objectPlacement.remove = false;
            objectPlacement.placed = false;
        }
        else if (!objectPlacement.remove) // if clicked again
        {
            objectPlacement.ActivePlanes(true);
            objectPlacement.remove = true;
            PlaceBtn.SetActive(true);
            objectPlacement.enabled = true;
        }

    }

    public void TakeScreenShot() // when screenshot button is clicked
    {
        float rw = (float)1920 / Screen.width;
        float rh = (float)1080 / Screen.height;
        ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpeg");
        showToast(string.Format(" SS Saved {0}", Application.persistentDataPath), 2);

    }



    void showToast(string text,int duration) // show toast at bottom of the scene currently not visible
    {
        StartCoroutine(showToastCOR(text, duration)); // call showtoastcor corotine
    }

    private IEnumerator showToastCOR(string text,int duration) // show the text and fade after the given duration
    {
        Color orginalColor = new Color(225, 225, 225);
        txt.color = orginalColor;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);

        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration) // used in above function used for fade in fade out
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }

    #endregion

}
