using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private CanvasGroup canvasGroup;

    bool onTable = false;

    private void Awake() 
    {
        canvasGroup = GetComponent<CanvasGroup>();    
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(this.gameObject.CompareTag("Baixo"))
        {
            GameObject go = Instantiate(GameController.instance.downArrow,GameController.instance.downArrowPoint.transform.position,Quaternion.identity);
            go.transform.SetParent(GameController.instance.canvas.transform);
        }

        else if(this.gameObject.CompareTag("Cima"))
        {
            GameObject go = Instantiate(GameController.instance.upArrow,GameController.instance.upArrowPoint.transform.position,Quaternion.identity);
            go.transform.SetParent(GameController.instance.canvas.transform);
        }

        else if(this.gameObject.CompareTag("Direita"))
        {
            GameObject go = Instantiate(GameController.instance.rightArrow,GameController.instance.rightArrowPoint.transform.position,Quaternion.identity);
            go.transform.SetParent(GameController.instance.canvas.transform);
        }

        else if(this.gameObject.CompareTag("Esquerda"))
        {
            GameObject go = Instantiate(GameController.instance.leftArrow,GameController.instance.leftArrowPoint.transform.position,Quaternion.identity);
            go.transform.SetParent(GameController.instance.canvas.transform);
        }
        //Instantiate
        Debug.Log("Begin Drag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position =new Vector3 (Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        if(!onTable)
        {
            Destroy(this.gameObject);
        }
        //canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointerDown");
    }

    public void ReceiveTable()
    {
        onTable = true;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
