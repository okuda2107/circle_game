using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMonoDirect : MonoBehaviour
{

    public List<Gravity> scopeActors = new List<Gravity>();
    public Gravity.Direct mMonoDirect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ofs = collision.GetComponent<Gravity>();
        scopeActors.Add(ofs);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach(var obj in scopeActors)
        {
            //obj.mTag = Gravity.Tag.release;?
            obj.mDirect = mMonoDirect;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var ofs = collision.GetComponent<Gravity>();
        scopeActors.Remove(ofs);
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

範囲内に入ったら動的配列に保持
範囲内のオブジェクトのmDirectとmTagを制御
範囲から出るときに動的配列から削除　mTagをcaptureにする？　<-必ずしもcaptureとは限らない

*/