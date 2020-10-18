using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStone : MonoBehaviour
{
    [SerializeField] float m_stoneSpeed = 3.0f;
    float m_lifetTime = 3.0f;
    void DestroyStone()
    {
        Destroy(gameObject);
    }
    public void SetStone(Vector3 stonePos)
    {
        transform.position = stonePos;
        Invoke("DestroyStone", m_lifetTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Wall"))
        {
            DestroyStone();
        }
        if(collision.transform.tag.Equals("Player"))
        {
            DestroyStone();
        }
        if(collision.transform.tag.Equals("Rocket"))
        {
            DestroyStone();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Wall"))
        {
            DestroyStone();
        }
        if(collision.transform.tag.Equals("Player"))
        {
            DestroyStone();
        }
        if(collision.transform.tag.Equals("Rocket"))
        {
            DestroyStone();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * m_stoneSpeed * Time.deltaTime;
    }
}
