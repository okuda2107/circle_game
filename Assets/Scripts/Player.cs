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
    public MoveGround mground;
    
    [System.NonSerialized] public int mLife = 5;
    public int mTileDamage;

    public mActors actors;

    public enum State
    {
        Alive,
        Dead
    };
    
    [System.NonSerialized] public State mState = State.Alive;

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
    //DamageGround�̃_���[�W����
    private void TileDamage()
    {
        mLife -= mTileDamage;
        if(mLife == 0)
        {
            mState = State.Dead;
        }
    }

    private AddMoveForce()
    {
        transform.localScale = new Vector3(mground.floorDirection, 1, 1);
        rb.AddForce(new Vector2(mground.floorForce * floorDirection, 0.0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Sate�̏������
        mState = State.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        GravityForce();
        Move();
        if (Input.GetKey(KeyCode.LeftShift) && (ground.IsGround() || ground.IsObject()))
        {
            mDirect = ChangeDirect();
            foreach (var obj in actors.actors)
            {
                obj.mDirect = ChangeDirect();
            }
        }
        Debug.Log(mDirect);

        if (ground.IsDamageGround())
        {
            TileDamage();
        }
        Debug.Log(mLife);
    
        if (mState == State.Dead)
        {
            Debug.Log("Player dead.");
        }
        else if(mState == State.Alive)
        {
            Debug.Log("Player Alive.");
        }
        else
        {
            Debug.Log("Eror");
        }

        if (ground.IsMoveGround())
        {
            AddMoveForce();
        }
    }
}

