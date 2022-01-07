using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInteractionController : MonoBehaviour
{
    private Camera playerCamera;

    //Interactables
    private Interactable interactable;
    private InteractableData interactableData;
    private Transform interactableTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInteractable();

        Interact();
    }

    private void DetectInteractable()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();


        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Interactable")
            {
                if(interactable == null || interactableTransform != hit.transform)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    interactableTransform = hit.transform;
                    interactableData = interactable.InteractableData;
                }
            }
        }
        else
        {
            interactable = null;
            interactableTransform = null;
            interactableData = null;
        }
    }

    private void Interact()
    {
        if (interactable == null)
            return;

        if(interactableData.requiresTool)
        {
            if (!GlobalManager.playerInventoryManager.PlayerInventoryContainsTool(interactableData.requiredTool))
            {
                return;
            }
                
        }

        if(Input.GetMouseButtonDown(0))
        {
            interactable.OnPlayerInteract();
        }
    }

    
}
