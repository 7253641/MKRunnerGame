using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardHandler : MonoBehaviour
{
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
            GameHandler.instance.SetScore(player.PlayerScore);
            Destroy(gameObject);
        }
    }
}
