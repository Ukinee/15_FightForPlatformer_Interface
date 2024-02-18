using System.Collections;
using MyProject.Sources.Enemies;
using UnityEngine;

namespace MyProject.Sources.Players
{
    public class VampiricAbility : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemyLocator _enemyLocator;
        [SerializeField] private float _amount;
        [SerializeField] private float _duration;
        
        private Coroutine _routine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                EnemyHealth closestEnemy = _enemyLocator.GetClosestEnemy();

                if (closestEnemy != null && _routine == null)
                {
                    _routine = StartCoroutine(StartVampirism(closestEnemy));
                }
            }
        }

        private IEnumerator StartVampirism(EnemyHealth enemy)
        {
            float endTime = Time.time + _duration;

            while (Time.time < endTime)
            {
                if(enemy.Current <= 0)
                    break;
                
                enemy.TakeDamage(_amount * Time.deltaTime);
                _player.Heal(_amount * Time.deltaTime);

                yield return null;
            }

            _routine = null;
        }
    }
}
