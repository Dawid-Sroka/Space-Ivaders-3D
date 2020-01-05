using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected int hitPoints, maxHP;
    public int HitPoints { get => hitPoints; }
    protected GameManager gameManager;
    public List<Weapon> weapons;
    protected int currentWeaponID;
    public virtual void Awake(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentWeaponID = 0;
    }
    public virtual void Shoot(){
        weapons[currentWeaponID].Shoot();
    }
    public virtual void TakeHit(int damage){
        hitPoints-= damage;
        Debug.Log(hitPoints + " hit points left");
        OnTakeHit();
        if(hitPoints <= 0){
            DestroySelf();
        }
    }
    public virtual void AddNewWeapon(string name){
        GameObject newWeapon = Instantiate(Resources.Load("Weapons/" + name + "Weapon"), transform) as GameObject;
        weapons.Add(newWeapon.GetComponent<Weapon>());
        //reloads.Add(0f);
    }
    protected virtual void OnTakeHit(){}
    protected virtual void DestroySelf(){
        Destroy(gameObject);
    }
}
