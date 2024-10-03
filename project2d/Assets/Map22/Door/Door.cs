using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Sprite DoorOpen;

    public Sprite DoorClose;

    bool DoorNow;
    private SpriteRenderer sp; 

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        DoorNow = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (DoorNow == true)
        {
            sp.sprite = DoorClose;
        }
        else
        {
            sp.sprite = DoorOpen;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            DoorNow = !DoorNow;


        }

    }

    

}

