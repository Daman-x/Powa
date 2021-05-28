using UnityEngine;
using System.Collections;

using System;
using System.IO;

namespace Assets.Scripts.Libs.Models
{

    [Serializable]
    public class Registry
    {
        public int id;
        public int mint;
        public string owner;
        public string name;
        public string symbol;
        public string url;
    }


    [Serializable]
    public class RegistryData
    {
        public Registry[] data;
    }
}
