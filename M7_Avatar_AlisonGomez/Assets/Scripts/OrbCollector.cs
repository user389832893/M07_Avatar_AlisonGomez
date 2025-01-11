using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OrbCollector : MonoBehaviour
{
    private Animator _animator;
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera itemCamera; 

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll))

        {
            icoll.OnCollected();

            if (other.GetComponent<Orb>()!=null)
            {
                _animator.SetTrigger("Collected");
                _animator.SetLayerWeight(1, 1);
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;
                GetComponent<PlayerMover>().canMove = false;  
            }
        } 
    }
}