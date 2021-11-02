using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //unitychanを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16f;
    //横方向の速度
    private float velocityX = 10f;
    //横方向に移動できる範囲
    private float movableRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //横方向の入力による速度
        float inputVelocityX = 0;
        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x) 
        {
            //左方向への速度を代入
            inputVelocityX = this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && -this.transform.position.x > this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }
        //unitychanに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, 0, velocityZ);
    }
}
