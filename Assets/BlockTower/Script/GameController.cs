using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] blockPrefab;
    public Camera main_camera;

    private Vector3 clickPosition;
    private Vector3 displayPosition;
    private Vector3 cameraPosition_old;
    private int number = 0;
    private int next_number = 0;
    private GameObject Obj;
    private GameObject dispObj;

    // Start is called before the first frame update
    void Start()
    {
        clickPosition = new Vector3(0.0f, 5.0f, 1.0f);
        number = Random.Range(0, blockPrefab.Length);

        displayPosition = new Vector3( 2.4f, 4.0f, 1.0f );
        BlockSet();

        cameraPosition_old = main_camera.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if( (Input.GetMouseButtonDown(0) ) )
        {
            clickPosition = Input.mousePosition;
            print("left click.");

            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
//            clickPosition += main_camera.transform.localPosition;
            print("クリックpos");
            print(clickPosition);
            print("カメラポジ");
            print(main_camera.transform.localPosition);

            if ( (clickPosition.y > (main_camera.transform.localPosition.y - 2.0f )) && (clickPosition.y < (main_camera.transform.localPosition.y + 4.0f)) )
            {
                if( ( -2.0f < clickPosition.x ) && (clickPosition.x < 2.0f ) )
                {
                    clickPosition.y = main_camera.transform.localPosition.y + 5.0f;
                    clickPosition.z = main_camera.transform.localPosition.z + 20.0f;

                    number = next_number;
                    BlockSet();

                }
            }

            if( cameraPosition_old != main_camera.transform.localPosition )
            {
                cameraPosition_old = main_camera.transform.localPosition;
                displayPosition = main_camera.transform.localPosition + new Vector3(2.4f, 4.0f, 1.0f);
                dispObj.transform.localPosition = displayPosition;
            }

        }
    }

    void BlockSet()
    {
        /* ブロックを出現させる */
        Obj = Instantiate(blockPrefab[number], clickPosition, blockPrefab[number].transform.rotation);
        Obj.transform.parent = this.transform;

        /* 次のブロックを表示する */
        Destroy(dispObj, 0.01f);
        //next_number = Random.Range(0, blockPrefab.Length);
        next_number += 1;
        if(next_number >= blockPrefab.Length)
        {
            next_number = 0;
        }
        dispObj = Instantiate(blockPrefab[next_number], displayPosition, blockPrefab[next_number].transform.rotation);
        dispObj.GetComponent<Rigidbody2D>().gravityScale = 0;
        dispObj.GetComponent<Collider2D>().isTrigger = true;
        dispObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }
}