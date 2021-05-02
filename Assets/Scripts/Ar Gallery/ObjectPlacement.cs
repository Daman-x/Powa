using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class ObjectPlacement : MonoBehaviour
{

    [SerializeField]
    GameObject Marker;
    public Text Place;
    public Text txt;

    ARRaycastManager raycastManager;
    ARPlaneManager planeManager;
    List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    bool Placed = false;
    GameObject Object;
    bool RemoveClicked = true;


    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.current.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (raycastManager.Raycast(ray, Hits, TrackableType.PlaneWithinPolygon) && Placed == false && RemoveClicked == true)
        {

            if (Object == null)
            {
                Object = Instantiate(Marker, Hits[0].pose.position, Hits[0].pose.rotation);
            }
            else
            {
                Object.transform.position = Hits[0].pose.position;
            }
        }
    }

    void ActivePlanes(bool set)
    {
        planeManager.enabled = set;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(set);
        }
    }

    #region UI function

    public void OnClickPlaceButton()
    {
        if (Placed == false)
        {
            Placed = true;
            ActivePlanes(false);
            Place.GetComponent<Text>().text = "ReAdjust";
        }
        else
        {
            OnClickReplaceButton();
        }

    }

    public void OnClickReplaceButton()
    {
        Placed = false;
        ActivePlanes(true);
        Place.GetComponent<Text>().text = "Place";

    }

    public void OnRemove()
    {
        if (RemoveClicked && Placed == true)
        {
            Destroy(Object);
            ActivePlanes(false);
            RemoveClicked = false;
            Placed = false;
            Place.GetComponent<Text>().text = "Place";
        }
        else if(!RemoveClicked)
        {
            ActivePlanes(true);
            RemoveClicked = true;
        }

    }

    public void TakeScreenShot()
    {
        float rw = (float)1920 / Screen.width;
        float rh = (float)1080 / Screen.height;
        ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpeg");
        showToast( string.Format(" SS Saved {0}",Application.persistentDataPath)  , 2);

    }
    #endregion

    

    void showToast(string text,
        int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = txt.color;

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

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
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
}
