using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayWeapon : Weapon
{
    public override void Awake(){
        base.Awake();
        misslePrefab = Resources.Load("Missles/rayMissle") as GameObject;
        if(misslePrefab == null){Debug.Log("Missle not found");}
        ammo = 10;
        velocity = 2f;
    }
    public override void Shoot(){
        base.Shoot();
        newMissle = spawnMissle();
        newMissle.GetComponent<Rigidbody>().velocity = localForward*velocity;
    }
}
