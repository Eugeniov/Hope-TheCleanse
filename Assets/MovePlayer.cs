using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public Camera playercamera;
    [SerializeField]
    private bool IsGrounded = false;

    [SerializeField]
    private BoxCollider2D boxCollider2d;
    
    [SerializeField]
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetBool("Start", true);

        if(IsGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 10.0f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            Debug.Log("Jump");
            IsGrounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "plateform")
        {
            IsGrounded = true;
            Debug.Log("IsGrounded");
        }
    }
}
