using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int knockbackForce;
    Vector3 knockbackDir;

    // Use this for initialization
    void Start ()
    {
        maxHealth = 100;
        currentHealth = 100;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Checking if player is alive. If not, destroy
        if (currentHealth <= 0)
        {
            DestroyObject(gameObject);
        }
	}

    //Collision handler
    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Enemy")
        {
            //Calculate Angle Between the collision point and the player
            knockbackDir = _col.contacts[0].point - transform.position;
            //We then get the opposite (-Vector3) and normalize it
            knockbackDir = -knockbackDir.normalized;
            //Apply knockback
            ApplyKnockback();
        }
    }

    public void ApplyDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, 100);
        Debug.Log("-" + _damage);
        Debug.Log("Current hp:" + currentHealth);
    }

    public void Heal(float _healAmmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + _healAmmount, 0, 100);
    }

    void ApplyKnockback()
    {
        //Adding force opposite to collision direction
        GetComponent<Rigidbody>().AddForce(knockbackDir * knockbackForce);
    }

   




    /*void GhostForm(bool isEnabled, Collider _collidedWith)
    {
        Color color = GetComponent<Renderer>().material.color;
        if (isEnabled)
        {
            //Setting transparency to 50% when in ghost mode      
            color.a = .5f;
            GetComponent<Renderer>().material.SetColor("_Color", color);
            //==========================================================
            //Ignoring collison with the enemy
            Physics.IgnoreCollision(_collidedWith, GetComponent<Collider>(), true);
            Debug.Log("ignoring");
        }
        else
        {
            Physics.IgnoreCollision(_collidedWith, GetComponent<Collider>(), false);
            isGhost = false;
            //Setting transparency to 50% when in ghost mode
            color.a = 1f;
            GetComponent<Renderer>().material.SetColor("_Color", color);
            //==========================================================
            Debug.Log("not ignoring");
        }

    }*/

}
