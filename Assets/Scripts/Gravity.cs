using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public void GravityForce() //èdóÕÇçÏópÇ≥ÇπÇÈä÷êî
    {
        switch (mDirect)
        {
            case Direct.Up:
                rb.AddForce(new Vector2(0.0f, gravity));
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
                break;
            case Direct.Down:
                rb.AddForce(new Vector2(0.0f, -gravity));
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
                break;
            case Direct.Left:
                rb.AddForce(new Vector2(-gravity, 0.0f));
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 270.0f));
                break;
            case Direct.Right:
                rb.AddForce(new Vector2(gravity, 0.0f));
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
