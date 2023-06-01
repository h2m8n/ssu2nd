using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1; // 최대 HP
    private int currentHealth; // 현재 HP

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // "Bullet" 태그를 가진 오브젝트와 충돌했을 때
        {
            Debug.Log("Collision");
            TakeDamage(1); // HP를 1 감소시킴
        }
        if (collision.gameObject.CompareTag("Ground")) // "Bullet" 태그를 가진 오브젝트와 충돌했을 때
        {
            Debug.Log("Collision");
            Die();
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die(); // HP가 0 이하이면 사망 처리
        }
    }

    private void Die()
    {
        // 사망 처리 로직을 구현하세요.
        Destroy(gameObject);
        


    }
}
