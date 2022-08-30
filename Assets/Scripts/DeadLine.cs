using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public Player mPlayer;
    public Camera stageCamera;

    private bool isDeadline = false;
    private bool isDeadlineEnter, isDeadlineStay, isDeadlineExit;

    public bool IsDeadline()
{
   if(isDeadlineEnter || isDeadlineStay)
   {
      isDeadline = true;
   }
   else if(isDeadlineExit)
   {
      isDeadline = false;
   } 

   isDeadlineEnter = false;
   isDeadlineStay = false;
   isDeadlineExit = false;
   return isDeadline;
}

private void OnTriggerEnter2D(Collider2D collision)
{
   if (collision.tag == "Player")
   {
      GameObject.Destroy(stageCamera.GetComponent<CameraFollowTarget>());
      mPlayer.mState = Player.State.Dead;
   }
}
 
private void OnTriggerStay2D(Collider2D collision)
{
   if (collision.tag == "Player")
   {
      isDeadlineStay = true;
   }
}
     
private void OnTriggerExit2D(Collider2D collision)
{
   if (collision.tag == "Player")
   {
      isDeadlineExit = true;
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
/*

プレイヤーのオブジェクト取得
カメラの取得

isTriggerを使う
当たり判定が動いている間，カメラの動きをその時点で止めて，プレイヤーにDeadにする

*/