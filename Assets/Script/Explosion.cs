﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float m_lifeTime = 0.3333f;

    float m_time;
    public void Explosive(Vector3 m_explo)
    {
        transform.position = m_explo;
        Invoke("RemoveExplosive", m_lifeTime);
    }
    void RemoveExplosive()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_time -= Time.deltaTime;
        if (m_time == 0)
        {
            RemoveExplosive();
        }
    }
}
