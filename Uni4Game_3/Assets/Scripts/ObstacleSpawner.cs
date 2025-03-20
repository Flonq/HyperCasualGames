using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject horizontalObstaclePrefab;
    public GameObject verticalObstaclePrefab;
    public float spawnInterval = 2f;
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float spawnDistance = 20f;

    private float timer;
    private Transform playerTransform;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!playerMovement.isMoving) return; // Oyuncu hareket etmiyorsa spawn yapma

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, 0.5f, playerTransform.position.z + spawnDistance);

        GameObject prefabToSpawn;
        Quaternion rotation;

        if (Random.value > 0.5f)
        {
            prefabToSpawn = horizontalObstaclePrefab;
            rotation = Quaternion.Euler(0, 0, 90); // Yatay engel için rotasyon
            spawnPos.x = Random.Range(-2.7f, 2.7f); // X konumunu rastgele ayarla
        }
        else
        {
            prefabToSpawn = verticalObstaclePrefab;
            rotation = Quaternion.Euler(90, 0, 0); // Dikey engel için rotasyon
        }

        Instantiate(prefabToSpawn, spawnPos, rotation);
    }
}