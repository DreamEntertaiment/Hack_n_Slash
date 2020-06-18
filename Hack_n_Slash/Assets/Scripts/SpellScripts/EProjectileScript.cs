using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectileScript : MonoBehaviour
{
    [SerializeField] private GameObject explosionBox;
    private int _moveSpeed = 10;
    private Vector3 _movementVector3;
    private void Start()
    {
        _movementVector3 = Vector3.forward * _moveSpeed * Time.deltaTime;
        Destroy(this.gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(_movementVector3, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Instantiate(explosionBox, new Vector3(other.transform.position.x,2.5f,other.transform.position.z), other.transform.rotation);
        }
    }
}
