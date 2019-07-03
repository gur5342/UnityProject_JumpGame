using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Transform goal;

    Transform player;

    Image pnOver;

    Text height;
    Text heightScore;

    public float btnAxis;

    float playerHeight = 0;
    bool isOver;

    Transform spPoint;
    Vector3 wrdSize;

    void InitGame()
    {
        spPoint = GameObject.Find("SpawnPoint").transform;

        Vector3 scrSize = new Vector3(Screen.width, Screen.height);
        scrSize.z = 10;  // z
        wrdSize = Camera.main.ScreenToWorldPoint(scrSize);

    }

    // Start is called before the first frame update
    void Awake()
    {
        InitGame();
        InitWidget();
    }

    // Update is called once per frame
    void Update()
    {
        MakeCloud();
        MakeGoal();

        if (!isOver) SetScore();
    }

    void MakeCloud()
    {
        int cnt = GameObject.FindGameObjectsWithTag("Cloud").Length;
        if (cnt > 4)
            return;

        Vector3 pos = spPoint.position;
        pos.x = Random.Range(-wrdSize.x * 0.5f, wrdSize.x * 0.5f); // 화면의 좌우 절반을 범위로 한다.


        GameObject cloud = Instantiate(Resources.Load("Cloud")) as GameObject;
        cloud.transform.position = pos;

        spPoint.position += new Vector3(0, 4, 0);
        
    }

    void MakeGoal()
    {
        int cnt = GameObject.FindGameObjectsWithTag("Goal").Length;
        if (cnt > 1)
            return;

        Vector3 pos = spPoint.position;
        pos.x = Random.Range(-wrdSize.x * 0.5f, wrdSize.x * 0.5f);  // 0.5f
        pos.y = 23;

        GameObject goal = Instantiate(Resources.Load("Goal")) as GameObject;
        goal.transform.position = pos;

    }

    void InitWidget()
    {
        pnOver = GameObject.Find("PanelOver").GetComponent<Image>();
        pnOver.gameObject.SetActive(false);

        height = GameObject.Find("Height").GetComponent<Text>();
        heightScore = GameObject.Find("HeightScore").GetComponent<Text>();

        player = GameObject.Find("cat").transform;
    }

    void SetScore()
    {
        if (player.position.y > playerHeight)
        {
            playerHeight = player.position.y;
        }

        heightScore.text = playerHeight.ToString("#,##0.0");
    }
    
    void SetGameOver()
    {
        isOver = true;
        pnOver.gameObject.SetActive(true);
        Cursor.visible = true;
    }

    public void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "BtnAgain":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "BtnQuit":
                Application.Quit();
                break;
        }
    }

    public void OnButtonUp()
    {
        btnAxis = 0;
    }
}
