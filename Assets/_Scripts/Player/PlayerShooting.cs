using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]private GameObject[] _bullets;
    [SerializeField] private Transform _emitter;
    private float _fireRate;
    private float _delay;
    private int _shootingUpgrade;

	void Start ()
	{
	    _fireRate = 0.075f;
	    _delay = 0.3f;
	    _shootingUpgrade = 0;
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.fixedTime > _delay)
            {
                _delay = Time.fixedTime + _fireRate;
                Instantiate(_bullets[_shootingUpgrade], _emitter);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_shootingUpgrade <= _bullets.Length-2)
            {
                _shootingUpgrade += 1;
            }
        }
    }
}
