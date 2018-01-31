using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour 
{
    [SerializeField]
    private Camera mainCamera;

    /// <summary>
    /// 右端
    /// </summary>
    /// <value>The right.</value>
    public float Right  { get { return getScreenBottomRight().x; } }
    /// <summary>
    /// 左端
    /// </summary>
    /// <value>The left.</value>
    public float Left   { get { return getScreenTopLeft().x; } }
    /// <summary>
    /// 上端
    /// </summary>
    /// <value>The top.</value>
    public float Top    { get { return getScreenTopLeft().y; } }
    /// <summary>
    /// 下端
    /// </summary>
    /// <value>The bottom.</value>
    public float Bottom { get { return getScreenBottomRight().y; } }

    void Start()
    {
        // カメラオブジェクトを取得します
        GameObject obj = GameObject.Find("Main Camera");
        mainCamera = obj.GetComponent<Camera>();

        // 座標値を出力
        Debug.Log("右端" + Right.ToString());
        Debug.Log("左端" + Left.ToString());

    }

    /// <summary>
    /// 画面の左上をの座標を取得
    /// </summary>
    /// <returns>The screen top left.</returns>
    private Vector3 getScreenTopLeft()
    {
        Vector3 topLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    /// <summary>
    /// 画面の右下の座標を取得
    /// </summary>
    /// <returns>The screen bottom right.</returns>
    private Vector3 getScreenBottomRight()
    {
        Vector3 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }
}