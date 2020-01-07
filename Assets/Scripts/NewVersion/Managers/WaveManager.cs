using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    UIManager uiManager;
    public Dictionary<char, GameObject> minions = new Dictionary<char, GameObject>();
    public List<WaveData> waves = new List<WaveData>();
    [SerializeField]
    private Vector3 spawnOffset;
    [SerializeField]
    Transform initialSpawnPosition;
    [SerializeField]
    private float minionOffset;
    private int currentWave;
    [SerializeField]

    public void Awake(){
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        currentWave = 0;
        spawnOffset = Vector3.zero;
        initialSpawnPosition = GameObject.Find("SpawnPosition").GetComponent<Transform>();
        minions.Add('B', Resources.Load<GameObject>("Units/Minions/BasicMinion"));
        minions.Add('S', Resources.Load<GameObject>("Units/Minions/ShieldedMinion"));
        SpawnWave();
    }
    public void SpawnWave(){
        WaveData currentWaveData = waves[currentWave];
        uiManager.UpdateWaveNr(currentWave + 1);
        StartCoroutine(NextWaveIE(currentWaveData.timeToNextWave));
        string enemiesPlacement = currentWaveData.enemiesPlacement;
        for(int i = 0; i < enemiesPlacement.Length; i++){
            char currentSpawn = enemiesPlacement[i];
            switch(currentSpawn){
                case '-':
                    break;
                case '|':
                    spawnOffset = new Vector3(0f, 0f, spawnOffset.z - minionOffset);
                    break;
                default:
                    //Debug.Log(currentSpawn);
                    SpawnMinion(minions[currentSpawn], spawnOffset);
                    break;
            }
            spawnOffset += Vector3.right*minionOffset;
        }
        spawnOffset = Vector3.zero;
        currentWave++;
        
    }
    private void SpawnMinion(GameObject minion, Vector3 position){
        GameObject newMinion = Instantiate(minion, initialSpawnPosition);
        newMinion.transform.localPosition = spawnOffset;
        newMinion.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    private IEnumerator NextWaveIE(int time){
        uiManager.Countdown(time);
        yield return new WaitForSeconds(time);
        SpawnWave();
    }
}
