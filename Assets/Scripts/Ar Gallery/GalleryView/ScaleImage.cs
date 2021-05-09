using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        collision.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        collision.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 70);
    }

}
