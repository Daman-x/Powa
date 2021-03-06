using UnityEngine;
using System.Collections;

using System;
using System.IO;


namespace Assets.Scripts.Libs.Models
{
    [Serializable]
    public class Item
    {
        public int id;
        public string owner;
        public string creator;
        public string registry;
        public int tokenId;
        public string name;
        public string metaUrl;
        public string imgType;
        public int favourite;
        public string description;
        public User user;
        public Gallery reg;
    }

    [Serializable]
    public class ItemData
    {
        public Item[] data;
    }
}