using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private List<Transform> _coinSpawnLocations = new List<Transform>();
    void Start()
    {
        foreach (Transform location in _coinSpawnLocations)
        {
            Instantiate(_coinPrefab, location.position, location.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
  }
