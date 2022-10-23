using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBall : MonoBehaviour
{
  public float speed = 1.0f;
  private Rigidbody2D _rigidbody2D;
  private Vector2 _userinput;

  public void Move(InputAction.CallbackContext context)
  {
    _userinput = context.ReadValue<Vector2>();
  }


  void Awake()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Calling the Start method");
  }

  // Update is called once per frame
  // void Update()
  // {
  //   _userinput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
  // }

  void FixedUpdate()
  {
    _rigidbody2D.MovePosition(transform.position + new Vector3(_userinput.x, _userinput.y, 0) * speed * Time.deltaTime);
  }
}
