using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag != "Player") return;
    Health health = other.GetComponent<Health>();
    if (health != null)
    {
      health.TakeDamage(10);
    }
  }
}
