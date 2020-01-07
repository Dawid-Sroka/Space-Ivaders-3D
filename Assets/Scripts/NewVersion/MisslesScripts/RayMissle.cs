using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMissle : MissleNew
{
    void Awake(){
        damage = 2;
    }
    protected override void DestroySelf(){
        IEnumerator coroutine = DestroySelfIE(0.2f);
        StartCoroutine(coroutine);
    }
    IEnumerator DestroySelfIE(float time){
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
