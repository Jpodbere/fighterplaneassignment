using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 3f);
        if (transform.position.x > 9.5f)
        {
            Destroy(this.gameObject);
        }
    }
}