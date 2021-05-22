using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistryContents : MonoBehaviour
{

    private List<GameObject> Items = new List<GameObject>();
    public List<GameObject> RegistryItems
    {
        get { return Items; }
    }

    public void OnClickRegistry()
    {
        // this.transform.root.gameObject.SetActive(false);
        GameObject.Find("Single Registry page").GetComponent<Canvas>().enabled = true;
    }
}
