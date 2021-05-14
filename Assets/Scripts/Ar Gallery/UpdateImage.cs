using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script update image on the frame
public class UpdateImage : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer TargetImage;


    private void Start()
    {
        GameObject.Find("SelectedOne").GetComponent<ScaleImage>().UpdateImg = this;
    }

    public void ChangeImages(Sprite img) // update the frame image
    {
        if (img == TargetImage) // this update will be change img on model
            return;
      

        TargetImage.sprite = img;
    }
}
