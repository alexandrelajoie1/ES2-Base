using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleSousMarin : MonoBehaviour
{
    [SerializeField] private float vitesseSousMarin;
    private Rigidbody _rb;
    private Vector3 directionInput;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnDeplacement(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * vitesseSousMarin;
        directionInput = new Vector3(0f, directionAvecVitesse.y, directionAvecVitesse.z);
        _animator.SetFloat("Deplacement", directionInput.magnitude);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Vector3 mouvement = directionInput;
        
        if (directionInput.magnitude > 0f)
        {
            _rb.AddForce(mouvement, ForceMode.VelocityChange);
        }   
    }
}
