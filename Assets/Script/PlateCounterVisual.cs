using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVisualGameObject;

    private void Awake()
    {
        plateVisualGameObject = new List<GameObject>();
    }

    private void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateDestroyed += PlateCounter_OnPlateDestroyed;
    }

    

    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObject.Count, 0);
        
        plateVisualGameObject.Add(plateVisualTransform.gameObject);
    }

    private void PlateCounter_OnPlateDestroyed(object sender, System.EventArgs e)
    {
        GameObject plateObject = plateVisualGameObject[plateVisualGameObject.Count - 1];
        plateVisualGameObject.Remove(plateObject);
        Destroy(plateObject);
    }
}
