using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private int numJumps;
    [Header("Movements")]
    [SerializeField] private float xMovement;
    [SerializeField] private float xDuration;

    private new Rigidbody2D rigidbody2D;
    //private Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rightMove = rigidbody2D.position + new Vector2(xMovement, 0f);
        Vector2 leftMove = rigidbody2D.position + new Vector2(-xMovement, 0f);
        Vector2 jumpValue = rigidbody2D.position + new Vector2(0f, xMovement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.DOJump(jumpValue, jumpPower, numJumps, jumpDuration);
        }

        if (Input.GetKeyDown(KeyCode.D) || 
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody2D.DOMove(rightMove, xDuration);
        }
        if (
            Input.GetKeyDown(KeyCode.A) || 
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A) 
            )
        {
            rigidbody2D.DOMove(leftMove, xDuration);
        }
    }
}
