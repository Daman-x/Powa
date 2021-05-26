using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchData : MonoBehaviour
{
    [SerializeField]
    GameObject Registry, Item, blog, itemgroup, item4registry1, registry1item2;

    [SerializeField]
    GameObject HomeRegistryContent , HomeItemContent, HomeBlogContent , DiscoverContent , mainBlogContent;

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
