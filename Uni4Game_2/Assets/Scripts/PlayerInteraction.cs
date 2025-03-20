using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    private GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        manager.score = 0;
    }
    void Update()
    {
        
    }
    
}
