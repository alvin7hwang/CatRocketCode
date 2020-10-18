using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject m_enemyPrefab;
    [SerializeField] Transform m_changePos;
    [SerializeField] Rigidbody2D m_enemyRigid;
    [SerializeField] float m_movingTime = 0.001f;
    [SerializeField] float m_enemySpeed = 3f;
    [SerializeField] Transform m_stonePos;
    [SerializeField] GameObject m_stonePrefab;
    Vector3 m_enemyDir = Vector3.down;
    [SerializeField] float m_shootTime = 1f;
    [SerializeField] float m_shootTimeDefault = 1f;
    void EnemyDestroy()
    {
        Destroy(gameObject);
    }
    void CreateStone()
    {
        var obj = Instantiate(m_stonePrefab);
        var projectile = obj.GetComponent<EnemyStone>();
        projectile.SetStone(m_stonePos.position);
    }
    void EnemyMoving()
    {
        m_enemyRigid.MovePosition(transform.position + m_enemyDir * m_enemySpeed * Time.fixedDeltaTime);
    }
    void ChangeDir()
    {
        m_enemyDir = m_enemyDir * -1;
    }
    void ShootStoneTime()
    {
        m_shootTime -= Time.deltaTime;
        if(m_shootTime <= 0)
        {
            CreateStone();
            m_shootTime = m_shootTimeDefault;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Rocket"))
        {
            EnemyDestroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Rocket"))
        {
            EnemyDestroy();
        }
    }
    private void Awake()
    {
        m_enemyPrefab = GetComponent<GameObject>();
        m_changePos = GetComponent<Transform>();
        m_enemyRigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoving();
        ChangeDir();
        ShootStoneTime();
        //Invoke("ChangeDir", m_movingTime);
    }
}
