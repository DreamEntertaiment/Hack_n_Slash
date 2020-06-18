using System;
using UnityEngine;

public class LmbProjectileScript : MonoBehaviour
{
    private int _moveSpeed = 30;
    private Vector3 _movementVector3;
    private void Start()
    {
        _movementVector3 = Vector3.forward * _moveSpeed * Time.deltaTime;
        Destroy(this.gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(_movementVector3,Space.Self);
    }

   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Enemy"))
       {
           Destroy(this.gameObject);
       }
   }
}
