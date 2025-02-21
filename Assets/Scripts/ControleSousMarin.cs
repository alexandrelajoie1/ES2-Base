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

    void OnDeplacement_Y(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * vitesseSousMarin;
        directionInput = new Vector3(0f, directionAvecVitesse.y, 0f);
        if(directionAvecVitesse.y > 0f)
        {
            _animator.SetFloat("Deplacement.Y", directionInput.magnitude);
        }
        
        else if (directionAvecVitesse.y < 0f)
        {
            _animator.SetFloat("Deplacement.Y", -directionInput.magnitude);
        }
        else
        {
            _animator.SetFloat("Deplacement.Y", directionInput.magnitude);
        }
    }

    void OnDeplacement_Z(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * vitesseSousMarin;
        directionInput = new Vector3(0f, 0f, directionAvecVitesse.z);
        if (directionAvecVitesse.z > 0f)
        {
            _animator.SetFloat("Deplacement.Z", directionInput.magnitude);
        }

        else if (directionAvecVitesse.z < 0f)
        {
            _animator.SetFloat("Deplacement.Z", -directionInput.magnitude);
        }
        else
        {
            _animator.SetFloat("Deplacement.Z", directionInput.magnitude);
        }
    }

    void OnBoost()
    {
       Vector3 boost = directionInput;
        _rb.AddForce(boost, ForceMode.VelocityChange);
    }

   
    void FixedUpdate()
    { 
        Vector3 mouvement = directionInput;
        
        if (directionInput.magnitude > 0f)
        {
            _rb.AddForce(mouvement, ForceMode.VelocityChange);
        }   
    }
}
