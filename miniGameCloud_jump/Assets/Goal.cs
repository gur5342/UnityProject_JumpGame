using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitGoal();
    }

    void InitGoal()
    {
        Sprite sprite = Resources.Load<Sprite>("sky castle");
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
