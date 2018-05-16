using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("IsWalking",true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("IsRunning", true);
            }else
            {
                _animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("IsJumping", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
        }
	}
}
