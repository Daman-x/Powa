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
    public Text _text;


    void Start()
    {
        InitApp _app = new InitApp();
        _app.init();
        ShowRegistry();
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_RegistryButton.onClick.AddListener(ShowRegistry);
        m_ItemButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });

    }

    void ShowRegistry()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the registry button!");

        //GameObject obj;
        for (int i = 0; i < AppData._registries.Length; i++)
        {
            GameObject card = Instantiate(Item) as GameObject;
            //Text txt = Item.GetComponent<Text>();
            //Debug.Log("txt = " + txt.text);
            //if (txt != null)
            //{
            //    Debug.Log("txt = " + txt.text);
            //}
            //card.GetComponent<Text>().text = AppData._registries[i].name;

            if (ScrollView != null)
            {
                card.transform.SetParent(ScrollView.transform, false);
            //    Text [] txt = card.GetComponentsInChildren<Text>();
            //    txt[0].text = "reguster";
           //     txt[1].text = "Japan";
            //    card.GetComponent<Image>().sprite = ;

            }
            //Debug.Log("rrrrrr   " + AppData._registries[i].name + " - " + AppData._registries[i].symbol + " , text = " + Item.GetComponent<Text>().text);
            //ItemGameObject is my prefab pointer that i previous made a public property  
            //and  assigned a prefab to it
            //GameObject obj = Instantiate(Item) as GameObject;
            //obj.GetComponent<Text>().text = AppData._registries[i].name;
            //Debug.Log("text = " + Item.text);
            //GameObject card = Instantiate(ScrollView) as GameObject;


            //scroll = GameObject.Find("CardScroll");
            //if (ScrollView != null)
            //{
            //    card.transform.SetParent(ScrollView.transform, false);
            //}
        }
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
}