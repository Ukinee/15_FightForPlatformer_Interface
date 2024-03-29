using MyProject.Sources.Players;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private int _healthCount = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.Heal(_healthCount);
            gameObject.SetActive(false);
        }
    }
}
