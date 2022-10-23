using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBall : MonoBehaviour
{
  public Vector2 jumpForce = new Vector2(0, 300);
  private bool _jump;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      _jump = true;
    }
  }
  void FixedUpdate()
  {
    if (_jump)
    {
      GetComponent<Rigidbody2D>().AddForce(jumpForce);
      _jump = false;
    }
  }
}
