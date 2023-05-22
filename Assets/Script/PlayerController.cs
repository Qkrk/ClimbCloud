using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public float jumpForce = 200f;
    public float Speed = 20;

    public float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //점프한다.
        if (Input.GetKey(KeyCode.W) &&
            this.rigid2D.velocity.y == 0)
        {
            animator.SetBool("isJumping", true);
        }

        if (rigid2D.velocity.y < 0)
        {
            Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }


        //좌우이동
        if (Input.GetKey(KeyCode.D))
        {
            rigid2D.velocity = new Vector2((Speed * 1), this.rigid2D.velocity.y);
            transform.localScale = new Vector3(1, 1 , 1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid2D.velocity = new Vector2((Speed * -1), this.rigid2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isWalking", true);
        }else
        {
            animator.SetBool("isWalking", false);
        }

        if(this.transform.localPosition.y < -10)
        {
            SceneManager.LoadScene("FailScene");
        }
    }

    public void Jump()
    {
        this.rigid2D.AddForce(transform.up * this.jumpForce);
    }
}
