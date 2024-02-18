using MyProject.Codebase.Healths.Model;
using MyProject.Codebase.Healths.Presenter;
using MyProject.Codebase.Healths.Views;
using UnityEngine;

namespace MyProject.Sources.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [field: SerializeField] public ContinuousBarView HealthView { get; private set; }
        
        private HealthPresenter _healthPresenter;

        private void Awake()
        {
            Health health = new Health(_maxHealth);
            
            _healthPresenter = new HealthPresenter(health, HealthView);
            _healthPresenter.Enable();
        }

        public void Heal(float healthCount)
        {
            _healthPresenter.RestoreHealth(healthCount);
        }

        public void TakeDamage(float damage)
        {
            _healthPresenter.TakeDamage(damage);
            _playerAnimation.PlayHurt();
        }
    }
}
