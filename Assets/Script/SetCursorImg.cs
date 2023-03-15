using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorImg : MonoBehaviour
{
    public Texture2D cursor;
    private void OnMouseDrag()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
