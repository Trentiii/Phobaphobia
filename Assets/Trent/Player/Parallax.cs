using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length1, startpos1;
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos1 = transform.position.y;
        length1 = GetComponent<SpriteRenderer>().bounds.size.y;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tenp1 = (cam.transform.position.y * (1 - parallaxEffect));
        float dist1 = (cam.transform.position.y * parallaxEffect);
        float tenp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (tenp > startpos + length) startpos += length;
        else if (tenp < startpos - length) startpos -= length;
    }
}
