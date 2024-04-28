using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static EndManager instance;
    public List<GameObject> enemyList;
    public GameObject player;
    public GameObject gameOverMenu;
    public TextMeshProUGUI endGameText;
    
    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count <= 0)
        {
            endGameText.text = "YOU WIN!";
            gameOverMenu.SetActive(true);
        }
        else if (player == null)
        {
            endGameText.text = "YOU LOSE!";
            gameOverMenu.SetActive(true);
        }
    }
}
