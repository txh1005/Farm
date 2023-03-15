using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float speed;
    private Vector2 moveInput;
    private Animator amin;

    public Tilemap tilemap;
    public TileBase newTile;
    public Tilemap tilemap1;
    public TileBase newTile1;
    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Vector2.zero;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rigid.velocity = moveInput * speed;     
        moveInput.Normalize();
        if (moveInput!=Vector2.zero)
        {
            amin.SetFloat("X", moveInput.x);
            amin.SetFloat("Y", moveInput.y);
            amin.SetBool("isMoving", true);
        }
        else
        {
            amin.SetBool("isMoving", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            amin.SetBool("isWatering", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            amin.SetBool("isWatering", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            amin.SetBool("isChop", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            amin.SetBool("isChop", false);
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            amin.SetBool("isHoe", true);
        }*/
        if (Input.GetKeyUp(KeyCode.Space))
        {
            amin.SetBool("isHoe", false);
        }
        Vector3 playerPosition = transform.position;
        Vector3Int cellPosition = tilemap.WorldToCell(playerPosition);
        Vector3Int cellPosition1 = tilemap1.WorldToCell(playerPosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tilemap.GetTile(cellPosition) == null)
            {
                tilemap.SetTile(cellPosition, newTile);
            }
            else
            {
                tilemap1.SetTile(cellPosition1, newTile1);
            }
            amin.SetBool("isHoe", true);
        }
    }
}
