
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.PostProcessing;


public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int knockbackForce;
    public int score;
    public TrackGen trackGeneratorScript;
    Vector3 knockbackDir;
    [SerializeField]
    UIHandler uiHandler;
    AudioSource audioSource;
    [SerializeField]
    public AudioClip ripSound;
    public AudioClip scoreSound;
    public PlateInput plate;
    bool ripSoundIsPlaying;
    float minimumChromaticAb = 0;
    float maximumChromaticAb = 1;
    public PostProcessingProfile postPProfile;
    ChromaticAberrationModel.Settings chromAbSettings;
    int smooth = 30;
    bool isHit;
    bool isDead;
    public Animator animator;



    void Start ()
    {
        currentHealth = 100;
        audioSource = GetComponent<AudioSource>();
        ripSoundIsPlaying = false;
        chromAbSettings = postPProfile.chromaticAberration.settings;
        chromAbSettings.intensity = 0;
        postPProfile.chromaticAberration.settings = chromAbSettings;
        isHit = false;
        isDead = false;
        Time.timeScale = 1;
    }

    private void Update()
    { 
           /* chromAbSettings.intensity = Mathf.Lerp(0, 1, Time.deltaTime * smooth);
            postPProfile.chromaticAberration.settings = chromAbSettings;*/    
    }

    void FixedUpdate ()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            plate.speed = 0;
            uiHandler.DisplayGameOverHud(true);
            if (ripSoundIsPlaying == false)
            {
                audioSource.PlayOneShot(ripSound, .5f);
                ripSoundIsPlaying = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                animator.SetBool("isDead", isDead);
                Time.timeScale = 0;
            }

        }
    }

    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Enemy")
        {
            //Calculate Angle Between the collision point and the player
            knockbackDir = _col.contacts[0].point - transform.position;
            knockbackDir = -knockbackDir.normalized;
            Hit();
        }
    }

    public void Hit()
    {
        isHit = true;
        ApplyKnockback();
        ApplyDamage(20);
    }


    private void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Trigger Spawn")
        {
            trackGeneratorScript.SpawnTrack();
            AddScore(1);
        }
    }

    public void ApplyDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, 100);
        uiHandler.UpdateHealth(currentHealth);

    }

    public void AddScore(int _score)
    {
        score = score + _score;
        uiHandler.UpdateScore(score);
        audioSource.PlayOneShot(scoreSound, .5f);
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

}
