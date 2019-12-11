using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAndDestory : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.fixedDeltaTime);
    }


}
