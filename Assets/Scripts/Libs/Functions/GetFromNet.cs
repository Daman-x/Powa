using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System;
using System.IO;

using UnityEngine.Networking;
using System.Net;

using Assets.Scripts.Libs.Data;

namespace Assets.Scripts.Libs.Functions
{
    public class GetFromNet
    {
        public static IEnumerator downloadImage(string url, Image imageToUpdate)
        {
            Debug.Log("url=" + url);

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

            DownloadHandler handle = www.downloadHandler;

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                UnityEngine.Debug.Log("Error while Receiving: " + www.error);
            }
            else
            {
                UnityEngine.Debug.Log("Success");
                //Load Image
                Texture2D texture2d = DownloadHandlerTexture.GetContent(www);

                Sprite sprite = null;
                sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);

                if (sprite != null)
                {
                    imageToUpdate.sprite = sprite;
                }
            }
        }

        public static string GetApiData(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            return jsonResponse;
        }

        //public static async string GetTextFromNet(string uri)
        //{
        //    var webClient = new System.Net.WebClient();
        //    string url = AppData.apiDomain + uri;
        //    string source = await webClient.DownloadStringTaskAsync(url);
        //    return source;
        //}
    }
}
