using UnityEngine;
using System.Collections;

using System;
using System.IO;
using Assets.Scripts.Libs.Models;

namespace Assets.Scripts.Libs.Models
{

    [Serializable]
    public class Gallery
    {
        public int id;
        public int mint;
        public string owner;
        public string name;
        public string symbol;
        public string url;
        public User user;
    }


    [Serializable]
    public class GalleryData
    {
        public Gallery[] data;
    }
}
