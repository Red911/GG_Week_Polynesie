using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerzer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    Vector2 moveValue;
    public  void Move(Vector2 value)
    {
        moveValue  = value * Time.deltaTime * speed;
    }

    public void Shoot()
    {
      
            GameObject.Instantiate(bullet, transform.position, transform.rotation);
        
    }

    private void Update()
    {
        transform.Translate(moveValue); 
    }

}
