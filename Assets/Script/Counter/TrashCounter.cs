using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyObjectTrash;
    public override void Interact(Player player)
    {
        if (player.HasGetKitchenObject())
        {
            player.GetKitchenObject().DesstroySelf();
            OnAnyObjectTrash?.Invoke(this, EventArgs.Empty);
        }
    }
}
