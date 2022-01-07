using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected InteractableData interactableData;
    public InteractableData InteractableData { get { return interactableData; } }

    protected virtual void Start()
    {
        this.gameObject.tag = "Interactable";
    }

    public virtual void OnPlayerInteract()
    {

    }

    protected virtual void SpawnItemsOnDestruction()
    {

    }
}
