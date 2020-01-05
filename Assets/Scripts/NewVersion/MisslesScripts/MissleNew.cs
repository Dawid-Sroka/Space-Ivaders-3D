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
                other.gameObject.GetComponent<Unit>().TakeHit(damage);
                Destroy(gameObject);
                break;
            }
            case "Player":
            {
                other.gameObject.GetComponent<Unit>().TakeHit(damage);
                Destroy(gameObject);
                break;
            }
            default:
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
