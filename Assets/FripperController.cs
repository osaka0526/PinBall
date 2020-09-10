using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //スマートフォンマルチタッチの設定
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                // タッチを開始
                if (t.phase == TouchPhase.Began)
                {
                    if (Input.mousePosition.x >= Screen.width / 2)
                    {
                        //画面右半分に指があれば右フリッパーをあげる
                        if (tag == "RightFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                    }
                    else if (Input.mousePosition.x <= Screen.width / 2)
                    {
                        //画面左半分に指があれば左フリッパーをあげる
                        if (tag == "LeftFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                    }
                    Debug.Log("タッチを開始しました。");
                    break;
                }

                // 指が動いている
                if (t.phase == TouchPhase.Moved)
                {
                    //画面右半分に指があれば右フリッパーをあげ左フリッパーをさげる
                    if (Input.mousePosition.x >= Screen.width / 2)
                    {
                        if (tag == "RightFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                        if (tag == "LeftFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }
                    }
                    //画面左半分に指があれば左フリッパーをあげ右フリッパーをさげる
                    else if (Input.mousePosition.x <= Screen.width / 2)
                    {
                        if (tag == "LeftFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                        if (tag == "RightFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }
                    }
                    Debug.Log("指が動いています。");
                    break;
                }

                // タッチを継続中だが静止
                if (t.phase == TouchPhase.Stationary)
                {
                    if (Input.mousePosition.x >= Screen.width / 2)
                    {
                        //画面右半分に指があれば右フリッパーをあげる
                        if (tag == "RightFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                    }
                    else if (Input.mousePosition.x <= Screen.width / 2)
                    {
                        //画面左半分に指があれば左フリッパーをあげる
                        if (tag == "LeftFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }

                    }
                    Debug.Log("タッチを継続中ですが動いていません。");
                    break;

                }
                //タッチを終了
                if (t.phase == TouchPhase.Ended)
                {
                    // フリッパーを下げる
                    SetAngle(this.defaultAngle);
                    Debug.Log("タッチを終了しました。");
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}

