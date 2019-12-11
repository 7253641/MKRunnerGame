using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ObjectToFollow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, ObjectToFollow.transform.position.x, Time.deltaTime),
            Mathf.Lerp(transform.position.y, ObjectToFollow.transform.position.y, Time.deltaTime),
            transform.position.z);
    }
}
