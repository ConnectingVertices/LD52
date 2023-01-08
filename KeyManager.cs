using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    public List<bool> keys;
    public List<GameObject> CarryItems;
    public List<LockItem> LockItems;
    public List<KeyItem> KeyItems;

    public static KeyManager instance;

    public int CurrentKey = 99 ;
    public int CurrentLock = 99;
    public int CurrentCarry = 99;

    // Start is called before the first frame update
    void Awake()
    {
        
        instance = this;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            if(CurrentKey == 99) 
            { 
                if(CurrentLock == 99)
                {
                    return;
                }
                else
                {
                    if(CurrentCarry == CurrentLock)
                    {
                        CarryItems[CurrentCarry].SetActive(false);
                        keys[CurrentCarry] = true;
                        LockItems[CurrentCarry].IsFixed();
                        CurrentCarry = 99;
                    }
                }
            }
            else
            {
                if (keys[CurrentKey])
                    return;


                if(CurrentCarry!= 99) 
                {
                    KeyItems[CurrentCarry].ReturnItem();
                    CarryItems[CurrentCarry].SetActive(false);
                }

                CurrentCarry = CurrentKey;
                CarryItems[CurrentCarry].SetActive(true);
                KeyItems[CurrentKey].PickUp();

            }




        }

    }


}
