using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public Vector2 offset;
    public float Smoothness;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectToFollow != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, ObjectToFollow.transform.position.x + offset.x, Time.deltaTime * Smoothness),
            Mathf.Lerp(transform.position.y, ObjectToFollow.transform.position.y + offset.y, Time.deltaTime * Smoothness),
            transform.position.z);
    }
}
