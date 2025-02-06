using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Template Method Pattern is used for this class
public abstract class Interactable : MonoBehaviour
{
    // this string will be displayed to the player when they are in range of the interactable object
    public string promptMessage;

    public void BaseInteract() 
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //Template function to be used at the discretion of the child class
    }

}
