using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image ArrowImage;
    private Vector3 clickPosition;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            ArrowImage.gameObject.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            // �x�N�g���̒������Z�o
            float size = dist.magnitude;
            // �x�N�g������p�x(�ʓx�@)���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // ���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            ArrowImage.rectTransform.position = clickPosition;
            // ���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            ArrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // ���̉摜�̑傫���ƃh���b�O���������ɍ��킹��
            ArrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if(Input.GetMouseButtonUp(0)) {
            ArrowImage.gameObject.SetActive(false);
        }
    }
}
