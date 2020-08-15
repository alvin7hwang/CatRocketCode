using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    float m_speed = 8;
    Vector3 m_dir;
    SpriteRenderer m_sprRen;
    Rigidbody2D m_rigid;
    [SerializeField]
    float m_lifeTime = 3.0f;
    public void SetRocket(Vector3 pos, Vector3 dir)
    {
        if(dir == Vector3.left)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if(dir == Vector3.right)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(dir == Vector3.up)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        if(dir == Vector3.down)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        m_dir = dir;
        transform.position = pos;
        Invoke("RemoveRocket", m_lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("wall"))
        {
            RemoveRocket();
        }
    }
    void RemoveRocket()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        m_sprRen = GetComponent<SpriteRenderer>();
        m_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_dir * m_speed * Time.deltaTime;
    }
}
