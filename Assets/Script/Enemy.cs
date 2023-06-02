using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1; // 최대 HP
    private int currentHealth; // 현재 HP

    [Header("soundmanage")]
    [SerializeField] private AudioClip enemyShot;
    [SerializeField] private AudioClip enemyGround;
    [SerializeField] private SoundManager mSoundManager;
    private readonly WaitForSeconds _cachedWaitForSeconds = new(1.0f);

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // "Bullet" 태그를 가진 오브젝트와 충돌했을 때
        {
            Debug.Log("Bullet Collision");

            Player.instance.clear -= 1;
            if(Player.instance.clear <= 0) {
                SceneManager.LoadScene("ClearScene");
            }
            // TakeDamage(1); // HP를 1 감소시킴
           
            mSoundManager.PlayFx(enemyShot, false);

            Die();
        }
        if (collision.gameObject.CompareTag("Ground")) // "Bullet" 태그를 가진 오브젝트와 충돌했을 때
        {
            Debug.Log("Ground Collision");

            Player.instance.TakeDamage(1);
            mSoundManager.PlayFx(enemyGround, false);
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
