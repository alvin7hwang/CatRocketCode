using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCat : MonoBehaviour
{
    [Header("이동")]
    [SerializeField]
    private float m_speed = 3f;
    [SerializeField]
    SpriteRenderer m_sprRen;
    [SerializeField]
    Rigidbody2D m_rigid;
    [SerializeField]
    GameObject m_rocketPrefab;
    [SerializeField]
    Transform m_rocketPos;
    Vector3 m_dir = Vector3.zero;
    Vector3 m_upDown = Vector3.zero;
    bool m_enableMoveCat = false;
    void AniEvent_CreateRocket()
    {
        var obj = Instantiate(m_rocketPrefab);
        var rocket = obj.GetComponent<Rocket>();
        var dir = Vector3.zero;
        if(transform.eulerAngles.y == 0f)
        {
            dir = Vector3.left;
        }
        if(transform.eulerAngles.y == 180f)
        {
            dir = Vector3.right;
        }
        if(transform.eulerAngles.z == 90f)
        {
            dir = Vector3.down;
        }
        if(transform.eulerAngles.z == 270f)
        {
            dir = Vector3.up;
            Debug.Log("dir = " + dir);
        }
        rocket.SetRocket(m_rocketPos.position, dir);
    }
    private void moveCat()
    {
        m_rigid.MovePosition(transform.position + m_dir * m_speed * Time.fixedDeltaTime);
        m_enableMoveCat = false;
    }
    // Start is called before the first frame update
    private void Start()
    {
        m_sprRen = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //m_sprRen.flipX = false;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            m_dir = Vector3.right;
            m_enableMoveCat = true;
            //transform.position += new Vector3(1, 0, 0) * m_speed *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //m_sprRen.flipX = true;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            m_dir = Vector3.left;
            m_enableMoveCat = true;
            //transform.position += new Vector3(-1, 0, 0) * m_speed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("transform.eulerAngles CreateRocket = " + transform.eulerAngles);
            AniEvent_CreateRocket();
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
            m_dir = Vector3.up;
            m_enableMoveCat = true;
            Debug.Log("transform.eulerAngles = " + transform.eulerAngles);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            m_dir = Vector3.down;
            m_enableMoveCat = true;
        }
        if(m_enableMoveCat)
        {
            moveCat();
        }

    }
}
