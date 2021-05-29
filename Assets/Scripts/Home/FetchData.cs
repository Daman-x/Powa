using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using backend.Services;
using Assets.Scripts.Libs.Models;
public class FetchData : MonoBehaviour
{
    [SerializeField]
    GameObject Galleryhome, galleryItem;

    [SerializeField]
    GameObject GalleriesView, ItemsView;

    Backend obj = new Backend();

    public void AddItemsOnHome() 
    {
        Item[] data = obj.ShowItems("5");

        foreach (Item i in data)
        {
            GameObject gameobj = Instantiate(galleryItem) as GameObject;
            gameobj.GetComponent<ItemContents>().getData(i.id ,obj.Ipfsurl + i.metaUrl + "-image", obj.Ipfsurl + i.owner + "-avatar" , i.name , i.user.name ,"" ,i.favourite , (int) Random.Range(1,10000));
            gameobj.transform.SetParent(ItemsView.transform, false);
        }
    }

    public void AddGalleriesOnHome()
    { 
          Gallery[] data = obj.ShowGalleries("5");

            foreach (Gallery i in data)
            {
                GameObject gameobj = Instantiate(Galleryhome) as GameObject;
                gameobj.GetComponent<GalleryContents>().getData(i.id , i.name , obj.Ipfsurl+i.url);   
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
