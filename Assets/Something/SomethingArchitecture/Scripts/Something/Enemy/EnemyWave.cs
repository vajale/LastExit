using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Something.Scripts.Something.Characters.Enemy
{
    // public class EnemyWave
    // {
    //     private Player.Player _player;
    //     private readonly Enemy[] _enemys;
    //     protected readonly List<Transform> _spawnPositions;
    //     private readonly List<Enemy> _currentEnemies;
    //     private bool _isGenerated;
    //
    //     public EnemyWave(Enemy[] enemy, List<Transform> spawnPositions)
    //     {
    //         _spawnPositions = spawnPositions;
    //         _enemys = enemy;
    //         _currentEnemies = new List<Enemy>();
    //         _isGenerated = false;
    //     }
    //
    //     public void CreateSingleEnemy(int enemyIndex, Vector3 position)
    //     {
    //         CreateEnemy(_enemys[enemyIndex], position);
    //     }
    //
    //     public void SetTarget(Player.Player target)
    //     {
    //         if (target == null)
    //             return;
    //
    //         _player = target;
    //     }
    //
    //     public bool IsHaveAliveEnemies()
    //     {
    //         if (_isGenerated == false)
    //             return false;
    //
    //         int count = 0;
    //
    //         //переделать на sender
    //         foreach (var enemy in _currentEnemies)
    //         {
    //             var enemys = Object.FindObjectsOfType<Enemy>();
    //             count = enemys.Count();
    //         }
    //
    //         Debug.Log("Количество живых врагов - " + count);
    //
    //         return count != 0;
    //     }
    //
    //     private Enemy CreateEnemy(IReadOnlyList<Enemy> source, Vector3 position)
    //     {
    //         var newEnemy = Object.Instantiate(source[Random.Range(0, source.Count)], position, Quaternion.identity);
    //         newEnemy.Init(_player);
    //
    //         return newEnemy;
    //     }
    //
    //     private Enemy CreateEnemy(Enemy enemy, Vector3 position)
    //     {
    //         var newEnemy = Object.Instantiate(enemy, position, Quaternion.identity);
    //         // newEnemy.Init(_player);
    //
    //         return newEnemy;
    //     }
    //
    //     public void CreateEnemyWave(int enemyCount)
    //     {
    //         foreach (var position in _spawnPositions)
    //         {
    //             for (int i = 0; i < enemyCount; i++)
    //             {
    //                 var enemy = CreateEnemy(_enemys, position.position);
    //                 _currentEnemies.Add(enemy);
    //             }
    //         }
    //
    //         _isGenerated = true;
    //     }
    //}
}