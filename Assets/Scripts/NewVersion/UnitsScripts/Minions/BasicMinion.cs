using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMinion : Minion
{
    [SerializeField]
    private float reloadTimeRange, stepTime, moveDist;
    protected override IEnumerator movementPattern(){
        //int stepNr = 0;
        while(true){
            transform.position = transform.position - moveDist*Vector3.forward;
            yield return new WaitForSeconds(stepTime);
        }
    }
    protected override IEnumerator shootingPattern(){
        while(true){
            float reload = Random.Range(1f, reloadTimeRange);
            yield return new WaitForSeconds(reload);
            Shoot();
        }
    }
    public override void Awake(){
        weapon = "basic";
        pointsValue = 1;
        creditsValue = 0;
        base.Awake();
    }
}
