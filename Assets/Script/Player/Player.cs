using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Camera mainCamera;
    public int maxHealth = 3; // 최대 HP
    public int currentHealth; // 현재 HP
    public static Player instance;
    public int clear = 5;

    // [Header("soundmanage")]
    // [SerializeField] private AudioClip BulletShootSound;
    // [SerializeField] private SoundManager mSoundManager;

    private readonly WaitForSeconds _cachedWaitForSeconds = new(1.0f);
    private readonly Queue<GameObject> _bulletPool = new();

    private void Awake() {
        if(Player.instance == null) {
            Player.instance = this;
        }
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 targetPosition = GetMouseWorldPosition();
        transform.position = targetPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    // private IEnumerator UpdateShootCoroutine()
    // {
    //     // 총알 사운드 재생
    //     mSoundManager.PlayFx(BulletShootSound, false);

    //     // 1초 대기
    //     yield return _cachedWaitForSeconds;

    // }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            // Die(); // HP가 0 이하이면 사망 처리
            Debug.Log("Player Damage");
            SceneManager.LoadScene("Gameover");
        }
    }


}