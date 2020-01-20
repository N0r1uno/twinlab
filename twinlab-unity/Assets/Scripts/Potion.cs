﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public ParticleSystem ps;
    public enum Type
    {
        freeze,
        poison,
        purple,
        fire,
        power
    }

    public Type type;
    public float range;
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider.enabled = false;
        ps.gameObject.SetActive(true);
        ps.loop = false;
        ps.Play();
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<SpriteRenderer>().sprite = null;
        switch (type)
        {

            default:
                break;
            case Type.fire:
                List<Actor> actors = getAllHitActors();
                foreach (Actor a in actors)
                {
                    a.TakeDamage(damage);
                }
                break;
            case Type.freeze:
                break;
            case Type.poison:
                break;
            case Type.power:
                break;
            case Type.purple:
                break;
        }
    }

    List<Actor> getAllHitActors()
    {
        List<Actor> allHitActors = new List<Actor>();
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i].gameObject.GetComponents<Actor>().Length > 0){
                RaycastHit2D hit = Physics2D.Raycast(transform.position, collisions[i].transform.position - transform.position);
                if (hit.collider.gameObject.Equals(collisions[i].gameObject))
                {
                    allHitActors.Add(collisions[i].GetComponent<Actor>());
                }
            }
        }
        return allHitActors;

    }

    
}