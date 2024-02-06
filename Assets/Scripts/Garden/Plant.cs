using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Plant : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp }
    public enum PlantType { Static, Planted }
    [Header("Attributes")]
    public InteractionType InteractType;
    public PlantType Type;
    [Header("Custom EVents")]
    public UnityEvent CustomEvent;
    public UnityEvent ConsumeEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    public void Interact()
    {
        switch (InteractType)
        {
            case InteractionType.PickUp:
               FindObjectOfType<GardenPlacement>().PickUp(gameObject);
                Destroy(gameObject);
                break;
            default:
                Debug.Log("NO ITEM");
                break;

        }
        CustomEvent.Invoke();
    }
}
