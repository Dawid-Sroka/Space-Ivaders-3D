using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // __NEW_GAME_MANAGER__
    UIManager uiManager;
    private int score, credits;
    public void Awake(){
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        Physics.IgnoreLayerCollision(11, 9);     //player missles & side
        Physics.IgnoreLayerCollision(12, 10);   //enemy missles & side
        Physics.IgnoreLayerCollision(12, 11);   //enemy & ally missles
    }
    public void UpdateScore(int n){
        score+= n;
        uiManager.UpdateScore(score);
    }
    public void UpdateCredits(int n){
        credits+=n;
        uiManager.UpdateCredits(credits);
    }
    /* __OLD_GAME_MANAGER__

    private int score = 0;
    public int enemiesCount;
    public float lossBorder = 6f;
    public TextMeshProUGUI scoreText;
    [Header("UI Elements")]
    public GameObject UICanvas;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject hitPointPrefab;
    public List<GameObject> hitPointsUI;

    public AudioClip backgroundMusicLoss;

    private AudioSource backgroundMusicSource;
    private Player player;

    void Start()
    {
        Time.timeScale = 1f;
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        backgroundMusicSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        gameOverUI.SetActive(false);
        victoryUI.SetActive(false);
        Physics.IgnoreLayerCollision(11, 9);     //player missles & side
        Physics.IgnoreLayerCollision(12, 10);   //enemy missles & side
        Physics.IgnoreLayerCollision(12, 11);   //enemy & ally missles
        scoreText.text = "Score: " + score;

        for(int i = 0; i < player.hitPoints; i++){
            GameObject newHitPoint = Instantiate(hitPointPrefab, UICanvas.transform);
            newHitPoint.transform.localPosition -= new Vector3(40*i, 0, 0);
            hitPointsUI.Add(newHitPoint);
        }
    }

    public void UpdateScore(int amount){
        score+= amount;
        scoreText.text = "Score: " + score;
        enemiesCount -= 1;
        if(enemiesCount == 0){
            Victory();
        }
    }
    public void GameOver(){
        backgroundMusicSource.clip = backgroundMusicLoss;
        backgroundMusicSource.Play();
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    public void Victory()
    {
        Time.timeScale = 0f;
        victoryUI.SetActive(true);
    }
    public void Restart(){
        SceneManager.LoadScene(1);
    }
    public void LoadLevel(string name){
        SceneManager.LoadScene(name);
    }
    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void SetPause(bool on){
        Time.timeScale = on ? 0.0f : 1.0f;
    }
    */
}
