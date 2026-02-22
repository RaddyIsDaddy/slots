using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class teleportDownScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public float dropSpeed = 10f;
    private Boolean done = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, dropSpeed * Time.deltaTime);
         if (Vector3.Distance(transform.position, targetPosition) < 0.01f && !done)
        {
            done = true;
            transform.position = targetPosition;
            AudioSource spinDone = GameObject.Find("Shot Sound").GetComponent<AudioSource>();
            spinDone.pitch = 0.6f;
            spinDone.volume = 0.3f;
            spinDone.PlayOneShot(spinDone.clip);
        }
    }
}
