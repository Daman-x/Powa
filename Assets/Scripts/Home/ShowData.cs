using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using System;
using System.IO;


using Assets.Scripts.Libs.Data;
using Assets.Scripts.Libs.Models;
using Assets.Scripts.Libs.Functions;
using Assets.Scripts.Libs.AppManager;

public class ShowData : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_RegistryButton, m_ItemButton;

    public GameObject ScrollView;

    public GameObject Item; //This is the item prefab model

    private static InitApp _app;

    void Start()
    {
        _app = new InitApp();
        //_app.init();
        ShowRegistry();
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_RegistryButton.onClick.AddListener(ShowRegistry);
        m_ItemButton.onClick.AddListener(delegate { ShowItem("Hello"); });

    }

    void ShowRegistry()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the registry button!");
        clearScrollView();
        _app.getAllRegistry();
        //GameObject obj;
        for (int i = 0; i < AppData._registries.Length; i++)
        {
            GameObject card = Instantiate(Item) as GameObject;

            if (ScrollView != null)
            {
                card.transform.SetParent(ScrollView.transform, false);
                Text[] txt = card.GetComponentsInChildren<Text>();
                txt[0].text = AppData._registries[i].name;
                //txt[1].text = AppData._registries[i].symbol;
                //   card.GetComponent<Image>().sprite = ;
            //    StartCoroutine(GetFromNet.downloadImage(AppData.IPFSUrl + AppData._registries[i].url, card.GetComponent<Image>()));
                card.transform.SetParent(ScrollView.transform, false);
            }
        }
    }

    void ShowItem(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
        clearScrollView();
        _app.getAllItem();

        for (int i = 0; i < AppData._items.Length; i++)
        {
            GameObject card = Instantiate(Item) as GameObject;

            if (ScrollView != null)
            {
                card.transform.SetParent(ScrollView.transform, false);
                Text[] txt = card.GetComponentsInChildren<Text>();
                txt[0].text = AppData._items[i].name;
                //txt[1].text = AppData._items[i].user.name;
                //   card.GetComponent<Image>().sprite = ;
                StartCoroutine(GetFromNet.downloadImage(AppData.IPFSUrl + AppData._items[i].metaUrl + "-image", card.GetComponent<Image>()));
                card.transform.SetParent(ScrollView.transform, false);
            }
        }
    }

    void clearScrollView()
    {
        foreach (Transform child in ScrollView.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void ShowItem(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
}