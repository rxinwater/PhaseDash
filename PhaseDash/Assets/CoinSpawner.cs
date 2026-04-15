using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        float startX = 9.0f;
        float y = -5.23f;
        float spacing = 2.0f;
        int amount = 5;

        for (int i = 0; i < amount; i++)
        {
            float x = startX + (i * spacing);
            Vector3 spawnPos = new Vector3(x, y, 0f);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}