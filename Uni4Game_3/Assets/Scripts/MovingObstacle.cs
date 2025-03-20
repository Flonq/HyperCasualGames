using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveSpeed = 2f;          // Hareket hızı
    public float moveDistance = 3f;       // Hareket mesafesi
    public bool moveHorizontally = true;  // Yatay hareket için true

    private Vector3 startPosition;
    private bool movingForward;

    void Start()
    {
        startPosition = transform.position;
        movingForward = Random.value > 0.5f; // Rastgele başlangıç yönü
    }

    void Update()
    {
        float moveDirection = movingForward ? 1 : -1;
        Vector3 moveVector = moveHorizontally ? Vector3.forward : Vector3.right; // İleri geri için Vector3.forward

        transform.Translate(moveVector * moveSpeed * moveDirection * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingForward = !movingForward;
        }
    }
}