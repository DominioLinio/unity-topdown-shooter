using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletDecayTime = 1f;
    float time = 0f;


    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,9,true);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > bulletDecayTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(hitEffect, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
            explosion.GetComponent<Transform>().transform.Rotate(170f, 0f, 0f);
        }
    }
}
