using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour 
{
	float xAxis, yAxis;
	[SerializeField]
	private Controller controller;
	[SerializeField]
	private GameObject bulletPrefab;
	[SerializeField]
	private Transform bulletSpawn;
	[SerializeField]
	private AudioSource fireSound;
	[SerializeField]
	private AudioSource reloadSound;
	[SerializeField]
	private AudioSource noAmmoSound;
	[SerializeField]
	private AudioSource cooldownSound;
	[SerializeField]
	private TextMeshProUGUI cooldownCounter;
	private float shootCooldown;
	private int currentScore;
	private int currentAmmo;
	[SerializeField]
	private UIHandler uiHandler;
	[SerializeField]
	GameObject ammoCratePrefab;
	bool canSpawnAmmo = true;



	void Start () 
	{
		currentAmmo = 5;
		currentScore = 0;
		uiHandler.UpdateScore(currentScore);
		uiHandler.UpdateAmmo(currentAmmo);
		fireSound = GameObject.Find("Fire sound").GetComponent<AudioSource>();
		reloadSound = GameObject.Find("Reload complete sound").GetComponent<AudioSource>();
		cooldownSound = GameObject.Find("Cooldown ticking sound").GetComponent<AudioSource>();
		noAmmoSound = GameObject.Find("No ammo sound").GetComponent<AudioSource>();
		shootCooldown = 2.1f;
		uiHandler.ShowGameOverScreen(false);
	}
	
	void Update ()
	{
		Input();
		Cooldown();
		if (UnityEngine.Input.GetButtonDown("Fire1") && shootCooldown <= 0)
		{
			if(currentAmmo == 0)
			{
				noAmmoSound.Play();
				uiHandler.ShowGameOverScreen(true);
			}
			else
			Shoot();
		}
		if(currentAmmo == 3 & canSpawnAmmo)
		{
			SpawnAmmoCrate();
		}
	}

	private void Cooldown()
	{
		cooldownCounter.text = shootCooldown.ToString("F1");
		shootCooldown = Mathf.Clamp(shootCooldown - 1 * Time.deltaTime, 0, 2);
	}

	private void Input()
	{
		xAxis = controller.x;
		yAxis = controller.y;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xAxis, yAxis, 0), Time.deltaTime);
	}

	void Shoot()
	{
		if(currentAmmo > 0)
		{
			SubAmmo(1);
			shootCooldown = 2;
			fireSound.Play();
			cooldownSound.Play();
			GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			bullet.GetComponent<Rigidbody>().velocity = -bullet.transform.forward * 40;
		}
	}

	public void AddScore(int _score)
	{
		currentScore = currentScore + _score;
		uiHandler.UpdateScore(currentScore);
	}

	public void AddAmmo(int _ammo)
	{
		currentAmmo = currentAmmo + _ammo;
		uiHandler.UpdateAmmo(currentAmmo);
	}

	public void SubAmmo(int _ammo)
	{
		currentAmmo = currentAmmo - _ammo;
		uiHandler.UpdateAmmo(currentAmmo);
	}

	void SpawnAmmoCrate()
	{
		if (canSpawnAmmo)
		{
			Quaternion target = Quaternion.Euler(-90, 0, 0);
			Instantiate(ammoCratePrefab, new Vector3(Random.Range(30, -19), 15, Random.Range(2,-39)),target);
			canSpawnAmmo = false;
		}
	}

}
