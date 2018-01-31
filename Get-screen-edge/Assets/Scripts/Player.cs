using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private MainCamera mainCamera;
    [SerializeField]
    private float speed;

    /// <summary>
    /// Spriteの幅を取得
    /// </summary>
    /// <value>The width of the sprite.</value>
    public float SpriteWidth
    {
        get
        {
            var spr = gameObject.GetComponent<SpriteRenderer>();
            return spr.sprite.bounds.size.x;
        }
    }

    /// <summary>
    /// Spriteの高さを取得
    /// </summary>
    /// <value>The height of the sprite.</value>
    public float SpriteHeight
    {
        get
        {
            var spr = gameObject.GetComponent<SpriteRenderer>();
            return spr.sprite.bounds.size.y;        
        }
    }

    private void Update()
    {
        var vec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        var movePos = transform.position + vec * speed * Time.deltaTime;
        transform.position = ClampPosition(movePos);
    }

    /// <summary>
    /// 座標に制限をかける
    /// </summary>
    /// <returns>The position.</returns>
    /// <param name="_pos">Position.</param>
    Vector3 ClampPosition(Vector3 _pos)
    {
        var x = Mathf.Clamp(_pos.x, mainCamera.Left + (SpriteWidth / 2.0f), mainCamera.Right - (SpriteWidth / 2.0f));
        var y = Mathf.Clamp(_pos.y, mainCamera.Bottom + (SpriteHeight / 2.0f), mainCamera.Top - (SpriteHeight / 2.0f));
        return new Vector3(x, y, 0);
    }
}
