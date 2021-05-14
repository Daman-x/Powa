using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestType : MonoBehaviour
{

    int Chest_is_Of_Type = 0;


    int Chest_Type 
    {
        get => Chest_is_Of_Type;
        set => Chest_is_Of_Type = value;
    }


    private void Start()
    {
        int randomChance = Random.Range(0, 10);
        
        if(randomChance <= 0 && randomChance <=6)
        {
            Chest_Type = 0;  //empty type 60%
        }
        else if( randomChance > 6 && randomChance < 9)
        {
            Chest_Type = 1;   // coin type 30%
        }
        else if (randomChance == 9)
        {
            Chest_Type = 2; //rare type 10%
        }

    }

    public int Type()
    {
        return Chest_Type;
    }

}
