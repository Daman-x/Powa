using UnityEngine;
using System.Collections;

using System;
using System.IO;


namespace Assets.Scripts.Libs.Models
{
    [Serializable]
    public class Artist
    {
        public int id;
        public string name;
        public string email;
        public string address;
        public User user;
    }

    [Serializable]
    public class ArtistData
    {
        public Artist[] data;
    }

}
