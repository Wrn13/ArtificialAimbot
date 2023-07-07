using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message for when looking at object.
    public string promptMessage;

    

    public void BaseInteract(){
        Interact();
    }

    protected virtual void Interact(){
        //To implement per object
    }
}
