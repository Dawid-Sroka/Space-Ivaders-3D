using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : EnemyNew
{
    string weaponReward;
    GameObject player;

    public override void Awake(){
        base.Awake();
        player = GameObject.FindWithTag("Player");
    }
}
