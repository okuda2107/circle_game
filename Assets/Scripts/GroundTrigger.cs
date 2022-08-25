using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{

private string groundTag = "Ground";
private bool isGround = false;
private bool isDamageGround = false;
private bool isGroundEnter, isGroundStay, isGroundExit;
private bool isDamageGroundEnter, isDamageGroundStay, isDamageGroundExit;

//接地判定を返すメソッド
//物理判定の更新毎に呼ぶ必要がある
public bool IsGround()
{
   if(isGroundEnter || isGroundStay)
   {
      isGround = true;
   }
   else if(isGroundExit)
   {
      isGround = false;
   } 

   isGroundEnter = false;
   isGroundStay = false;
   isGroundExit = false;
   return isGround; 
}

public bool IsDamageGround()
{
   if(isDamageGroundEnter || isDamageGroundStay)
   {
      isDamageGround = true;
   }
   else if(isDamageGroundExit)
   {
      isDamageGround = false;
   } 

   isDamageGroundEnter = false;
   isDamageGroundStay = false;
   isDamageGroundExit = false;
   return isDamageGround; 
}
 
private void OnTriggerEnter2D(Collider2D collision)
{
   switch (collision.tag)
   {
      case "Ground":
      isGroundEnter = true;
      break;

      case "DamageGround":
      isDamageGroundEnter = true;
      break;
   }
}
 
private void OnTriggerStay2D(Collider2D collision)
{
   switch (collision.tag)
   {
      case "Ground":
      isGroundStay = true;
      break;

      case "DamageGround":
      isDamageGroundStay = true;
      break;
   }
}
     
private void OnTriggerExit2D(Collider2D collision)
{
   switch (collision.tag)
   {
      case "Ground":
      isGroundExit = true;
      break;

      case "DamageGround":
      isDamageGroundExit = true;
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
