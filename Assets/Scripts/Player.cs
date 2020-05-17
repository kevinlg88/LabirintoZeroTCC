using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public Rigidbody rb;

    Animator animator;

    public bool greenKey = false;
    public bool redKey = false;
    public bool blueKey = false;
    public float velocity;

    public bool end = false;
    int currentPoint;
    void Start()
    {
        currentPoint = 11;
        rb = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AndarDireita()
    {
        StartCoroutine(Direita());
    }

    IEnumerator Direita()
    {
        animator.SetBool("Walk", true);
        rb.velocity = Vector3.right * velocity;
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector3.zero;
        animator.SetBool("Walk", false);
    }


    public void AndarEsquerda()
    {
        StartCoroutine(Esquerda());
    }

    IEnumerator Esquerda()
    {
        animator.SetBool("Walk", true);
        rb.velocity = Vector3.left * velocity;
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector3.zero;
        animator.SetBool("Walk", false);
    }

    public void AndarCima()
    {
        StartCoroutine(Cima());
    }

    IEnumerator Cima()
    {
        animator.SetBool("Walk", true);
        rb.velocity = new Vector3(0,0,1) * velocity;
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector3.zero;
        animator.SetBool("Walk", false);
    }

    public void AndarBaixo()
    {
        StartCoroutine(Baixo());
    }

    IEnumerator Baixo()
    {
        animator.SetBool("Walk", true);
        rb.velocity = new Vector3(0,0,-1) * velocity;
        yield return new WaitForSeconds(.5f);
        rb.velocity = Vector3.zero;
        animator.SetBool("Walk", false);
    }


    private void OnTriggerEnter(Collider other) 
    {
        // ##################### CHAVES ####################
        if(other.gameObject.CompareTag("keyGreen"))
        {
            greenKey = true;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("keyRed"))
        {
            redKey = true;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("keyBlue"))
        {
            blueKey = true;
            Destroy(other.gameObject);
        }

        //######################################################
        //############## PORTAS #############################

        else if(other.gameObject.CompareTag("doorGreen"))
        {
            if(greenKey)
            {
                greenKey = false;
                Destroy(other.gameObject);
            }
        }

        else if(other.gameObject.CompareTag("doorRed"))
        {
            if(redKey)
            {
                redKey = false;
                Destroy(other.gameObject);
            }
        }

        else if(other.gameObject.CompareTag("doorBlue"))
        {
            if(blueKey)
            {
                blueKey = false;
                Destroy(other.gameObject);
            }
        } 

        //##################### End ############################
        else if(other.gameObject.CompareTag("end"))
        {
            end = true;
            Destroy(other.gameObject);
        }
    }

}
