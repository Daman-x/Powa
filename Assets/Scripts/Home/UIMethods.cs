using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover;


    private void Start()
    {
        mainmenu.gameObject.SetActive(true);
        discover.gameObject.SetActive(false);
    }
    public void OnClickDiscover()
    {
        mainmenu.gameObject.SetActive(false);
        discover.gameObject.SetActive(true);
    }
}
