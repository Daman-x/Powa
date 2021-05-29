using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover, Blogs;
    public GameObject notavailpanel;

    [SerializeField]
    private FetchData fetchData;

    private void Start()
    {
        mainmenu.gameObject.SetActive(true);
        fetchData.AddGalleriesOnHome();
        fetchData.AddItemsOnHome();
    }
    public void OnClickDiscover()
    {
        mainmenu.gameObject.SetActive(false);
        discover.gameObject.SetActive(true);
        fetchData.AddDataOnDiscover();
    }
    public void OnClickBlogs()
    {
        mainmenu.gameObject.SetActive(false);
        Blogs.gameObject.SetActive(true);
        fetchData.AddBlogOnBlogPage();
    }
    public void OnClickHome()
    {
        mainmenu.gameObject.SetActive(true);
        discover.gameObject.SetActive(false);
    }
    public void OnclickClose()
    {
        notavailpanel.SetActive(false);
    }

    public void OnClickWallet()
    {
        notavailpanel.SetActive(true);
    }
    public void OnClickFav()
    {
        notavailpanel.SetActive(true);
    }
    public void OnClickProfile()
    {
        notavailpanel.SetActive(true);
    }
}
