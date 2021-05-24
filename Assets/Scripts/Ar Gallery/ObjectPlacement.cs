using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// THIS SCRIPT DETECT PLANES AND SPAWNS THE OBJECTS IN REAL WORLD


using System;
using System.IO;

using Assets.Scripts.Libs.Data;
using Assets.Scripts.Libs.Models;
using Assets.Scripts.Libs.Functions;
using Assets.Scripts.Libs.AppManager;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class ObjectPlacement : MonoBehaviour
{

    [SerializeField]
    GameObject Marker; // change this inorder to change the object spawning

    ARRaycastManager raycastManager;
    ARPlaneManager planeManager;
    List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    bool Placed = false;  // if object placed
    GameObject Object; // reference to the main object for object to relocate

    void Start()
    {
        InitApp _app = new InitApp();
        _app.init();

        for (int i = 0; i < AppData._registries.Length; i++)
        {
            Debug.Log("rrrrrr   " + AppData._registries[i].name + " - " + AppData._registries[i].symbol);
        }

        Debug.Log("-------------------------ITEMS------------------------");

        for (int i = 0; i < AppData._items.Length; i++)
        {
            Debug.Log(AppData._items[i].name + " - " + AppData._items[i].user.name);
        }
        Debug.Log("-------------------------Artists------------------------");

        for (int i = 0; i < AppData._artists.Length; i++)
        {
            Debug.Log(AppData._artists[i].email + " - " + AppData._artists[i].user.name);
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    StartCoroutine(GetFromNet.downloadImage("https://storageapi.fleek.co/citizenfinance-team-bucket/cifipowa.app/" + data1.data[i].metaUrl + "-image", imageToUpdate[i]));
        //    Debug.Log("i = " + i);
        //}
    }

    public bool placed  // get set for placed
    {
        get { return Placed; }
        set { Placed = value; }
    }

    public GameObject prefab // return object prefabs/gameobject
    {
        get { return Object; }
    }

    private void Awake() // connect to all the components needed in the scene
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }
    void Update() // run every frame
    {

        Ray ray = Camera.current.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)); // shoot ray from the center of the screen
        if (raycastManager.Raycast(ray, Hits, TrackableType.PlaneWithinPolygon) && Placed == false)  // if hit any ar plane
        {

            if (Object == null)
            {
                Object = Instantiate(Marker, Hits[0].pose.position, Hits[0].pose.rotation);

            }
            else
            {
                Object.transform.position = Hits[0].pose.position;
            }
        }
    }

    public void ActivePlanes(bool set) // active or deactive all ar planes used by ui function class
    {
        planeManager.enabled = set;
        raycastManager.enabled = set;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(set);
        }
    }


}
