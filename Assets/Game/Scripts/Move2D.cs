using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FishNet.Object;
using FishNet.Connection;
using FishNet.Component.Animating;

public class Move2D : NetworkBehaviour
{
  public float m_speed = 1.0f;
  private Rigidbody2D _rigidbody2D;
  private Animator _animator;
  private NetworkAnimator _networkAnimator;
  private Vector2 _userinput;
  private bool _flipped;
  [SerializeField] private Transform m_main;

  void Awake()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _animator = GetComponentInChildren<Animator>();
    _networkAnimator = GetComponentInChildren<NetworkAnimator>();
  }

  public override void OnOwnershipClient(NetworkConnection prevOwner)
  {
    base.OnOwnershipClient(prevOwner);
    GetComponent<PlayerInput>().enabled = base.IsOwner;
  }

  public void Attack(InputAction.CallbackContext context)
  {
    if (!base.IsOwner) return;
    if (context.started)
    {
      _networkAnimator.SetTrigger("attack");
    }
    if (context.canceled)
    {
      _networkAnimator.ResetTrigger("attack");
    }
  }

  public void Move(InputAction.CallbackContext context)
  {
    if (!base.IsOwner) return;
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
    m_main.localScale = new Vector3(_flipped ? -1 : 1, 1, 1);
  }

  void FixedUpdate()
  {
    if (!base.IsOwner) return;
    _rigidbody2D.MovePosition(_rigidbody2D.position + _userinput * Time.fixedDeltaTime * m_speed);
  }
}
