using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float forwardSpeed = 5f;        // İleri hareket hızı
    public float horizontalSpeed = 5f;     // Yatay hareket hızı
    public float horizontalLimit = 3f;   // Yatay hareket sınırı
    
    public bool isMoving = false;         // Hareket durumu
    private float horizontalInput = 0f;    // Yatay girdi değeri

    void Update()
    {
        // Fare tıklaması ile hareketi başlat
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
        }

        // Yön tuşları kontrolü
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Hareket
        if (isMoving)
        {
            // İleri hareket
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            
            // Yatay hareket
            float newX = transform.position.x + (horizontalInput * horizontalSpeed * Time.deltaTime);
            newX = Mathf.Clamp(newX, -horizontalLimit, horizontalLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(-1);
        }
    }

    void GameOver()
    {
        isMoving = false;
        // Burada oyun bitiş fonksiyonlarını çağırabilirsiniz
        Debug.Log("Oyun Bitti!");
    }
}