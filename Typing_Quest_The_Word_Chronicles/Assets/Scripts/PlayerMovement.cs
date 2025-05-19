using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float stopDistance;

    [Space]
    private Vector3 currentPosition;
    private bool isMove;
    private float speed = 4f;

    private void Update()
    {
        Move();   
    }
    public void Move()
    {
        CheckClickMouse();

        if(isMove)
        {
            rb.velocity = (currentPosition - transform.position).normalized * speed;
            CheckPosition();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }

    public void CheckClickMouse()
    {
        if(Input.GetMouseButton(1))
        {
            this.currentPosition = GetPositionMouse();
            this.isMove = true;
        }
    }
    public Vector3 GetPositionMouse()
    {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
    public void CheckPosition()
    {
        if (Vector3.Distance(transform.position, currentPosition) <= stopDistance)
        {
            this.isMove = false;
        }
    }
    public void CheckWall(Collider2D collider)
    {
        if(isMove)
        {
            this.isMove = false;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            this.CheckWall(collision);
        }
    }
}
