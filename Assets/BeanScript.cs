using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanScript : MonoBehaviour
{
  public float speed = 10.0f;
  public float jumpForce = 2.0f;
  private Rigidbody rigidBody;
  private CapsuleCollider capsuleCollider;
  private float distToGround;
  private bool grounded
  {
    get
    {
      print("Grounded");
      return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
  }
  private Vector3 startPosition;
  // Start is called before the first frame update
  void Start()
  {
    startPosition = transform.position;
    rigidBody = GetComponent<Rigidbody>();
    capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    distToGround = capsuleCollider.bounds.extents.y;
    
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.S))
    {
      transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.A))
    {
      transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.D))
    {
      transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    if (Input.GetKey(KeyCode.Space) && grounded)
    {
      rigidBody.velocity = Vector3.up * jumpForce;
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.gameObject.name == "Lava")
    {
      transform.position = startPosition;
    }
  }
}