using UnityEngine;
using System.Collections;

using System;
using System.IO;


namespace Assets.Scripts.Libs.Models
{
    [Serializable]
    public class User
    {
        public string name;
        public string url;
        public string twitter;
        public string instagram;
        public string website;
        public string bio;
        public int registry;
        public int mint;
    }

}