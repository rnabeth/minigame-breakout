﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GameManager instance = null;

	private GameObject clonePaddle;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		Setup();
	}

	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main");
	}

	void SetupPaddle()
	{
		Vector3 spawnPoint = new Vector3(0, -9.5f, 0);
		clonePaddle = Instantiate(paddle, spawnPoint, Quaternion.identity) as GameObject;
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}
