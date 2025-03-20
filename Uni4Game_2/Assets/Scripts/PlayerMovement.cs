using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed, rotationSpeed;
    public FloatingJoystick joystick;
    public Animator animator;
    public Material defaultMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    private Renderer characterRenderer;
    private GameManager manager;
    void Start()
    {
        characterRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        characterRenderer.material = defaultMaterial;
        manager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        Vector3 direction = Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical;
        transform.position += direction * speed * Time.deltaTime;
        if (direction.magnitude > 0.1f) 
        {
            animator.SetBool("isWalking", true);
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Green Table") && transform.childCount < 2)
        {
            Transform item = other.transform.GetChild(Random.Range(0, other.transform.childCount));
            item.SetParent(transform);
            Vector3 itemPosition = transform.position + transform.forward * 2f + Vector3.up * 5f;
            item.position = itemPosition;

            if (item.CompareTag("Red Collectable"))
            {
                characterRenderer.material = redMaterial;
            }
            else if (item.CompareTag("Blue Collectable"))
            {
                characterRenderer.material = blueMaterial;
            }
        }
        if ((other.CompareTag("Red Table") || other.CompareTag("Blue Table")) && transform.childCount == 2)
        {
            Transform item = transform.GetChild(1);
            BoxCollider tableCollider = other.GetComponent<BoxCollider>();
            if (tableCollider != null)
            {
                float randomX = Random.Range(tableCollider.bounds.min.x, tableCollider.bounds.max.x);
                float randomZ = Random.Range(tableCollider.bounds.min.z, tableCollider.bounds.max.z);
                float itemYPosition = tableCollider.bounds.max.y;
                item.position = new Vector3(randomX, itemYPosition, randomZ);
            }
            item.SetParent(other.transform);

            if (other.CompareTag("Red Table") && item.CompareTag("Red Collectable"))
            {
                manager.UpdateScore(10);
            }
            else if (other.CompareTag("Blue Table") && item.CompareTag("Blue Collectable"))
            {
                manager.UpdateScore(5);
            }
            else
            {
                manager.IncreaseWrongAttempts();
            }

            characterRenderer.material = defaultMaterial;
        }
    }
}
