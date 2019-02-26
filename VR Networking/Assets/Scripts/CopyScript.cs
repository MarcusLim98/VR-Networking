using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour
{
    public int index = 1;   

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            switch (index)
            {
                case 1:
                    transform.position = ViveManager.instance.head.transform.position;
                    transform.rotation = ViveManager.instance.head.transform.rotation;  
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }     
    }
}
