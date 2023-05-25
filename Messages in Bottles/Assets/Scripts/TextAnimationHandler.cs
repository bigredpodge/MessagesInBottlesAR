using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimationHandler : MonoBehaviour
{
[Header("Movement")]
public GameObject Bottle;
public bool startMoving;


[Header("Animation")]
Animator animator;
TMP_Text textComponent;

    void Awake()
    {
        Bottle = GameObject.Find("Cylinder");
        animator = transform.GetChild(0).GetComponent<Animator>();
        textComponent = transform.GetChild(0).GetComponent<TextMeshPro>();
        startMoving = false;
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
            //transform.RotateAround(Bottle.transform.position, new Vector3(0, 1, 0), 2f*Time.deltaTime);
            return;
        }

        transform.LookAt(Bottle.transform);
        transform.position = Vector3.MoveTowards(transform.position, Bottle.transform.position, 1.5f*Time.deltaTime);
        
    }
    
    public void StartMoving()
    {
        startMoving = true;
        animator.SetBool("isFading", false);
        animator.SetBool("isBobbing", true);
    }

    public void FadeIn()
    {
        animator.SetBool("isFading", true);
    }
}
