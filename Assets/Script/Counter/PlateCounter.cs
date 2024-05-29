using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlateCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateDestroyed;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 3f;
    private int spawnPlateAmount;
    private int spawnPlateAmountMax = 5;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0;

            if (spawnPlateAmount < spawnPlateAmountMax)
            {
                spawnPlateAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasGetKitchenObject())
        {
            if(spawnPlateAmount > 0)
            {
                spawnPlateAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateDestroyed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
