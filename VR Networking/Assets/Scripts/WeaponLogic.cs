using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WeaponLogic : Photon.MonoBehaviour
{
    Collider[] thisCollider;
    VRTK_InteractableObject interactableObj;
    //Rigidbody rb;
    void Start()

    {
        thisCollider = GetComponents<Collider>();
        interactableObj = GetComponent<VRTK_InteractableObject>();
        //rb = GetComponent<Rigidbody>();
        //make sure the object has the VRTK script attached... 

        if (GetComponent<VRTK_InteractableObject>() == null)

        {
                
            //Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");

            return;

        }
        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(Ungrabbed);
        interactableObj.InteractableObjectGrabbed += TouchedObj;
    }

    void TouchedObj(object sender, InteractableObjectEventArgs e)
    {
        interactableObj.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
    }

    //this object has been grabbed.. so do what ever is in the code.. 

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        foreach(Collider col in thisCollider)
        {
            col.isTrigger = true;
        }
        Debug.Log("grabbed");
    }

    public virtual void Ungrabbed(object sender, InteractableObjectEventArgs e)
    {
        foreach (Collider col in thisCollider)
        {
            col.isTrigger = false;
        }
        print("ungrabbed");
    }
}
