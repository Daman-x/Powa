using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT MANAGES THE WALKTHROUGH WHICH ONLY RUN ONCE
public class WalkthroughManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] images;
    byte i = 0;
    public Button skip, getStarted;

    private const float MAX_SWIPE_TIME = 0.5f;
    private const float MIN_SWIPE_DISTANCE = 0.17f;

    Vector2 startPos;
    float startTime;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Walkthrough Completed") == 1) // IF WLAKTHROUGH ALREADY SEEN SKIP IT
        {
            Destroy(this.gameObject);
        }
        getStarted.enabled = false;
    }
    private void Update()
    {
        if (Input.touches.Length > 0) // SWIPE TO MOVE NEXT LEFT TO RIGHT
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                    return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                    return;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x < 0)
                    {
                        ChangeSprite();
                    }
                  
                }
            }
        }
    }

    private void ChangeSprite()
    {
        if (i == images.Length)
            return;

        i++;
        GetComponent<Image>().sprite = images[i];
        if(i == images.Length-1)
        {
            skip.gameObject.SetActive(false);
            getStarted.enabled = true;
        }
    }

    public void OnClickGetStarted() // GETSTARTED CLCIKED
    {
        PlayerPrefs.SetInt("Walkthrough Completed", 1);
        Destroy(this.gameObject);
    }

    public void OnClickedSkip() // SKIP CLICKED
    {
        GetComponent<Image>().sprite = images[images.Length - 1];
        skip.gameObject.SetActive(false);
        getStarted.enabled = true;
    }
}
