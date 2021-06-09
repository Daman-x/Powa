using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using backend.Services;
using UnityEngine.UI;
using Assets.Scripts.Libs.Models;
public class FetchData : MonoBehaviour
{
    [SerializeField]
    GameObject Galleryhome, galleryItem;

    [SerializeField]
    public RectTransform rect;

    [SerializeField]
    GameObject GalleriesView, ItemsView;

    [SerializeField]
    Backend obj;

    public static Item[] arr;
    public static string desc;
    public void AddItemsOnHome() 
    {
        arr = obj.ShowItems("5");
      
        foreach (Item i in arr)
        {
            
            ItemMeta tmp = JsonUtility.FromJson<ItemMeta>(obj.GetApiData(obj.Ipfurl + i.metaUrl + "-meta"));
            GameObject gameobj = Instantiate(galleryItem) as GameObject;

                obj.GetImage(i.metaUrl + (i.imgType == "glb" ? "-display-image" : "-image"), gameobj.GetComponent<ItemContents>().main_image);

                gameobj.GetComponent<RectTransform>().sizeDelta = new Vector3(450f, rect.rect.height);
                gameobj.GetComponent<ItemContents>().getData(i.id, i.name, i.user.name, tmp.description , i.favourite, (int)Random.Range(1, 10000));
               
                obj.GetImage(i.owner + "-avatar", gameobj.GetComponent<ItemContents>().owner_image);
                obj.GetImage(i.reg.url, gameobj.GetComponent<ItemContents>().ofGallery);
                gameobj.transform.SetParent(ItemsView.transform, false);
        }
    }

    public void AddItemOnScrollview(GameObject gameobj = null)
    {

        if(gameobj == null)
        {
            obj.Getdata(arr[arr.Length - 1].id );
           // ItemMeta tmp = JsonUtility.FromJson<ItemMeta>(obj.GetApiData(obj.Ipfurl + arr[0].metaUrl + "-meta"));
           // desc = tmp.description;
        }
        else
        {
            StartCoroutine(Card(gameobj));  
        }
    }

    private IEnumerator Card(GameObject gameobj)
    {
        ItemContents contents = gameobj.GetComponent<ItemContents>();

        obj.GetImage(arr[0].metaUrl + (arr[0].imgType == "glb" ? "-display-image" : "-image"), contents.main_image);

        contents.getData(arr[0].id, arr[0].name, arr[0].user.name, "", arr[0].favourite, (int)Random.Range(1, 10000));

        obj.GetImage(arr[0].owner + "-avatar", contents.owner_image);
        obj.GetImage(arr[0].reg.url, contents.ofGallery);

        yield return null;
    }

    public void AddGalleriesOnHome()
    { 
          Gallery[] data = obj.ShowGalleries("5");

            foreach (Gallery i in data)
            {
                GameObject gameobj = Instantiate(Galleryhome) as GameObject;
                gameobj.GetComponent<GalleryContents>().getData(i.id , i.name ,i.url);   
                gameobj.transform.SetParent(GalleriesView.transform, false);
            }
    }

    public void AddBlogOnHome()
    {
        //add blog prefabs in homeblog content 
    }
    public void AddBlogOnBlogPage()
    {
        //add blog prefabs on  the main blog content
    }
    
    public void AddDataOnDiscover()
    {
        // add discover prefabs on discovercontent  there are 3 prefabs which are basically nested items and registry prefabs
    }

}
