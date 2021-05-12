using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// THIS SCRIPT DETECT PLANES AND SPAWNS THE OBJECTS IN REAL WORLD

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
    bool RemoveClicked = true; // if remove btn is clicked

    public bool placed  // get set for placed
    {
        get { return Placed; }
        set { Placed = value; }
    }
    public bool remove //get set for remove variable
    {
        get { return RemoveClicked; }
        set { RemoveClicked = value; }
    }

    public GameObject prefabs // return object prefabs/gameobject
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
        if (raycastManager.Raycast(ray, Hits, TrackableType.PlaneWithinPolygon) && Placed == false && RemoveClicked == true)  // if hit any ar plane
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
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(set);
        }
    }


}
