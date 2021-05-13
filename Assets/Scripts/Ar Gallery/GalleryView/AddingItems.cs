using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// USED THIS SCRIPT TO ADD IMAGES ON RUNTIME AND ADD TO THE GALLERY BELT
public class AddingItems : MonoBehaviour
{

    [SerializeField]
    GameObject ImagePrefab; // prefab type

    List<Sprite> Images = new List<Sprite>(); // list of Unity sprite dynamic
    private GameObject container; // where to spawn
   
    private void Start()
    {
        container = this.gameObject; // target this gameobject to be the parent object
    //    AddingImagesToList();
        AddingImages();
    }

    void AddingImagesToList()
    {
        // ADD IMAGES TO LIST
    }

    void AddingImages()
    {
        foreach (Sprite i in Images)
        {
            if (i != null)
            {
                ImagePrefab.GetComponent<Image>().sprite = i; // take images and set the image on too the image prefab
                Instantiate(ImagePrefab, container.transform); // create a gameobject of every image in the list
            }
        }
    }
}
