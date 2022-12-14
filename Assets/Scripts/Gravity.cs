using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [System.NonSerialized] public Rigidbody2D rb = null;
    public Direct mDirect = Direct.Down;
    public Tag mTag = Tag.capture;
    public float gravity = 25;

    public enum Direct
    {
        Down,
        Up,
        Left,
        Right
    };

    public enum Tag
    {
        capture, //自分でオンオフできる．オンの状態
        release, //自分でオンオフできる．オフの状態
    };

    public void GravityForce() //�d�͂���p������֐�
    {
        switch (mDirect)
        {
            case Direct.Up:
                rb.AddForce(new Vector2(0.0f, gravity));
                break;
            case Direct.Down:
                rb.AddForce(new Vector2(0.0f, -gravity));
                break;
            case Direct.Left:
                rb.AddForce(new Vector2(-gravity, 0.0f));
                break;
            case Direct.Right:
                rb.AddForce(new Vector2(gravity, 0.0f));
                break;
        }
    }

    protected Direct ChangeDirect()
    {
        if (mTag == Tag.capture)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f));
                return Direct.Left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
                return Direct.Right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
                return Direct.Up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
                return Direct.Down;
            }
            return mDirect;
        }
        else
        {
            return mDirect;
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
    }
}
