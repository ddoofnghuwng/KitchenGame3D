using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public static event EventHandler PlaceObjectHere;

    [SerializeField] private Transform counterTop;

    private KitchenObject kitchenObject;

    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter InteractAlternate");
    }
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter Interact");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTop;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            PlaceObjectHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject() { return kitchenObject; }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasGetKitchenObject() { return kitchenObject != null; }
}
