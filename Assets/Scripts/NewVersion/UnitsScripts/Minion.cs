using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : EnemyNew
{
    protected abstract IEnumerator movementPattern();
    protected abstract IEnumerator shootingPattern();
    protected string weapon;
    public GameObject deathAnimation;
    public override void Awake(){
        base.Awake();
        AddNewWeapon(weapon);
        StartCoroutine("movementPattern");
        StartCoroutine("shootingPattern");
    }
    public override void DestroySelf(){
        Instantiate(deathAnimation, transform.position, transform.rotation);
        base.DestroySelf();
    }
}
