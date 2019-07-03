using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    GameManager manager; // GameManager를 불러온다. 

    Rigidbody2D rigid2D;
    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;

    float jumpForce = 750.0f; // 780.0f
    float walkForce = 10.0f;  // 30.0f
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(rigid2D.velocity.y > 0)
        {
            boxCollider.enabled = false;
            circleCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
            circleCollider.enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce); 
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if(transform.position.y < -10 || Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0; // 일시정지 효과
            manager.SendMessage("SetGameOver");            
        }
        else
        {
            Time.timeScale = 1; // 일시 정지 해제
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Transform other = coll.transform;

        switch (other.tag)
        {
            case "Goal":
                SceneManager.LoadScene("ClearScene");
                break;
        }
    }
}
