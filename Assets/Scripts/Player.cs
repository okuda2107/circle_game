using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Gravity
{
    
    public enum Direct
    {
        Down,
        Up,
        Left,
        Right
    };

    public float mForce;
    public float maxSpeed;
    public float mBrake;

    public Gravity gravity;
    public Rigidbody2D rb = null;
    public Direct mDirect = Direct.Down;

    public void Move()
    {
        bool leftFlag = Input.GetKey(KeyCode.LeftArrow);
        bool rightFlag = Input.GetKey(KeyCode.RightArrow);
        bool upFlag = Input.GetKey(KeyCode.UpArrow);
        bool downFlag = Input.GetKey(KeyCode.DownArrow);


        if (mDirect == gravity.Direct.Down || gravity.mDirect == Direct.Up)
        {
            if (-maxSpeed < rb.velocity.x && rb.velocity.x < maxSpeed)
            {
                if (leftFlag && !rightFlag)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rb.AddForce(new Vector2(-mForce, 0.0f));
                }
                if (rightFlag && !leftFlag)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rb.AddForce(new Vector2(mForce, 0.0f));
                }
                if (!leftFlag && !rightFlag)
                {
                    float offset = rb.velocity.x;
                    offset *= mBrake;
                    rb.velocity = new Vector2(offset, rb.velocity.y);
                }
            }
        }
        else if (mDirect == gravity.Direct.Left || mDirect == gravity.Direct.Right)
        {
            if (-maxSpeed < rb.velocity.y && rb.velocity.y < maxSpeed)
            {
                if (upFlag && !downFlag)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rb.AddForce(new Vector2(0.0f, mForce));
                }
                if (downFlag && !upFlag)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rb.AddForce(new Vector2(0.0f, -mForce));
                }
                if (!upFlag && !downFlag)
                {
                    float offset = rb.velocity.y;
                    offset *= mBrake;
                    rb.velocity = new Vector2(rb.velocity.x, offset);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

