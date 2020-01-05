using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : Unit
{
    UIManager uiManager; 
    List<float> reloads = new List<float>();
    override public void Awake(){
        base.Awake();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        AddNewWeapon("basic");
        AddNewWeapon("ray");
        maxHP = hitPoints;
        /*
        gameObject.AddComponent<BasicWeapon>();
        weapons.Add(gameObject.GetComponent<BasicWeapon>());
        gameObject.AddComponent<RayWeapon>();
        weapons.Add(gameObject.GetComponent<RayWeapon>());
        */
        //AddNewWeapon()
        
    }
    public void Update(){
        PlayerControl();
        
    }
    private void PlayerControl(){
        if(Input.GetKey(KeyCode.Space)){
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.E)){
            NextWeapon();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            PrevWeapon();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.localPosition+= Vector3.right*0.1f;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.localPosition+= Vector3.left*0.1f;
        }
    }
    override public void Shoot(){
        Weapon currentWeapon = weapons[currentWeaponID];
        if(currentWeapon.ammo > 0 && currentWeapon.ready){
            base.Shoot();
        }
    }
    override public void TakeHit(int damage){
        base.TakeHit(damage);
    }
    override protected void OnTakeHit(){
        uiManager.EmptyHitPoints();
    }
    override protected void DestroySelf(){
        //gameManager.GameOver();
        base.DestroySelf();
    }
    /* Functions considering adding new and regaining lost HPs
    public void RegainHP(int n){
        hitPoints = (hitPoints + n)%(maxHP + 1);
        uiManager.FillHitPoints();
    }
    public void GainHP(int n){
        maxHP+=n;
        hitPoints+=n;
        uiManager.AddNewHitPoints(n);
        uiManager.FillHitPoints();
    }
    */
    // Functions considering equiping (new) and choosing (available in 'weapons') weapons
    
    public override void AddNewWeapon(string name){
        //GameObject newWeapon = Instantiate(Resources.Load("Weapons/" + name + "Weapon"), transform) as GameObject;
        //weapons.Add(newWeapon.GetComponent<Weapon>());
        base.AddNewWeapon(name);
        reloads.Add(0f);
    }
    // choose next (in terms of index) weapon from 'weapons'
    public void NextWeapon(){
        currentWeaponID = (currentWeaponID + 1)%weapons.Count;
        Debug.Log("nextWeapon");
    }
    // choose previous weapon from 'weapons'
    public void PrevWeapon(){
        Debug.Log("previousWeapon");
        currentWeaponID = (currentWeaponID - 1)%weapons.Count;
    }
    // choose weapon on nth sloth from 'weapons'
    public void ChooseWeapon(int n){
        if(n >= 0 && n < weapons.Count) {
            currentWeaponID = n;
        }
    }

}

/* */
