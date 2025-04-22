using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    [SerializeField] private string victorySceneName = "MainMenu";
    [SerializeField] private float sceneLoadDelay = 1.5f;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool allEnemiesDead = false;

    private void Awake()
    {
        // Implementação do Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void RegisterEnemy(GameObject enemy)
    {
        if (!activeEnemies.Contains(enemy))
        {
            activeEnemies.Add(enemy);
        }
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            CheckAllEnemiesDefeated();
        }
    }

    private void CheckAllEnemiesDefeated()
    {
        if (activeEnemies.Count == 0 && !allEnemiesDead)
        {
            allEnemiesDead = true;
            Invoke(nameof(LoadVictoryScene), sceneLoadDelay);
        }
    }

    private void LoadVictoryScene()
    {
        if (!string.IsNullOrEmpty(victorySceneName))
        {
            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            Debug.LogWarning("Victory scene name not set in EnemyManager!");
        }
    }
}