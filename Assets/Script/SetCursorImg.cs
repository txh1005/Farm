using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorImg : MonoBehaviour
{
    public Texture2D cursorSprite;
    public Texture2D defaultCursor;
    void Start()
    {
        // lưu Texture2D của ảnh ban đầu
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto); // đổi cursor thành ảnh khi click chuột
    }

    void OnMouseUp()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto); // đổi cursor về ảnh ban đầu khi thả chuột
    }
}
