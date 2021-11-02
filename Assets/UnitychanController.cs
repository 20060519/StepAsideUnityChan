using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;
    //unitychan���ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 16f;
    //�������̑��x
    private float velocityX = 10f;
    //�������Ɉړ��ł���͈�
    private float movableRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x) 
        {
            //�������ւ̑��x����
            inputVelocityX = this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && -this.transform.position.x > this.movableRange)
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        }
        //unitychan�ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, 0, velocityZ);
    }
}
