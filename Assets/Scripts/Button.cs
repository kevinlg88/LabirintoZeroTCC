using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour
{
    public GameObject obstacle;
    public Material myMaterial;
    Animator obstacleAnim;

    private bool on = false;
    // Start is called before the first frame update
    private void Awake() 
    {
        myMaterial.color = Color.red;
        obstacleAnim = obstacle.GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("triggerEnter");
        myMaterial.color = Color.green;
        obstacleAnim.SetBool("Free",true);
    }
}
