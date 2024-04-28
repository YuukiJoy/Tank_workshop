using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI life;
    private string defaultLife = "oooo";
    private int actualLife = 4;
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Damage(1);
        }
        
        if (other.CompareTag("Spike"))
        {
            Damage(1);
        }

        if (other.CompareTag("Mine"))
        {
            Instantiate(explosion, other.transform.position + new Vector3(0, 2, 0), quaternion.identity);
            Destroy(other.gameObject);
            Damage(2);
        }

        if (other.CompareTag("Life"))
        {
            Destroy(other.gameObject);
            Damage(-1);
        }
    }

    public void Damage(int damage)
    {
        actualLife = Mathf.Clamp(actualLife - damage, 0, 4);
        life.text = defaultLife.Substring(0, actualLife);
        if (actualLife < 1)
        {
            Destroy(gameObject);
        }
    }
}
