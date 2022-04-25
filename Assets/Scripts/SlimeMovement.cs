using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform groundDetection;
    [SerializeField] private bool canJump = true;
    [SerializeField] private float timeBetweenJumps = 3f;
    [SerializeField] private bool edgeDetection = true;

    private bool movingRight = true;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private BoxCollider2D myBoxCollider;

    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpRoutine());
    }

    void Update()
    {
        Movement();

        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            myAnimator.SetBool ("isJumping", false);
        }
    }

    private void Movement() {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (edgeDetection == false) { return; }
        
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false) {
            if (movingRight == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private IEnumerator JumpRoutine () {
        while (canJump) {
            yield return new WaitForSeconds(timeBetweenJumps);
            Jump();
        }
    }

    private void Jump() {
        myAnimator.SetBool("isJumping", true);
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigidBody.velocity += jumpVelocityToAdd;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            myAnimator.SetTrigger("Land");
        }
    }
}