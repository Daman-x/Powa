using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class CollectRewards : MonoBehaviour
{

    public Text txt;
    Vector2 touch_position;
    RaycastHit Hits;

    bool IsTouching()
    {
        if (Input.touchCount > 0)
        {
            touch_position = Input.GetTouch(0).position;
            return true;
        }

        touch_position = default;
        return false;
       
    }

    void Update()
    {
        if (!IsTouching())
            return;

        Ray pointingTo = Camera.current.ScreenPointToRay(touch_position);
        if(Physics.Raycast(pointingTo, out Hits))
        {
            if(Hits.collider.gameObject.CompareTag("Chest"))
            {
                txt.text = string.Format("{0} type hit", Hits.collider.gameObject.GetComponent<ChestType>().Type());
            }
        }
    }

    
}
