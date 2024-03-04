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

        // 这句话表示获取屏幕左边界的x坐标。它使用了Vector3.zero作为参数，这个向量表示屏幕左下角的点
        // 它的x和y分量都是0，z分量是摄像机的近裁剪面距离。然后，它将这个点转换为世界坐标系中的点，
        // 并取出它的x分量，赋值给screenLeft变量。
        screenLeft = mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        // 这句话表示获取屏幕右边界的x坐标。它使用了一个新建的向量作为参数，这个向量表示屏幕右下角的点，
        // 它的x分量是屏幕的宽度，y和z分量都是0。然后，它将这个点转换为世界坐标系中的点，
        // 并取出它的x分量，赋值给screenRight变量。
        screenRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenTop = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = mainCamera.ScreenToWorldPoint(Vector3.zero).y;
    }

    void Update()
    {
        // 获取当前玩家对象的位置
        Vector3 currentPosition = transform.position;

        // 限制在屏幕边界内
        currentPosition.x = Mathf.Clamp(currentPosition.x, screenLeft, screenRight);
        currentPosition.y = Mathf.Clamp(currentPosition.y, screenBottom, screenTop);

        // 更新玩家的位置
        transform.position = currentPosition;
    }
}
