using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // Takip edilecek hedef (Player)
    public Vector3 offset = new Vector3(0, 2, -5);  // Kamera offset değeri
    public float smoothSpeed = 5f;     // Kamera takip yumuşaklığı

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Hedefin pozisyonu + offset değeri
        Vector3 desiredPosition = target.position + offset;
        
        // Yumuşak geçiş için Lerp kullanımı
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Kameranın pozisyonunu güncelle
        transform.position = smoothedPosition;
        
        // Kameranın hedefi sürekli izlemesi için
        transform.LookAt(target);
    }
}
