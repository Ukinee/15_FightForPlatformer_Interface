using MyProject.Sources.Players;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("CollisionGemScore");

            gameObject.SetActive(false);
        }
    }
}
