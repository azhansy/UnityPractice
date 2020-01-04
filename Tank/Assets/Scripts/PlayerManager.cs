using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //玩家的属性值
    public int lifeValue = 3;
    public int playerScore = 0;

    public bool isDead;

    public bool isDefeat;

    //引用
    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;

    //单例
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            Debug.Log("游戏结束=========");
            isDefeatUI.SetActive(true);
            Invoke("ReturnToTheMaiinMenu", 3);
            return;
        }

        if (isDead)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();
    }

    public void SetPlayerDead()
    {
        isDead = true;
    }


   public void AddScore()
    {
        playerScore++;
    }

    private void Recover()
    {
        if (lifeValue < 0)
        {
            //游戏失败， 返回主界面
            isDefeat = true;
            Invoke("ReturnToTheMaiinMenu", 3);
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2 ,-8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }


    public void ReturnToTheMaiinMenu()
    {
        SceneManager.LoadScene(0);
    }

}
