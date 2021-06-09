using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// on any item clicked this script will be called

public class ItemContents : MonoBehaviour
{
    private int id;
    private string name;
    [SerializeField]
    private Text Ownername, description, likes, comments;
    [SerializeField]
    public Image main_image, owner_image, ofGallery;

    public void OnClickItems()
    {
        GameObject.Find("Single Item Page").GetComponent<Canvas>().enabled = true;
    }

    public void getData(int id = -1 , string name = "", string ownername = "" , string description = "" , int likes = 0 , int comments = 0)
    {
        this.id = id;
        this.name = name;
        this.Ownername.text =  ownername != null ? ownername : "No Name";
        this.description.text = description;
        this.likes.text =   likes > 0 ?  likes.ToString() + " likes" : "0 likes";
        this.comments.text =  comments > 0 ? comments.ToString() + " comments" : "Be first to Comment";
    }

}
