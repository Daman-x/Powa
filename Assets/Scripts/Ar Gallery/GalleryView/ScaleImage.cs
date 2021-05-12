using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT IS APPLYED ON GALLERVIEW TO SCALE THE SELECTED IMAGE AND RESCALE THE NOT SELECTED ONE

public class ScaleImage : MonoBehaviour
{

    [SerializeField]
    AddingItems addingItems; // refer to adding items

    private void OnTriggerEnter2D(Collider2D collision) // if images is selected
    { 
        collision.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
        addingItems.selectedImages(collision.gameObject.GetComponent<Image>());     // selected image transfer to adding items selectedimage funtion
    }

    private void OnTriggerExit2D(Collider2D collision) // if not
    {
        collision.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 70);
    }

}
