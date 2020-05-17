using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    // Start is called before the first frame update

    public GameObject player;
    public GameObject canvas;

    public GameObject winScreen;
    public GameObject gameOverScreen;

    [Header("SetasPrefabs")]
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject downArrow;
    public GameObject upArrow;

    [Header("PontosOrigem")]
    public GameObject leftArrowPoint;
    public GameObject rightArrowPoint;
    public GameObject upArrowPoint;
    public GameObject downArrowPoint;

    [Header("PontosLevel")]
    public GameObject levelPoints;

    [Header("CommandsList")]
    public List <string> commands;
    private void Awake() 
    {
        //**** Singleton *****
        if (instance != null) 
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }

        //************************
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRun()
    {
        StartCoroutine(Run());
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    IEnumerator Run()
    {
        Player p = player.GetComponent<Player>();
        foreach(string x in commands)
        {
            if(x == "Direita")
            {
                p.AndarDireita();
                Debug.Log("Corre para direita");
            }
            else if(x == "Esquerda")
            {
                p.AndarEsquerda();
                Debug.Log("Corre para esquerda");
            }
            else if(x == "Cima")
            {
                p.AndarCima();
                Debug.Log("Corre para cima");
            }
            else if(x == "Baixo")
            {
                p.AndarBaixo();
                Debug.Log("Corre para baixo");
            }
            yield return new WaitForSeconds(1f);
        }
        if(player.GetComponent<Player>().end)
        {
            winScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
        commands.Clear();
    }
}
