using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Linq;
using System.Collections.Generic;



public class Player : MonoBehaviour
{

    
    public float maxHealth;
    public float currentHealth;
    public int knockbackForce;
    Vector3 knockbackDir;

    SerialPort serialPort = new SerialPort("COM4", 115200);


    void Start ()
    {

        serialPort.Open();
        serialPort.ReadTimeout = 100;
        maxHealth = 100;
        currentHealth = 100;
    }

    private void Update()
    {
        //Checking if serial port is open
        if (serialPort.IsOpen)  
        {
            try
            {
                //Need to write a char to start reading from dmp
                serialPort.Write("s");
                //On read event
                SerialEvent(serialPort);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    void FixedUpdate ()
    {
        //Checking if player is alive. If not, destroy
        if (currentHealth <= 0)
        {
            DestroyObject(gameObject);
        }
	}

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

    void SerialEvent(SerialPort myPort)
    {
        
        string buffer = serialPort.ReadLine();

        if (buffer != null)
        {
            if(buffer.Contains("ypr"))
            {
                
                string[] values = buffer.Split('|');
                foreach (string s in values)
                {
                    Debug.Log(s);
                }
            }
           // Debug.Log(buffer);
        }
    }


}
