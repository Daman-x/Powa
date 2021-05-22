using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover, Blogs;


    private void Start()
    {
        mainmenu.gameObject.SetActive(true);
    }
    public void OnClickDiscover()
    {
        mainmenu.gameObject.SetActive(false);
        discover.gameObject.SetActive(true);
    }
    public void OnClickBlogs()
    {
        mainmenu.gameObject.SetActive(false);
        Blogs.gameObject.SetActive(true);
    }

}
