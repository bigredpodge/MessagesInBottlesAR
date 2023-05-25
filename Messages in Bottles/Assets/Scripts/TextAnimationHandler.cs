using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationHandler : MonoBehaviour
{
[Header("Movement")]
public GameObject Bottle;
public bool startMoving;


[Header("Animation")]
Animator animator;

    void Start()
    {
        Bottle = GameObject.Find("Cylinder");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!startMoving)
        {
            animator.SetBool("isBobbing", false);
            return;
        }

        if (Vector3.Distance(transform.position, Bottle.transform.position) < 1f)
        {
            startMoving = false;
            return;
        }
        
        animator.SetBool("isBobbing", true);
        transform.LookAt(Bottle.transform);
        transform.position = new Vector3(0, 0, 1f*Time.deltaTime);
        
    }
    
    public void StartMoving()
    {
        startMoving = true;
    }
}
