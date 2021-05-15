using UnityEngine;
using System.Collections;

using System;
using System.IO;


using Assets.Scripts.Libs.Data;
using Assets.Scripts.Libs.Models;
using Assets.Scripts.Libs.Functions;


namespace Assets.Scripts.Libs.AppManager
{
    public class InitApp : MonoBehaviour
    {
        void start()
        {
            init();
        }

        public void init()
        {
            getAllRegistry();
            //getAllItem();
            //getAllArtist();
        }

        public void getAllRegistry()
        {
            if (AppData._registries != null) return;
            string response = GetFromNet.GetApiData("registry");
            RegistryData data1 = JsonUtility.FromJson<RegistryData>("{\"data\":" + response + "}");
            AppData._registries = data1.data;
        }

        public void getAllItem()
        {
            if (AppData._items != null) return;
            string response = GetFromNet.GetApiData("token/getNewItems?limit=100&id=0");
            ItemData data1 = JsonUtility.FromJson<ItemData>("{\"data\":" + response + "}");
            AppData._items= data1.data;
        }

        public void getAllArtist()
        {
            if (AppData._artists != null) return;
            string response = GetFromNet.GetApiData("artist/get");
            ArtistData data1 = JsonUtility.FromJson<ArtistData>("{\"data\":" + response + "}");
            AppData._artists = data1.data;
        }
    }
}
