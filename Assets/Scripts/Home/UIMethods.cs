using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMethods : MonoBehaviour
{
    public Canvas mainmenu, discover, Blogs;
    public GameObject notavailpanel;

    private bool calledOnce = false;
    public GameObject item;
    public GameObject ItemsView;

    [SerializeField]
    private FetchData fetchData;

    private void Start()
    {
        mainmenu.gameObject.SetActive(true);
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
    public void OnScrollTo(Vector2 value)
    {
        if(FetchData.arr[0].id <= 2)
        {
            return;
        }

       // Debug.Log(value.y);
       if(value.y < 0.5 && calledOnce == false)
        {
            fetchData.AddItemOnScrollview();
            calledOnce = true;
          //  Debug.Log("data");
        }


        if(value.y <= 0.1)
        {
            calledOnce = false;
         //   Debug.Log("called");
            GameObject gameobj = Instantiate(item) as GameObject;
            gameobj.GetComponent<RectTransform>().sizeDelta = new Vector3(450f, fetchData.rect.rect.height);
            gameobj.transform.SetParent(ItemsView.transform, false);
            fetchData.AddItemOnScrollview(gameobj);
        }
    }
}
