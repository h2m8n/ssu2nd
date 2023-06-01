using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Camera mainCamera;
    
    [Header("soundmanage")]
    [SerializeField] private AudioClip BulletShootSound;
    [SerializeField] private SoundManager mSoundManager;

    private readonly WaitForSeconds _cachedWaitForSeconds = new(1.0f);
    private readonly Queue<GameObject> _bulletPool = new();


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

       private IEnumerator UpdateShootCoroutine()
    {
        // 총알 사운드 재생
        mSoundManager.PlayFx(BulletShootSound, false);

        // 1초 대기
        yield return _cachedWaitForSeconds;

    }




}