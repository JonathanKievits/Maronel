using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]private float speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(0f,10f,0f) * speed * Time.fixedDeltaTime;
    }
}
