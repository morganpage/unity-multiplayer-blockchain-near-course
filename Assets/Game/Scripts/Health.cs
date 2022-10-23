using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  public int m_health;
  public int m_maxHealth = 100;

  [SerializeField] private Image m_healthBar;

  void Awake()
  {
    m_health = m_maxHealth;
  }

  [ContextMenu("Take Damage")]
  public void TestTakeDamage()
  {
    TakeDamage(10);
  }

  public void TakeDamage(int damage)
  {
    m_health -= damage;
    m_healthBar.fillAmount = (float)m_health / m_maxHealth;
    if (m_health <= 0)
    {
      gameObject.SetActive(false);
    }
  }
}
