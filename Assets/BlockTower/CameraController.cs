using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera main_camera;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            clickPosition = Input.mousePosition;
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            // upper botton
            if( ( ( ( main_camera.transform.localPosition.x  - 2.7 ) < clickPosition.x ) && ( clickPosition.x < (main_camera.transform.localPosition.x - 2.2 )) )  )
            {
                //upper botton
                if( ( (main_camera.transform.localPosition.y - 1.6) < clickPosition.y) && (clickPosition.y < ( main_camera.transform.localPosition.y - 1.2 ) ) )
                {
                    main_camera.transform.localPosition = new Vector3(0.0f, ( main_camera.transform.localPosition.y + 1.0f ), -10.0f);
                }
                // lower botton
                else if (( (main_camera.transform.localPosition.y - 2.35) < clickPosition.y) && (clickPosition.y < (main_camera.transform.localPosition.y - 2.0)))
                {
                    main_camera.transform.localPosition = new Vector3(0.0f, (main_camera.transform.localPosition.y - 1.0f), -10.0f);
                    print(main_camera.transform.localPosition);
                }
            }

        }
    }
}
