using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARAnchorManager))]
public class RandomChestPlacer : MonoBehaviour
{

    [SerializeField]
    GameObject Chest;

    ARPlaneManager planeManager;
    ARRaycastManager raycastManager;
    ARAnchorManager anchorManager;

    List<ARRaycastHit> Hits = new List<ARRaycastHit>();
    List<ARAnchor> Anchors = new List<ARAnchor>();

    float SpawnAt;
    float time = 0f;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        raycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }

    private void Start()
    {
        RandomlySpawnTime();
    }

    private void Update()
    {
        Ray ray = Camera.current.ScreenPointToRay(new Vector3((Screen.width / 2) , (Screen.height / 2)));

        if(raycastManager.Raycast(ray , Hits , TrackableType.PlaneWithinBounds) && time >= SpawnAt)
        {
            AddAnchor(Hits[Random.Range(0,Hits.Count)]);
            time = 0f;
            RandomlySpawnTime();
            this.enabled = false;
        }

        time += Time.deltaTime;
    }

    #region Functions


    void AddAnchor(in ARRaycastHit hitPoint)
    {
        ARAnchor anchor = null;

        if(hitPoint.trackable is ARPlane plane)
        {
            var oldprefab = anchorManager.anchorPrefab;
            anchorManager.anchorPrefab = Chest;
            anchor = anchorManager.AttachAnchor(plane, hitPoint.pose); // create gameobject and set an anchor on plane
            anchorManager.anchorPrefab = oldprefab;

            if (anchor)
                Anchors.Add(anchor);
            else
                Debug.LogWarning("Error creating Anchor");
        }
    }

    void RandomlySpawnTime()
    {
        SpawnAt = Random.Range(0f, 20f);
    }

    void RemoveAnchor()
    { }

    #endregion
}