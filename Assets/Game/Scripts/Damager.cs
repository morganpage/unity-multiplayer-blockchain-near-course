using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class Damager : NetworkBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (!base.IsOwner) return;
    if (other.tag != "Player") return;
    Health health = other.GetComponent<Health>();
    if (health != null)
    {
      ServerDamager(health);
    }
  }

  [ServerRpc]
  private void ServerDamager(Health opponentsHealth)
  {
    opponentsHealth.UpdateHealth(opponentsHealth.m_health - 10);
  }

}
