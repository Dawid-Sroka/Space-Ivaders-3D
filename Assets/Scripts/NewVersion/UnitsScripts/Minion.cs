using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : EnemyNew
{
    protected abstract IEnumerator movementPattern();
    protected abstract IEnumerator shootingPattern();
    protected string weapon;
    public override void Awake(){
        base.Awake();
        AddNewWeapon(weapon);
        StartCoroutine("movementPattern");
        StartCoroutine("shootingPattern");
    }
}
