using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public AudioSource music1;
    public bool isMusicActive;

    public Transform target;
    public float speedcam = 1f;

    void Start()
    {
        if (isMusicActive == false)
        {
            isMusicActive = true;
            music1.Play();
        }
        else { music1.Stop(); }
    }

        void Update()
    {
        Vector3 destpoint = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, destpoint, Time.deltaTime * speedcam);
    }
}
