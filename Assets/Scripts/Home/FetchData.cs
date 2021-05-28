using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using backend.Services;
using Assets.Scripts.Libs.Models;
public class FetchData : MonoBehaviour
{
    [SerializeField]
    GameObject Registry, Item, blog, itemgroup, item4registry1, registry1item2;

    [SerializeField]
    GameObject HomeRegistryContent , HomeItemContent, HomeBlogContent , DiscoverContent , mainBlogContent;

    Registry[] data;

    Backend obj = new Backend();

    public void AddItemsOnHome() 
    {
        HomeRegistryContent.SetActive(false);
        HomeItemContent.SetActive(true);
        // add item prefabs in home item content upto 10only
    }

    public void AddRegistriesOnHome()
    {
        HomeRegistryContent.SetActive(true);
        HomeItemContent.SetActive(false);

        if (HomeRegistryContent.transform.childCount < 5 )
        {   
            data = obj.ShowRegistries("5");

            foreach (Registry i in data)
            {
                GameObject gameobj = Instantiate(Registry) as GameObject;
                gameobj.GetComponent<RegistryContents>().getData(i.id, i.name, i.owner, i.mint, obj.Ipfsurl + i.url);
                gameobj.transform.SetParent(HomeRegistryContent.transform, false);
            }
        }
        // add registry prefab in home registry content upto 10 only
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
