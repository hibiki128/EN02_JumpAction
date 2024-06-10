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
            // ベクトルの長さを算出
            float size = dist.magnitude;
            // ベクトルから角度(弧度法)を算出
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // 矢印の画像をクリックした場所に画像を移動
            ArrowImage.rectTransform.position = clickPosition;
            // 矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
            ArrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // 矢印の画像の大きさとドラッグした距離に合わせる
            ArrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if(Input.GetMouseButtonUp(0)) {
            ArrowImage.gameObject.SetActive(false);
        }
    }
}
