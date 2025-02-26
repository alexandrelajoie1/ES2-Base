using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleSousMarin : MonoBehaviour
{
    [SerializeField] private float _vitesseSousMarin;
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
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * _vitesseSousMarin;
        directionInput = new Vector3(0f, directionAvecVitesse.y, directionAvecVitesse.z);

        if (directionAvecVitesse.y > 0f)
        {
            _animator.SetFloat("Deplacement.Y", directionInput.magnitude);
            Debug.Log("En Haut!");

        }

        else if (directionAvecVitesse.y < 0f)
        {
            _animator.SetFloat("Deplacement.Y", -directionInput.magnitude);
            Debug.Log("En Bas!");
        }
       
        else if (directionAvecVitesse.z > 0f)
        {
            _animator.SetFloat("Deplacement.Z", directionInput.magnitude);
            Debug.Log("Avance!");
        }

        else if (directionAvecVitesse.z < 0f)
        {
            _animator.SetFloat("Deplacement.Z", -directionInput.magnitude);
            Debug.Log("Recule!");
        }

        else if (directionAvecVitesse.y == 0f && directionAvecVitesse.z == 0f)
        {
            _animator.SetFloat("Deplacement.Y", directionInput.magnitude);
            _animator.SetFloat("Deplacement.Z", -directionInput.magnitude);
           
            Debug.Log("Repos");
        }
        
    }

    void OnBoost(InputValue etatBouton)
    {
        if(etatBouton.isPressed){
            _vitesseSousMarin = 1f;
            Debug.Log("Boost!!");
        }
        else{
            _vitesseSousMarin = 0.5f;
            Debug.Log("No boost");
        }
       
    }

   
    void FixedUpdate()
    {
        Vector3 movement = directionInput * _vitesseSousMarin;
        _rb.AddForce(movement, ForceMode.VelocityChange);
     
    }
}
