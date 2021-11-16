using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // ������̑��x
    private float velocityY = 10f;
    //�������Ɉړ��ł���͈�
    private float movableRange = 3.4f;
    //����������������W��
    private float coefficient = 0.09f;
    //�Q�[���̏I���̔���
    private bool isEnd = false;
    //�Q�[���I�����ɕ\������e�L�X�g
    private GameObject stateText;
    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;
    //���_
    private int score = 0;
    //���{�^�������̔���
    private bool isLButtonDown = false;
    //�E�{�^�������̔���
    private bool isRButtonDown = false;
    //�W�����v�{�^�������̔���
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();

        //�V�[���̒���stateText�I�u�W�F�N�g���擾
        this.stateText = GameObject.Find("GameResultText");
        //�V�[���̒���scoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I���Ȃ�unity�����̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }


        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;

        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������
        if ( (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown ) && -this.movableRange < this.transform.position.x) 
        {
            //�������ւ̑��x����
            inputVelocityX = -this.velocityX;
        }
        else if ( (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ����ɃX�y�[�X�������ꂽ��W�����v����
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ�
            this.myAnimator.SetBool("Jump", true);
            //������̑��x����
            inputVelocityY = this.velocityY;
        }

        else 
        {
            //���݂�Y���̒l����
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇ��Jump��False���Z�b�g����
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //unitychan�ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }

    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ɐڐG�����ꍇ�̏���
    void OnTriggerEnter(Collider other)
    {
        //��Q���ɏՓ˂����ꍇ
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") 
        {
            this.isEnd = true;
            //stateText��GAME Over��\��
            this.stateText.GetComponent<Text>().text = "GameOver!!";
        }
        //�S�[���n�_�ɓ��������ꍇ
        if (other.gameObject.tag == "GoalTag") 
        {
            this.isEnd = true;
            //stateText�ɃQ�[���N���A�ƕ\��
            this.stateText.GetComponent<Text>().text = "Clear";
        }
        //�R�C���ɏՓ˂����ꍇ
        if (other.gameObject.tag == "CoinTag")
        {
            //���_�����Z
            this.score += 10;
            //ScoreText�l�������_����\��
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
            //�p�[�e�B�N�����Đ�
            GetComponent<ParticleSystem>().Play();

            //�ڐG�����R�C���̃I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }

    //�W�����v�{�^�����������Ƃ��̏���
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    //�W�����v�{�^���𗣂����Ƃ��̏���
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }
    //���{�^���������������ꍇ�̏���
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //���{�^���𗣂����Ƃ��̏���
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    //�E�{�^���������������ꍇ�̏���
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //�E�{�^���𗣂����Ƃ��̏���
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }


}
