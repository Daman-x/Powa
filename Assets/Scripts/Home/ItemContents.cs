using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on any item clicked this script will be called

public class ItemContents : MonoBehaviour
{

    public void OnClickItems()
    {
        // this.transform.root.gameObject.SetActive(false);
        GameObject.Find("Single Item Page").GetComponent<Canvas>().enabled = true;
    }
}
