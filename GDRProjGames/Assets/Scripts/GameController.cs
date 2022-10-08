using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject destroyedPlayer;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject[] resultTextGame;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    
    private int curentScore = 0;
    private int maxCoins = 0;

    private void Awake() => Instance = this;
    
    private void Start()
    {
        //Counting coins on stage
        CoinScript[] sceneObjects = FindObjectsOfType(typeof(CoinScript)) as CoinScript[];
        
        foreach (CoinScript obj in sceneObjects)
            maxCoins++;

        scoreText.text = " Money / "+ curentScore + " / " + maxCoins;

    }

    public void DestroyPlayer() 
    {
        GameObject DesObj = Instantiate(destroyedPlayer, playerObj.transform.position, playerObj.transform.rotation);
        Destroy(this.playerObj);
        Destroy(DesObj, 3f);
        OpenMenu(0);
    }

    public void Scoring() 
    {
        curentScore++;
        scoreText.text = " Money / "+curentScore + " / "+ maxCoins;
        if (curentScore>=maxCoins)
        {
            OpenMenu(1);
        }
    
    }
    public void OpenMenu(int result) 
    {
        resultTextGame[result].SetActive(true);
        menu.SetActive(true);
    }
    //Button restart
    public void GameRestart() 
    {
       SceneManager.LoadScene(0);
    }



}
