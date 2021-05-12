using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script update image on the frame
public class UpdateImage : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer TargetImage;

    AddingItems addingItems;
   
    private void Start()
    {
        addingItems = GameObject.Find("Content").GetComponent<AddingItems>();
        TargetImage.sprite = addingItems.selectedimg;
    }

    private void Update() // update the frame image
    {
        if (addingItems.selectedimg == TargetImage) // this update will be change in the future for optimzation
            return;
      

        TargetImage.sprite = addingItems.selectedimg;
    }
}
