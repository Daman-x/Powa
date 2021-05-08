using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
{
    [SerializeField]
    private int WhichCollider; //0 = center  -1 = left  1 = right


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Image"))
        {
            if (WhichCollider == 0)
            {
                collision.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                collision.gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
            }
            if (WhichCollider == -1)
            {
                collision.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                collision.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 70);
            }
            if (WhichCollider == 1)
            {
                collision.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                collision.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 70);
            }
        }
    }

}
