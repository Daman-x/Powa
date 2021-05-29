using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Net;

using Assets.Scripts.Libs.Models;

namespace backend.Services
{
    public class Backend 
    {

        private const string apidomain = "https://xapi.cifipowa.app/api/";
        private const string IPFSUrl = "https://storageapi.fleek.co/citizenfinance-team-bucket/cifipowa.app/";

        public string Ipfsurl
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

        private string GetApiData(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            return jsonResponse;
        }

    }
}


