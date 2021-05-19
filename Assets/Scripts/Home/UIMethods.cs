using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover , singleRegistry , blogs;


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

    public void OnClickRegisteries()
    {
        mainmenu.gameObject.SetActive(false);
        singleRegistry.gameObject.SetActive(true);
    }

    public void OnClickBlogs()
    {
        mainmenu.gameObject.SetActive(false);
        blogs.gameObject.SetActive(true);
    }

}
