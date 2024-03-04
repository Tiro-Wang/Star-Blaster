using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    void Start()
    {
        Camera mainCamera = Camera.main;

        // ��仰��ʾ��ȡ��Ļ��߽��x���ꡣ��ʹ����Vector3.zero��Ϊ���������������ʾ��Ļ���½ǵĵ�
        // ����x��y��������0��z������������Ľ��ü�����롣Ȼ�����������ת��Ϊ��������ϵ�еĵ㣬
        // ��ȡ������x��������ֵ��screenLeft������
        screenLeft = mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        // ��仰��ʾ��ȡ��Ļ�ұ߽��x���ꡣ��ʹ����һ���½���������Ϊ���������������ʾ��Ļ���½ǵĵ㣬
        // ����x��������Ļ�Ŀ�ȣ�y��z��������0��Ȼ�����������ת��Ϊ��������ϵ�еĵ㣬
        // ��ȡ������x��������ֵ��screenRight������
        screenRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenTop = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = mainCamera.ScreenToWorldPoint(Vector3.zero).y;
    }

    void Update()
    {
        // ��ȡ��ǰ��Ҷ����λ��
        Vector3 currentPosition = transform.position;

        // ��������Ļ�߽���
        currentPosition.x = Mathf.Clamp(currentPosition.x, screenLeft, screenRight);
        currentPosition.y = Mathf.Clamp(currentPosition.y, screenBottom, screenTop);

        // ������ҵ�λ��
        transform.position = currentPosition;
    }
}
