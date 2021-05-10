using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT IS NOT IN USE FOR NOW -------------------------------------------------------------------------------------------------
public class MenuController : MonoBehaviour
{
    public GameObject[] panels;
    int i = 0;
    public Image panelno;
    public Sprite[] dots;
    public GameObject skip , nextslide;

  

    public void OnStartedClick()
    {
        //todo next scene transcition
        
    }

    public void OnNextClick()
    {
        i++;
        if (i != 0)
        {
            panels[i - 1].SetActive(false);
        }

        if(i == panels.Length - 1)
        {
            OnLastPanel();
        }
        panels[i].SetActive(true);
        PanelNo(i);
        
        
    }

    void OnLastPanel()
    {
        panels[i].SetActive(false);
        panels[panels.Length - 1].SetActive(true);
        PanelNo(panels.Length - 1);
        skip.SetActive(false);
        nextslide.SetActive(false);
    }

    public void OnSkip()
    {
        OnLastPanel();
    }

    void PanelNo( int no)
    {
        panelno.sprite = dots[no];
    }

  
}
