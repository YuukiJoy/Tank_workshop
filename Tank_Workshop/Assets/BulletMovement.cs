using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destroyable destroyable))
        {
            GameObject g = Instantiate(destroyable.destroyEffect, other.transform.position + destroyable.effectPosOffset, quaternion.identity);
            g.transform.localScale = destroyable.effectSize;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
