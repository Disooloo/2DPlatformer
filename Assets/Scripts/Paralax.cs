using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, StartPost;
    public GameObject cam;
    public float ParalaxEffect;

    // Start is called before the first frame update
    private void Start()
    {
        StartPost = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - ParalaxEffect));
        float dist = (cam.transform.position.x * ParalaxEffect);

        transform.position = new Vector3(StartPost + dist, transform.position.y, transform.position.z);

        if (temp > StartPost + length) StartPost += length;
        else if (temp < StartPost - length) StartPost -= length;
    }
}
