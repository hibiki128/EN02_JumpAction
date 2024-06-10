using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Lumin;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, -12, 0);
    }

    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            audioSource.Play();
            // �N���b�N�������W�Ƙb�������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X�������d�l�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
    }
    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("�ڐG��");
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        // ������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓��ρB��̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁAcos�Ƃ̌��ʂ�dotUN�ϐ��ɓ���B
        float dotUN = Vector3.Dot(upVector,otherNormal);
        // ���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�o�B�����x���@�֕ύX����B����Ŋp�x���Z�o�ł����B
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // ��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�Ƃ���
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log("���E����");
        isCanJump = false;
    }

}
