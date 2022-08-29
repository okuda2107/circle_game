using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Gravity
{
    private bool pushFlag = false;
    public float mForce;
    public float maxSpeed;
    public float mBrake;
    public GroundTrigger ground;
    
    [System.NonSerialized] public int mLife = 5;

    public enum State
    {
        Alive,
        Dead
    };

    public void Move()
    {
        bool leftFlag = Input.GetKey(KeyCode.A);
        bool rightFlag = Input.GetKey(KeyCode.D);
        bool upFlag = Input.GetKey(KeyCode.W);
        bool downFlag = Input.GetKey(KeyCode.S);

        if (mDirect == Gravity.Direct.Down || mDirect == Gravity.Direct.Up)
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
        else if (mDirect == Gravity.Direct.Left || mDirect == Gravity.Direct.Right)
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

    private void GravityChange()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if ((!pushFlag) && ground.IsGround())
            {
                pushFlag = true;
                mDirect = ChangeDirect();
            }
        }
        else
        {
            pushFlag = false;
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
        GravityForce();
        Move();
        if (Input.GetKey(KeyCode.LeftShift) && ground.IsGround())
        {
            mDirect = ChangeDirect();
        }
        Debug.Log(mDirect);
    }
}

