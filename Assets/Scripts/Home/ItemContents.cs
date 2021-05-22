using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContents : MonoBehaviour
{

    public void OnClickItems()
    {
        // this.transform.root.gameObject.SetActive(false);
        GameObject.Find("Single Item Page").GetComponent<Canvas>().enabled = true;
    }
}
