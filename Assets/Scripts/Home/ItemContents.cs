using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
    private Image main_image, owner_image;

    public void OnClickItems()
    {
        GameObject.Find("Single Item Page").GetComponent<Canvas>().enabled = true;
    }

    public void getData(int id = -1,string MainUrl = "" , string OwnerUrl = "" , string name = "", string ownername = "" , string description = "" , int likes = 0 , int comments = 0)
    {
        this.id = id;
        this.name = name;
        this.Ownername.text =  ownername != null ? ownername : "No Name";
        this.description.text = description;
        this.likes.text =   likes > 0 ?  likes.ToString() + " likes" : "";
        this.comments.text =  comments > 0 ? comments.ToString() + " comments" : "";
        StartCoroutine(downloadImage(MainUrl, this.main_image));
        StartCoroutine(downloadImage(OwnerUrl, this.owner_image));
    }

    public void OnClickAR()
    {
        ObjectPlacement.img = this.main_image.sprite;
        SceneManager.LoadScene("ARScene");       
    }

    private IEnumerator downloadImage(string url , Image img)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error while Receiving: " + www.error);
        }
        else
        {
            //Load Image
            Texture2D texture2d = DownloadHandlerTexture.GetContent(www);

            Sprite sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);

            if (sprite != null)
            {
                img.sprite = sprite;
            }
        }
    }
}
