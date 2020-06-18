using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSpellScript : MonoBehaviour
{
    [SerializeField] private GameObject rExplosionZone;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(rExplosionZone, new Vector3(other.transform.position.x, 5, other.transform.position.z),
            Quaternion.identity);
        Destroy(this.gameObject);
    }
}
