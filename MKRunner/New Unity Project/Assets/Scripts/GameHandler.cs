using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public GameObject ObstacleToSpawn;
    public GameObject rewardToSpawn;
    public GameObject scoreText;
    public GameObject meterText;
    public GameObject gameOverUI;
    public GameObject highestScoreText;
    public Vector3 rewardPosition;
    public Vector3 ObstaclePosition;
    [HideInInspector]public int finalScore = 0;
    [HideInInspector]public int finalMeter = 0;
    public GameObject finalScoreText;
    public GameObject finalMeterText;
    float randX;
    [HideInInspector] public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        isGameOver = false;
        gameOverUI.SetActive(false);
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnReward());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighestScoreText(int score)
    {
        highestScoreText.GetComponent<TextMeshProUGUI>().text = "Highest: " + score;
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void SetMeter(int meter)
    {
        meterText.GetComponent<TextMeshProUGUI>().text = meter.ToString() + "m";
    }

    public void ShowGameOverState()
    {
        gameOverUI.SetActive(true);
    }

    public void SetFinalScore(int score)
    {
        finalScoreText.GetComponent<TextMeshProUGUI>().text = "Final Score: " + score;
    }

    public void SetFinalMeter(int meter)
    {
        finalMeterText.GetComponent<TextMeshProUGUI>().text = "Meters Travelled: " + meter + "m";
    }

    IEnumerator SpawnObstacle()
    {
        while (isGameOver == false)
        {
            randX = Random.Range(0f, 4f);
            Instantiate(ObstacleToSpawn, new Vector3(
                ObstaclePosition.x + randX, ObstaclePosition.y, ObstaclePosition.z),
                Quaternion.identity);
            
            yield return new WaitForSeconds(5 - randX);
        }
    }

    IEnumerator SpawnReward()
    {
        while (isGameOver == false)
        {
            float randRewardX = Random.Range(0f, 4f);
            Instantiate(rewardToSpawn, new Vector3(
                rewardPosition.x + randRewardX, rewardPosition.y + randRewardX, rewardPosition.z),
                Quaternion.identity);
            yield return new WaitForSeconds(randRewardX * .5f);
        }
    }
}
