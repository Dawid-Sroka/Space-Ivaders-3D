using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNew : Unit
{
    protected int pointsValue, creditsValue;
    override public void Awake(){
        base.Awake();
    }
    override public void Shoot(){
        base.Shoot();
    }
    override public void TakeHit(int damage){
        base.TakeHit(damage);
        Debug.Log("U've struck an enemy!");
    }
    override protected void OnTakeHit(){
        base.OnTakeHit();
    }
    override public void DestroySelf(){
        gameManager.UpdateScore(pointsValue);
        gameManager.UpdateCredits(creditsValue);

        base.DestroySelf();
        //gameManager.UpdateScore(pointsValue);
    }
}
