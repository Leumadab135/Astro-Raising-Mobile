using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    //Attributes
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private List<Item> _spawnList;
    [SerializeField] private Item _mineralItem;
    private float _minSpawnTime = 0.5f;
    private float _maxSpawnTime = 3;
    private float _nextSpawnTime;
    private float _cronoTime = 0;
    private bool _mineralAdded = false;

    void Start()
    {
        ResetTime();
    }

    void Update()
    {
        _cronoTime += Time.deltaTime;

        if (_cronoTime > _nextSpawnTime)
        {
            ResetTime();
            SpawnItem();
        }

        //Difficulty progression (add item after certain level)
        AddMineralItem();
        DestroySpawner();
    }


    private void ResetTime()
    {
        _cronoTime = 0;
        _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void SpawnItem()
    {
        //Random Object from a List
        int index = Random.Range(0, _spawnList.Count);
        float xPos = Random.Range(-7, 7);

        //Spawn Item in a random position
        Vector2 itemPosition = new Vector2(xPos, transform.position.y);
        Item newItem = Instantiate(_spawnList[index], itemPosition, Quaternion.identity);

        //Spawn with torque
        newItem.GetComponent<Rigidbody2D>().AddTorque(70);

        //Difficulty progression
        if (_maxSpawnTime < _minSpawnTime)
            _maxSpawnTime -= 0.2f;
    }

    private void AddMineralItem()
    {
        if (_playerTransform.position.y > 116 && !_mineralAdded)
        {
            _spawnList.Add(_mineralItem);
            _mineralAdded = true;
        }
    }

    private void DestroySpawner()
    {
        if (_playerTransform.position.y > 279)
        {
            Destroy(gameObject);
        }
    }
}

