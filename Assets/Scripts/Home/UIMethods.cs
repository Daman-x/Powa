using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover, Blogs;
    public Text registrybtn, itembtn;

    public GameObject notavailpanel;

    [SerializeField]
    private FetchData fetchData;

    private void Start()
    {
        mainmenu.gameObject.SetActive(true);
        OnClickRegistry();
        fetchData.AddBlogOnHome();
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

    public void OnClickItems() // when item btn is clicked on home page 
    {

        itembtn.color = Color.black;
        registrybtn.color = Color.grey;

        fetchData.AddItemsOnHome();
    }
    public void OnClickRegistry()
    {
        itembtn.color = Color.grey;
        registrybtn.color = Color.black;

        fetchData.AddRegistriesOnHome();
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
