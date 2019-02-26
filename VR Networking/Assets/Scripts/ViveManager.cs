using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveManager : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    public static ViveManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;    
        }
    }
}
