using UnityEngine;
using System.Collections;

using System;
using System.IO;


using Assets.Scripts.Libs.Data;
using Assets.Scripts.Libs.Models;
using Assets.Scripts.Libs.Functions;


namespace Assets.Scripts.Libs.AppManager
{
    public class InitApp
    {
        public void init()
        {
            //getAllRegistry();
            getAllItem();
        }

        public void getAllRegistry()
        {
            string response = GetFromNet.GetApiData("registry");
            RegistryData data1 = JsonUtility.FromJson<RegistryData>("{\"data\":" + response + "}");
            AppData._registries = data1.data;
        }

        public void getAllItem()
        {
            string response = GetFromNet.GetApiData("token/getNewItems?limit=100&id=0");
            ItemData data1 = JsonUtility.FromJson<ItemData>("{\"data\":" + response + "}");
            AppData._items= data1.data;

        }
    }
}