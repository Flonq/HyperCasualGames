using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectablePrefab;
    public float spawnInterval = 3f;
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float spawnDistance = 20f;

    private float timer;
    private Transform playerTransform;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isMoving) return; // Oyuncu hareket etmiyorsa spawn yapma

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCollectable();
            timer = 0f;
        }
    }

    void SpawnCollectable()
    {
        float randomX = Random.Range(-2.7f, 2.7f);
        Vector3 spawnPos = new Vector3(randomX, 0.5f, playerTransform.position.z + spawnDistance);

        Instantiate(collectablePrefab, spawnPos, Quaternion.identity);
    }
}
