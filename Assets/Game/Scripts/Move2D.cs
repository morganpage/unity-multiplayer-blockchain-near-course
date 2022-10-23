using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move2D : MonoBehaviour
{
  public float m_speed = 1.0f;
  private Rigidbody2D _rigidbody2D;
  private Animator _animator;
  private Vector2 _userinput;
  private bool _flipped;

  void Awake()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _animator = GetComponent<Animator>();
  }

  public void Attack(InputAction.CallbackContext context)
  {
    if (context.started)
    {
      _animator.SetTrigger("attack");
    }
    if (context.canceled)
    {
      _animator.ResetTrigger("attack");
    }
  }

  public void Move(InputAction.CallbackContext context)
  {
    _userinput = context.ReadValue<Vector2>();
    _animator.SetFloat("speed", _userinput.magnitude);
    if (_userinput.x < 0 && !_flipped)
    {
      _flipped = true;
    }
    else if (_userinput.x > 0 && _flipped)
    {
      _flipped = false;
    }
    transform.localScale = new Vector3(_flipped ? -1 : 1, 1, 1);
  }

  void FixedUpdate()
  {
    _rigidbody2D.MovePosition(_rigidbody2D.position + _userinput * Time.fixedDeltaTime * m_speed);
  }
}
