using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon
{
    public override void Awake(){
        base.Awake();
        misslePrefab = Resources.Load("Missles/basicMissle") as GameObject;
        if(misslePrefab == null){Debug.Log("Missle not found");}
        //velocity = 4.5f;
        ammo = int.MaxValue;
    }
    public override void Shoot(){
        base.Shoot();
        newMissle = spawnMissle();
        newMissle.GetComponent<Rigidbody>().velocity = localForward*velocity;
    }
}
