using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [System.NonSerialized] public Rigidbody2D rb = null;
    public float floorSpeed;
    public float moveDistance;
    public float floorMaxSpeed;
    public float floorForce;
    private int floorDirection;

    // Start is called before the first frame update
    void Start()
    {
        floorDirection = 1;
        Vector2 firstPosi = this.transform.position;
        Debug.Log("x= " + firstPosi.x);
        Debug.Log("y= " + firstPosi.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 firstPosi;
        Vector2 posi = this.transform.position;
        if(0.0f < (posi.x - firstPosi.x) && (posi.x - firstPosi.x) < moveDistance)
        {
            if(-floorMaxSpeed <= rb.velocity.x && rb.velocity.x <= floorMaxSpeed)
            {
                transform.localScale = new Vector3(floorDirection, 1, 1);
                rb.AddForce(new Vector2(floorForce*floorDirection, 0.0f));
            }

        }
        else
        {
            if(floorDirection == 1)
            {
                posi = new Vector2(firstPosi.x + moveDistance, firstPosi.y);
                this.transform.position = posi;
            }
            else if(floorDirection == -1)
            {
                posi = new Vector2(firstPosi.x, firstPosi.y);
                this.transform.position = posi;
            }
            floorDirection *= -1;

        }
    }
}