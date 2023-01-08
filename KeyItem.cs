using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public int KeyID;
    public GameObject PressPlate;
    public GameObject KeyGO;
    public Collider coll;



    // Start is called before the first frame update
    void Start()
    {
        PressPlate.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyManager.instance.CurrentKey = KeyID;

        if(!KeyManager.instance.keys[KeyID]) 
        {
            PressPlate.SetActive(true);    
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PressPlate.SetActive(false);

        KeyManager.instance.CurrentKey = 99;

    }

    public void PickUp()
    {
        KeyGO.SetActive(false);
        PressPlate.SetActive(false);

    }

    public void ReturnItem()
    {
        KeyGO.SetActive(true);


    }


    // Update is called once per frame
    void Update()
    {
        




    }
}
