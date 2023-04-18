using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanScript : MonoBehaviour
{
    public float speed = 0.0000000000000000000000000000000001f;
    public Vector3 velocity = new Vector3();
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
        rigidBody = GetComponentInChildren<Rigidbody>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        distToGround = capsuleCollider.bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {
        float childRotY = Mathf.Deg2Rad * transform.GetChild(1).eulerAngles.y;
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(Mathf.Sin(childRotY), 0, Mathf.Cos(childRotY)) * Time.deltaTime * speed;
            transform.Translate(velocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-new Vector3(Mathf.Sin(childRotY), 0, Mathf.Cos(childRotY)) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-new Vector3(Mathf.Cos(childRotY), 0, -Mathf.Sin(childRotY)) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(Mathf.Cos(childRotY), 0, -Mathf.Sin(childRotY)) * Time.deltaTime * speed);
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
