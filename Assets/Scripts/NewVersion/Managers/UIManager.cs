using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<GameObject> weaponSlots = new List<GameObject>();
    List<GameObject> hitPoints = new List<GameObject>();
    [SerializeField]
    List<GameObject> screenBreaks = new List<GameObject>();
    [SerializeField]
    TextMeshProUGUI waveNr, score, credits, timeToNextWave;
    [SerializeField]
    GameObject pauseMenu, gameOverScreen, UICanvas, hitPointPrefab, weaponSlot;
    Sprite fullHitPoint, emptyHitPoint;

    PlayerNew player;
    
    void Awake(){
        player = GameObject.FindWithTag("Player").GetComponent<PlayerNew>();
        UICanvas = GameObject.Find("UICanvas");
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        credits = UICanvas.transform.Find("Credits").GetComponent<TextMeshProUGUI>();
        waveNr = UICanvas.transform.Find("Wave nr").GetComponent<TextMeshProUGUI>();
        timeToNextWave = UICanvas.transform.Find("TimeToNextWave").GetComponent<TextMeshProUGUI>();


        hitPointPrefab = Resources.Load("UI/hitPoint") as GameObject;
        fullHitPoint = Resources.Load<Sprite>("Sprites/fullHitPoint");
        emptyHitPoint = Resources.Load<Sprite>("Sprites/emptyHitPoint") as Sprite;   
        //weaponSlot = Resources.Load("UI/weaponSlot") as GameObject;
        //Debug.Log(player.HitPoints);
        AddNewHitPoints(player.HitPoints);

    }
    public void GameOver(){
        gameOverScreen.SetActive(true);
    }
    public IEnumerator AnimateReload(int index){
        float reload = player.weapons[index].reloadTime;
        float timeLeft = reload;
        Image currentWeaponSlot = weaponSlots[index].GetComponent<Image>();
        currentWeaponSlot.fillAmount = 1f;
        do{
            yield return new WaitForEndOfFrame();
            timeLeft-= Time.deltaTime;
            currentWeaponSlot.fillAmount = timeLeft/reload;
        }
        while(timeLeft > 0f);
    }
    public void Countdown(int time){
        IEnumerator coroutine = CountdownIE(time);
        StartCoroutine(coroutine);
    }
    private IEnumerator CountdownIE(int time){
        while(time >= 0){
            timeToNextWave.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1f);
        }
    }
    public void AddNewHitPoints(int amount){
        for(int i = hitPoints.Count; i < amount; i++){
            //Debug.Log("Loop " + i);
            GameObject newHitPoint = Instantiate(hitPointPrefab, UICanvas.transform);
            newHitPoint.transform.position -= new Vector3(75*i, 0, 0);
            hitPoints.Add(newHitPoint);
        }
    }
    public void FillHitPoints(){
        for(int i = 0; i < player.HitPoints; i++){
            hitPoints[i].GetComponent<Image>().sprite = fullHitPoint;
            screenBreaks[i].SetActive(false);
        }
    }
    public void EmptyHitPoints(){
        for(int i = player.HitPoints; i < hitPoints.Count; i++){
            hitPoints[i].GetComponent<Image>().sprite = emptyHitPoint;
            screenBreaks[i].SetActive(true);
        }
    }
    public void UpdateScore(int n){
        score.text = "Score: " + n;
    }
    public void UpdateCredits(int n){
        credits.text = "Credits: " + n;
    }
    public void UpdateWaveNr(int n){
        waveNr.text = n.ToString();
    }



}
