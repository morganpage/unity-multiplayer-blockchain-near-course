using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;

public class Health : NetworkBehaviour
{
  public int m_health;
  public int m_maxHealth = 100;

  [SerializeField] private Image m_healthBar;

  void Awake()
  {
    m_health = m_maxHealth;
  }

  public void UpdateHealth(int health)
  {
    m_health = health;
    m_healthBar.fillAmount = (float)m_health / m_maxHealth;
    ObserversUpdateHealth(m_health);
    if (m_health <= 0)
    {
      gameObject.SetActive(false);
    }
  }

  [ObserversRpc(BufferLast = true)]
  private void ObserversUpdateHealth(int health)
  {
    m_health = health;
    m_healthBar.fillAmount = (float)m_health / m_maxHealth;
    if (m_health <= 0)
    {
      gameObject.SetActive(false);
    }
  }




}
