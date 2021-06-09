using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Libs.Models
{

    [Serializable]
    public class ItemMeta
    {
        public string name;
        public string description;
    }
    [Serializable]
    public class ItemMetaData
    {
        public ItemMeta[] data;
    }
}

