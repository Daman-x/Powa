using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;


// THIS SCRIPT HAVE ALL THE UI FUNCTIONS ON THE SCENE
public class UIFunctions : MonoBehaviour
{

    [SerializeField]
    Text txt;         // toast txt
    [SerializeField]
    GameObject PlaceBtn, remove; // invisble btn on screen to place object

    private Animation anim;
    private ObjectPlacement objectPlacement; // objectplacement class reference
 

    private void Start() // run as scene starts once only
    {
        objectPlacement = GameObject.Find("AR Session Origin").GetComponent<ObjectPlacement>(); // gather all components
        anim = GetComponent<Animation>();
        PlaceBtn.SetActive(true);
    }

    #region side panel functions

  

    public void OnClickPlaceButton() // when touch on the screen to place the object
    {
        if (objectPlacement.placed == false)
        {

            if (objectPlacement.prefab.GetComponent<ARAnchor>() == null)
                objectPlacement.prefab.AddComponent<ARAnchor>();



            objectPlacement.placed = true;
            objectPlacement.ActivePlanes(false);
            PlaceBtn.SetActive(false);
            remove.SetActive(true);
            objectPlacement.enabled = false;
        }
    }

    public void OnRemove() // when reomve button is clicked removes object on scene
    {
        if (objectPlacement.placed == true)
        {
            Destroy(objectPlacement.prefab);
            objectPlacement.enabled = true;
            objectPlacement.ActivePlanes(true);
            objectPlacement.placed = false;
            PlaceBtn.SetActive(true);
            remove.SetActive(false);
        }
      

    }

    public void TakeScreenShot() // when screenshot button is clicked
    {
        float rw = (float)1920 / Screen.width;
        float rh = (float)1080 / Screen.height;
        ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpeg");
        showToast(string.Format(" SS Saved {0}", Application.persistentDataPath), 2);

    }

    public void OnLikeClicked() // if like btn is clicked
    {
        anim.Play("Liked");
        // store that on server
    }

    public void OnMediaClicked()
    {
        anim.Play("Media");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
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
