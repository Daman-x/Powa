using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

// When any registry is clicked this script will call on 
public class RegistryContents : MonoBehaviour
{

    private int id;
    [SerializeField]
    private Image sprite;
    [SerializeField]
    private Text name;

    private string Url;
    [SerializeField]
    private Text Ownername;
    [SerializeField]
    private Image Ownersprite;
    [SerializeField]
    private Text mint;

    public void OnClickRegistry()
    {
        // this.transform.root.gameObject.SetActive(false);
        GameObject.Find("Single Registry page").GetComponent<Canvas>().enabled = true;
    }

    public void getData(int id = -1 , string name = "" , string owner = "" , int mint = 0 , string URL = "")
    {
        this.id = id;
        this.name.text = name;
        this.Ownername.text = owner;
        this.mint.text = mint.ToString();
        this.Url = URL;
        StartCoroutine(downloadImage(URL));
    }

    private IEnumerator downloadImage(string url)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error while Receiving: " + www.error);
        }
        else
        {
            Debug.Log("Success image");
            //Load Image
            Texture2D texture2d = DownloadHandlerTexture.GetContent(www);

            Sprite sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);

            if (sprite != null)
            {
                this.sprite.sprite = sprite;
            }
        }
    }

}
