using UnityEngine;
using System.Collections;

using System;
using System.IO;


using Assets.Scripts.Libs.Models;

namespace Assets.Scripts.Libs.Data
{
    public class AppData
    {
        //public static string apiDomain = "https://xapi.cifipowa.app/api/";
        //public static string IPFSUrl = "https://storageapi.fleek.co/citizenfinance-team-bucket/cifipowa.app/";


        public static string apiDomain = "http://127.0.0.1:8008/api/";
        public static string IPFSUrl = "https://storageapi.fleek.co/promisedstar-team-bucket/cifipowa.app/";

        public static Item[] _items;
        public static Gallery[] _registries;
        public static Artist[] _artists;
        public static User _me;
    }
}
