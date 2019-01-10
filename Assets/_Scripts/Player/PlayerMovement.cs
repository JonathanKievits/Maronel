using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [HideInInspector]
    public float xMin = -3.5f, yMin = -5f, xMax = 3.5f, yMax = 5f;
}

public class PlayerMovement : MonoBehaviour
{
    [Range(1,4)][SerializeField]private float _moveSpeed;
    [Range(1, 4)][SerializeField]private float _slowSpeed;
    private Rigidbody2D _rigid;
    [HideInInspector]public Vector2 _movement;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(x, y);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _moveSpeed /= _slowSpeed;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            _moveSpeed *= _slowSpeed;
    }

    void FixedUpdate()
    {
        Vector3 velocity = transform.TransformDirection(_movement.normalized) * _moveSpeed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.transform.localPosition + velocity);
    }
}