using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManegerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemple;

    private void Awake()
    {
        recipeTemple.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManage.Instance.OnRecipeSpawned += DeliveryManage_OnRecipeSpawned;
        DeliveryManage.Instance.OnRecipeCompleted += DeliveryManage_OnRecipeCompleted;

        UpdateVisual();
    }

    private void DeliveryManage_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManage_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if(child == recipeTemple)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        foreach (RecipeSO recipeSO in DeliveryManage.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform  = Instantiate(recipeTemple,container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);
        }
    }
}
