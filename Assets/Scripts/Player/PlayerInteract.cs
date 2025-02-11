using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] // To make the distance visible in the Inspector
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty); //Clears the text on the UI (when not hovering over it)

        //Creating a ray at the center of the camera and shooting it forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable to store collision information.

        if (Physics.Raycast(ray, out hitInfo, distance, mask)) //Will only run if the raycast hits something
        { 
            if (hitInfo.collider.GetComponent<Interactable>() != null) // Checking to see if game object has Interactable component
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>(); // if it does, store it in a variable
                playerUI.UpdateText(interactable.promptMessage); // Updating the on screen text
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
