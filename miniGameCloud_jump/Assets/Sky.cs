using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    Material mat;
    float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ofs = mat.mainTextureOffset;
        ofs.x += speed * Time.deltaTime;

        mat.mainTextureOffset = ofs;
    }
}
