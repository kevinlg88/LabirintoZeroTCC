using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTable : MonoBehaviour, IDropHandler
{
    public List<GameObject> pontos;

    public List<GameObject> listGo;

    private bool runned = false;
    private bool full = false;
    private int numberCommands = 0;

    private void Awake() 
    {
        listGo = new List<GameObject>();
        foreach(GameObject x in pontos)
        {
            listGo.Add(x);
        }    
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(runned)return;
        if(full)return;
        if(numberCommands >= pontos.Count)
        {
            numberCommands = 0;
        }
        if(numberCommands == pontos.Count-1)
        {
            full = true;
        }
        Debug.Log("Drop Table");
        GameObject objeto = eventData.pointerDrag.gameObject;
        objeto.GetComponent<DragDrop>().ReceiveTable();
        UpdateCommands(objeto);

        if(!listGo[numberCommands].gameObject.CompareTag("point"))
        {
            Destroy(listGo[numberCommands].gameObject);
        }
        listGo[numberCommands] = objeto;


        objeto.transform.position = new Vector2(pontos[numberCommands].transform.position.x, pontos[numberCommands].transform.position.y);
        objeto.transform.localScale = objeto.transform.localScale/2;
        objeto.GetComponent<CanvasGroup>().blocksRaycasts = false;
        numberCommands += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCommands(GameObject go)
    {
        if(go.CompareTag("Baixo"))
        {
            GameController.instance.commands.Add("Baixo");
        }
        else if(go.CompareTag("Cima"))
        {
            GameController.instance.commands.Add("Cima");
        }
        else if(go.CompareTag("Esquerda"))
        {
            GameController.instance.commands.Add("Esquerda");
        }
        else if(go.CompareTag("Direita"))
        {
            GameController.instance.commands.Add("Direita");
        }
    }

    public void Run()
    {
        runned = true;
        numberCommands = 0;
        foreach(GameObject go in listGo)
        {
            if(!go.CompareTag("point"))
            {
                Destroy(go);
            }
        }
        listGo.Clear();
        listGo = new List<GameObject>();
        foreach(GameObject x in pontos)
        {
            listGo.Add(x);
        }   
        GameController.instance.StartRun();
    }
}
