using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private float destroyTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        print("ｼｮｳﾄﾂ!");

        if (other.gameObject.tag == this.tag)
        {
            print("ｷｴﾛ");
            Destroy(this.gameObject, destroyTime);
            Destroy(other.gameObject, destroyTime);

        }
    }

}
