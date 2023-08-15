using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatPlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int coinCount;
    private int maxCoinCount; //1 coin plus 10 gem
    [SerializeField] ParticleSystem YippeeSparkles;
    [SerializeField] TextMeshProUGUI CoinDisplay;

    bool alreadyRunEndOfLevelSequence;

    void Start()
    {
        coinCount = 0;
        maxCoinCount = 11;

        alreadyRunEndOfLevelSequence = false;
    }

    void Update()
    {
        CoinDisplay.GetComponent<TextMeshProUGUI>().text = $"{coinCount} / {maxCoinCount}"; 
        if (coinCount >= maxCoinCount)
        {
            if (!alreadyRunEndOfLevelSequence)
            {
                alreadyRunEndOfLevelSequence = true;
                YippeeSparkles.Play();
                Invoke("LoadNextLevel", 3);
            }
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        if (currentSceneIndex < maxSceneIndex)
        {
            SceneManager.LoadScene(currentSceneIndex+1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<ICollectable>() != null)
        {   //Makes the THING IT HITS run Collect function
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    coinCount += collectable.Collect(); //run script And add value
                    break;
                case CollectableType.Key:
                    break;
                case CollectableType.Gem:
                    coinCount += collectable.Collect();
                    break;
                case CollectableType.Special:
                    collectable.Collect(); //run the script
                    break;
            }
        }
    }
}