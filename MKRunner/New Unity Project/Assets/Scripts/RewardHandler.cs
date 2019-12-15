using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardHandler : MonoBehaviour
{
    public GameObject destoryFX;
    public GameObject points;
    public Vector3 pointsOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHandler>() != null)
        {
            print("collected");
            PlayerHandler player = collision.gameObject.GetComponent<PlayerHandler>();
            player.PlayerScore += 1;
            if(player.PlayerScore > player.currentHighestScore)
            {
                GameHandler.instance.UpdateHighestScoreText(player.PlayerScore);
            }
            GameHandler.instance.SetScore(player.PlayerScore);
            FindObjectOfType<CameraControl>().CamShake();
            Instantiate(points, transform.position + pointsOffset, Quaternion.identity);
            Instantiate(destoryFX, transform.position, Quaternion.Euler(0, 0, Random.Range(0f,360f)));
            FindObjectOfType<SoundFXManager>().Play("Explode");
            Destroy(gameObject);
        }
    }
}
