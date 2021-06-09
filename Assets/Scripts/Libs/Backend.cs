using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;

using Assets.Scripts.Libs.Models;

namespace backend.Services
{
    public class Backend : MonoBehaviour
    {

        private const string apidomain = "https://xapi.cifipowa.app/api/";
        private const string IPFSUrl = "https://storageapi.fleek.co/citizenfinance-team-bucket/cifipowa.app/";

        public string Ipfurl
        {
            get { return IPFSUrl; }
        }
 
      public Gallery [] ShowGalleries(string number)
        {
            if(number == "all" || number == "ALL")
            {
                GalleryData data1 = JsonUtility.FromJson<GalleryData>("{\"data\":" + GetApiData(apidomain + "registry") + "}");
                return data1.data;
            }
            else
            {

                GalleryData data1 = JsonUtility.FromJson<GalleryData>("{\"data\":" + GetApiData(apidomain + "registry" + "/getLatest/" + number) + "}");
                return data1.data;
            }
        }

        public Item[] ShowItems(string number) //https://www.xapi.cifipowa.app/api/token/getTokens?limit=3
        {
            if (number == "all" || number == "ALL")
            {
                ItemData data1 = JsonUtility.FromJson<ItemData>("{\"data\":" + GetApiData(apidomain + "token/getTokens") + "}");
                return data1.data;
            }
            else
            {
                ItemData data1 = JsonUtility.FromJson<ItemData>("{\"data\":" + GetApiData(apidomain + "token/getTokens?limit=" + number) + "}");
                return data1.data;
            }
        }

        public string GetApiData(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            return jsonResponse;
        }


        public void Getdata(int id = 0)
        {
            StartCoroutine(downloadData(id.ToString()));
        }
        private IEnumerator downloadData(string id = "" , string limit = "1") //https://xapi.cifipowa.app/api/token/getNewItems?id=&limit=1
        {
          //  Debug.Log(apidomain + "token/getNewItems?id=" + id + "&limit=1");
            UnityWebRequest www = UnityWebRequest.Get(apidomain + "token/getNewItems?id=" + id + "&limit=1");
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                ItemData data1 = JsonUtility.FromJson<ItemData>("{\"data\":" + www.downloadHandler.text + "}");
                FetchData.arr = data1.data;
                StartCoroutine(GetDescription(FetchData.arr[0].metaUrl));
            }
        }

        public void GetDesc(string metaurl)
        {
            StartCoroutine(GetDescription(metaurl));
        }
        private IEnumerator GetDescription(string uri)
        {
            UnityWebRequest www = UnityWebRequest.Get( Ipfurl + uri + "-meta");
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                FetchData.desc = "";
            }
            else
            {
                ItemMeta tmp = JsonUtility.FromJson<ItemMeta>(www.downloadHandler.text);
                FetchData.desc = tmp.description;
            }
        }

        public void GetImage(string url , Image img)
        {
            StartCoroutine(downloadImage(url, img));
        }

        private IEnumerator downloadImage(string url, Image img)
        {

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(IPFSUrl + url);
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
}


