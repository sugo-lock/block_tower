using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Camera main_camera;
    public Text text;
    public float SCORE_FIXED_TIME = 0.5f;
    private string txt = "";
    private Vector3 highestObjectPosition;
    private float erapsed_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.BoxCast( (new Vector2 ( 0.0f+ main_camera.transform.localPosition.x, 5.0f+ main_camera.transform.localPosition.y) ), ( new Vector2(3, 1) ), 0f, (new Vector2(0.0f, -1.0f )), 10.0f );
        if (hitInfo)
        {
            highestObjectPosition = hitInfo.transform.position;

            if ( txt == (highestObjectPosition.y + 3.5f).ToString("f2") + "m" )
            {
                if ( erapsed_time > SCORE_FIXED_TIME)
                {
                    text.text = txt;
                }
                else
                {
                    erapsed_time += Time.deltaTime;
                }

            }
            else
            {
                txt = (highestObjectPosition.y + 3.5f).ToString("f2") + "m";
                erapsed_time = 0.0f;
            }

            //Gizmos.color = Color.red; //色指定
            //Gizmos.DrawCube( new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0, 1, 0) ); //中心点とサイズ
            Debug.Log(hitInfo.collider.gameObject.name);
        }
    }
}
