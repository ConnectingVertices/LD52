using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockItem : MonoBehaviour
{
    public int LockID;
    public Collider coll;

    public GameObject canvas;

    public GameObject Broken;
    public GameObject Fixed;
    public Animator Anim;
    public Animator Anim2;

    bool isFixed = false;
    // Start is called before the first frame update
    void Start()
    {
        Broken.SetActive(false);
        Fixed.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyManager.instance.CurrentLock = LockID;

        if (!isFixed)
        {
            Broken.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Broken.SetActive(false);

        KeyManager.instance.CurrentLock = 99;

    }

   public void IsFixed()
    {
        Broken.SetActive(false);
        Fixed.SetActive(true);
        Anim.enabled = true;
        isFixed= true;

        if(Anim2)
            Anim2.enabled = true;

        if(LockID == 5)
            canvas.SetActive(true);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
