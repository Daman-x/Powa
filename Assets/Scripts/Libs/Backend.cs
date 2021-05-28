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
 
      public Registry [] ShowRegistries(string number)
        {
            if(number == "all" || number == "ALL")
            {
                RegistryData data1 = JsonUtility.FromJson<RegistryData>("{\"data\":" + GetApiData(apidomain + "registry") + "}");
                return data1.data;
            }
            else
            {

                RegistryData data1 = JsonUtility.FromJson<RegistryData>("{\"data\":" + GetApiData(apidomain + "registry" + "/getLatest/" + number) + "}");
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


