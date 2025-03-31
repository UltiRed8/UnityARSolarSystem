using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] float g = 1f;
    [SerializeField] GameObject[] planets;
    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach(GameObject _planet in planets)
        {
            Debug.Log(_planet.name);
        }
        InitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach (GameObject _planetA in planets)
        {
            Debug.Log(_planetA.name);
            foreach (GameObject _planetB in planets)
            {
                Debug.Log(_planetB.name);
                if (_planetA == _planetB) continue;
                Rigidbody _rigidbodyA = _planetA.GetComponent<Rigidbody>();
                Rigidbody _rigidbodyB = _planetB.GetComponent<Rigidbody>();
                Vector3 _planetAPos = _planetA.transform.position;
                Vector3 _planetBPos = _planetB.transform.position;
                float _massA = _rigidbodyA.mass;
                float _massB = _rigidbodyB.mass;
                float _distance = Vector3.Distance(_planetAPos, _planetBPos);

                _rigidbodyA.AddForce((_planetBPos - _planetAPos).normalized * (g * (_massA * _massB) / (_distance * _distance)));
            }
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject _planetA in planets)
        {
            foreach (GameObject _planetB in planets)
            {
                if( _planetA == _planetB) continue;
                float _massB = _planetB.GetComponent<Rigidbody>().mass;
                float _distance = Vector3.Distance(_planetA.transform.position, _planetB.transform.position);
                _planetA.transform.LookAt(_planetB.transform);

                _planetA.GetComponent<Rigidbody>().velocity += _planetA.transform.right * Mathf.Sqrt((g * _massB) / _distance);
            }
        }
    }
}
