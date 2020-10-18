using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    [SerializeField] private float m_speed = 3f;
    [SerializeField] Animator m_animator;
    [SerializeField] SpriteRenderer m_sprRen;
    [SerializeField] Rigidbody2D m_rigid;
    [SerializeField] GameObject m_rocketPrefab;
    [SerializeField] Transform m_firePos;
    Vector3 m_dir = Vector3.zero;
    void CreateRocket()
    {
        var obj = Instantiate(m_rocketPrefab);
        var projectile = obj.GetComponent<Rocket>();
        var dir = Vector3.zero;
        if (transform.eulerAngles.y == 0f)
        {
            dir = Vector3.right;
        }
        if (transform.eulerAngles.y == 180f)
        {
            dir = Vector3.left;
        }
        if (transform.eulerAngles.z == 90f)
        {
            dir = Vector3.up;
        }
        if (transform.eulerAngles.z == 270f)
        {
            dir = Vector3.down;
        }
        projectile.SetRocket(m_firePos.position, dir);
    }
    void Moving()
    {
        m_rigid.MovePosition(transform.position + m_dir * m_speed * Time.fixedDeltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_sprRen = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            m_dir = Vector3.left;
            Moving();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            m_dir = Vector3.right;
            Moving();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            m_dir = Vector3.up;
            Moving();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
            m_dir = Vector3.down;
            Moving();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateRocket();
        }
    }
}
