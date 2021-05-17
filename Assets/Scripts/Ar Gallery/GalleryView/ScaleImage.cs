using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT IS APPLYED ON GALLERVIEW TO SCALE THE SELECTED IMAGE AND RESCALE THE NOT SELECTED ONE

public class ScaleImage : MonoBehaviour
{

    private UpdateImage updateImage; // refer to updateimage
    private Sprite ImgOn;

    public UpdateImage UpdateImg
    {
        set { 
            updateImage = value;
            updateImage.TargetImage.sprite = ImgOn;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // if images is selected
    { 
        collision.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
        ImgOn = collision.gameObject.GetComponent<Image>().sprite;

        if(updateImage != null)
            updateImage.ChangeImages(collision.gameObject.GetComponent<Image>().sprite);     // selected image transfer to updateimage, changing image function 
    }

    private void OnTriggerExit2D(Collider2D collision) // if not
    {
        collision.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 70);
    }

}
