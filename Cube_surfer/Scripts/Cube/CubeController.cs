using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController heroStackController;
    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;


    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="cube")
        {
            if (!isStack)
            {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }
           
        } 
        if(other.gameObject.tag=="Obstacle")
        {
          heroStackController.DecreaseBlock(gameObject);
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
