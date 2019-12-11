using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ObstacleToSpawn;
    public GameObject rewardToSpawn;
    public Vector3 rewardPosition;
    public Vector3 ObstaclePosition;
    float randX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnReward());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            randX = Random.Range(0, 5);
            Instantiate(ObstacleToSpawn, new Vector3(
                ObstaclePosition.x + randX, ObstaclePosition.y, ObstaclePosition.z),
                Quaternion.identity);
            
            yield return new WaitForSeconds(5 - randX);
        }
    }

    IEnumerator SpawnReward()
    {
        while (true)
        {
            int randRewardX = Random.Range(0, 4);
            Instantiate(rewardToSpawn, new Vector3(
                rewardPosition.x + randRewardX, rewardPosition.y + randRewardX, rewardPosition.z),
                Quaternion.identity);
            yield return new WaitForSeconds(randRewardX * .5f);
        }
    }
}
