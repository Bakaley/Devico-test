using System.Collections.Generic;
using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [InlineEditor]
    [SerializeField] private LevelGenerationConfig _config;
    private List<Item> _feedList = new List<Item>();

    [SerializeField] private Vector2 _leftDownArenaPoint = new Vector2(-100f, -100f);
    [SerializeField] private Vector2 _rightUpArenaPoint = new Vector2(100f, 100f);
    
    private void Awake()
    {
        InitFeedList();
        GenerateLevel();
    }

    private void InitFeedList()
    {
        foreach (var pair in _config.FeedPercentTable)
        {
            for (int i = 0; i < pair.Value; i++)
            {
                _feedList.Add(pair.Key);
            }
        }
    }

    private void GenerateLevel()
    {
        bool generateBooster;
        Item itemToCreate;
        for (int i = 0; i < _config.ObjectsCount; i++)
        {
            generateBooster = Random.Range(0, 99) >= _config.BoosterSpawnChance;
            if (generateBooster)
            {
                itemToCreate = GetRandomFeed();
            }
            else
            {
                itemToCreate = GetRandomBooster();
            }
            Instantiate(itemToCreate.gameObject, new Vector3(
                Random.Range(_leftDownArenaPoint.x, _rightUpArenaPoint.x), 
                Random.Range(_leftDownArenaPoint.y, _rightUpArenaPoint.y),
                0),
                Quaternion.identity);
        }
    }

    private Item GetRandomFeed()
    {
        return _feedList[Random.Range(0, _feedList.Count)];
    }

    private Item GetRandomBooster()
    {
        return _config.BoosterList[Random.Range(0, _config.BoosterList.Count)];
    }
}
