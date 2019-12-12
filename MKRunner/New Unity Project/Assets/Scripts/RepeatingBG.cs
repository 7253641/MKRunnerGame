using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public float scrollSpeed;

    public float startX;
    public float endX;

    public bool FinishSnap;
    float randomGap;
    float randVerticalOffset = 0;
    public bool makeRandomGap;
    // Use this for initialization
    void Start()
    {
        FinishSnap = false;
        if (makeRandomGap == true)
        {
            randomGap = Random.Range(5f, 15f);
            randVerticalOffset = Random.Range(-1f, 1f);
        }
        else
        {
            randomGap = 0;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.fixedDeltaTime);
        if (!FinishSnap)
        {
            MoveAndSnap();
        }
    }

    void MoveAndSnap()
    {
        if (transform.localPosition.x <= endX)
        {
            Vector2 pos = new Vector2(startX + randomGap, transform.position.y + randVerticalOffset);
            transform.localPosition = pos;
            if (makeRandomGap == true)
            {
                randomGap = Random.Range(5f, 15f);
                randVerticalOffset = Random.Range(-1f, 1f);
                if(randVerticalOffset != 0)
                {
                    randomGap = 10f;
                }
            }
            else
            {
                randomGap = 0;
            }
        }
    }


}
