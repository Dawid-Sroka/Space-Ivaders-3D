using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject misslePrefab, newMissle, wielder;
    protected Transform wielderT;
    protected Sprite weaponSpriteUI;
    public int ammo;
    public bool ready;
    [SerializeField]
    protected float velocity, reloadTime, castTime;
    protected Vector3 localForward;
    protected string missleTag;

    public virtual void Awake(){
        wielderT = transform.parent;
        wielder = wielderT.gameObject;
        localForward = Quaternion.AngleAxis(wielderT.eulerAngles.y, Vector3.up) * Vector3.forward;
        missleTag = wielder.tag + "Missle"; //e.g. "EnemyMissle"/"PlayerMissle"
        ready = true;
        //Debug.Log(localForward);
    }
    public virtual void Shoot(){
        if(ammo!= int.MaxValue){
            ammo--;
        }
        StartCoroutine("Reload");
        //Debug.Log("U've got " + ammo + " missles left");
    }
    protected virtual GameObject spawnMissle(){
        newMissle = Instantiate(misslePrefab, wielderT.position, Quaternion.identity) as GameObject;
        Physics.IgnoreCollision(newMissle.GetComponent<Collider>(), wielder.GetComponent<Collider>());
        //Może być lepiej zrobić po 1 prefabie dla pocisku gracza/przeciwnika
        newMissle.tag = missleTag;
        newMissle.layer = missleTag == "PlayerMissle" ? 11 : 12;
        //where Layer11: PlayerMissles, Layer12: EnemyMissles
        return newMissle;
    }
    protected virtual IEnumerator Reload(){
        ready = false;
        //Debug.Log("Now u can't shoot!");
        yield return new WaitForSeconds(reloadTime);
        ready = true;
        //Debug.Log("Now u can shoot again!");
    }
}
