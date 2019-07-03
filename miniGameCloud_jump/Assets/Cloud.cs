using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitCloud();
    }

    void InitCloud()
    {
        float sx = Random.Range(0.8f, 2);

        transform.localScale = new Vector3(sx, sx, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
