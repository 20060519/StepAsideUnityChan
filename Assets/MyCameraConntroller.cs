using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraConntroller : MonoBehaviour
{
    //unitychan�̃I�u�W�F�N�g
    private GameObject unitychan;
    //unitychan�ƃJ�����̋���
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        //unitychan�̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //unitychan�ƃJ�����̈ʒu�i�����W�j�̍������߂�
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
