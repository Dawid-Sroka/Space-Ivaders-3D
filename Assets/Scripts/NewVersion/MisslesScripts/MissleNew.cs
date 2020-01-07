using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissleNew : MonoBehaviour
{
    protected int damage;
    protected virtual void OnCollisionEnter(Collision other){
        switch(other.gameObject.tag){
            case "Enemy":
            {
                //EnemyHit();
                other.gameObject.GetComponent<Unit>().TakeHit(damage);
                break;
            }
            case "Player":
            {
                //PlayerHit();
                other.gameObject.GetComponent<Unit>().TakeHit(damage);
                break;
            }
            case "Shield":
            {
                //ShieldHit();
                Destroy(other.gameObject);
                break;
            }
            default:
            {
                //DefaultHit();
                break;
            }
        }
        DestroySelf();
    }
    protected virtual void DestroySelf(){
        Destroy(gameObject);
    }
    protected virtual void EnemyHit(){
        //other.gameObject.GetComponent<Unit>().TakeHit(damage);
    }
    protected virtual void PlayerHit(){
        //other.gameObject.GetComponent<Unit>().TakeHit(damage);
    }
    protected virtual void ShieldHit(){
        //Destroy(other.gameObject);
    }
    protected virtual void DefaultHit(){
        
    }
}
