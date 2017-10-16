//ゲイン変化に未対応，というかさせる気が無い．

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ResistanceField : MonoBehaviour
{

    #region//変数宣言
    private float original_gain = 0.02f;
    public static float[] ResistantCofficience = new float[] { 0.01f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.325f, 0.35f, 0.375f, 0.4f, 0.425f, 0.45f, 0.475f, 0.5f, 1.0f };  //Handmodel speed gain
    private const string vh_pos_bone = "wrist";
    private const string finger = "index-tip";
    private const string plane = "Suihei";
    private const string plane1 = "Suichoku";
    private GameObject vh;
    private GameObject index;
    private bool _bool = false;
    public static int area_directional_mode = 1;
    public static int i=14;
    private const string rf_scene_name = "EH_RF";
    private SetHandInfomation shi2;
    #endregion


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == rf_scene_name)
        {
            _bool = true;
            vh = GameObject.Find(vh_pos_bone);
            index = GameObject.Find(finger);
            GameObject myref = GameObject.Find(MyDefinitions.GetDefinitions.vh_name);
            shi2 = myref.GetComponent<SetHandInfomation>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Return) && i != 0)
        {
            area_directional_mode++;
            if(area_directional_mode % 4 == 0)
            {
                area_directional_mode = 4;
                i = 14;
            }
            else
            {
                area_directional_mode = area_directional_mode % 4;
                i = 14;
            }
        }
        Cursor.visible = false;

        if (_bool)
        {
            switch (area_directional_mode)
            {
                case 1:
                    GameObject.Find("Areas").transform.Find("Suihei").gameObject.SetActive(true);
                    GameObject.Find("Areas").transform.Find("Suichoku").gameObject.SetActive(false);

                    if (Input.GetKeyUp(KeyCode.Space) && i != 0)
                    {
                        i--;
                    }

                    if (index.transform.position.x >= 0.15f)
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain * ResistantCofficience[i];
                    }

                    else
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain;
                    }

                    break;

                case 2:
                    GameObject.Find("Areas").transform.Find("Suihei").gameObject.SetActive(true);
                    GameObject.Find("Areas").transform.Find("Suichoku").gameObject.SetActive(false);

                    if (Input.GetKeyUp(KeyCode.Space) && i != 0)
                    {
                        i--;
                    }

                    if (index.transform.position.x >= 0.15f)
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain;
                    }

                    else
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain * ResistantCofficience[i];
                    }

                    break;

                case 3:
                    GameObject.Find("Areas").transform.Find("Suihei").gameObject.SetActive(false);
                    GameObject.Find("Areas").transform.Find("Suichoku").gameObject.SetActive(true);

                    if (Input.GetKeyUp(KeyCode.Space) && i != 0)
                    {
                        i--;
                    }

                    if (index.transform.position.z <= -0.186f)
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain * ResistantCofficience[i];
                    }

                    else
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain;
                    }

                    break;

                case 4:
                    GameObject.Find("Areas").transform.Find("Suihei").gameObject.SetActive(false);
                    GameObject.Find("Areas").transform.Find("Suichoku").gameObject.SetActive(true);
                    if (Input.GetKeyUp(KeyCode.Space) && i != 0)
                    {
                        i--;
                    }

                    if (index.transform.position.z <= -0.186f)
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain;
                    }

                    else
                    {
                        shi2.MyHand.Last_center_pos = shi2.CalHandPosition();
                        shi2.MyHand.Init_center_pos = shi2.MyHand.Center_pos;
                        shi2.MyHand.extensiongain = original_gain * ResistantCofficience[i];
                    }
                    break;

            }
        }
    }
}
