using UnityEngine;
using System.Collections;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントのコイン型3Dオブジェクト
    /// </summary>
    public class CheckPointObject : MonoBehaviour
    {
        [SerializeField] CheckPointManager m_CheckPointManager;

        [SerializeField] GameObject m_NormalStatePrefab;
        [SerializeField] GameObject m_CompleteEffectPrefab;
        [SerializeField] GameObject m_CompletedStatePrefab;
        [SerializeField] int m_CheckPointIndex;
        [SerializeField] float m_CompleteEffectDuration = 10f;

        Camera m_MainCamera;
        GameObject m_NormalStateObject;
        GameObject m_CompleteEffectObject;

        void Start()
        {
            m_CheckPointManager.OnCheckPointCompleted += HandleCheckPointCompleted;

            m_MainCamera = Camera.main;
            m_NormalStateObject = Instantiate(m_NormalStatePrefab, transform.position, Quaternion.identity, transform);
        }

        void Update()
        {
            if (m_CompleteEffectObject != null && m_MainCamera != null)
            {
                AdjustEffectPositionAndRotation();
            }
        }

        void OnDestroy()
        {
            m_CheckPointManager.OnCheckPointCompleted -= HandleCheckPointCompleted;
        }
        void HandleCheckPointCompleted(int completedIndex)
        {
            if (completedIndex == m_CheckPointIndex)
            {
                Destroy(m_NormalStateObject);
                m_CheckPointManager.IsShowingCompletedCheckpointEffect = true;
                StartCoroutine(ShowAndDestroyCompleteEffect());
            }
        }

        IEnumerator ShowAndDestroyCompleteEffect()
        {
            ShowCompleteEffect();
            yield return new WaitForSeconds(m_CompleteEffectDuration);
            Destroy(m_CompleteEffectObject);
            Instantiate(m_CompletedStatePrefab, transform.position, Quaternion.identity, transform);
            m_CheckPointManager.IsShowingCompletedCheckpointEffect = false;
        }

        void ShowCompleteEffect()
        {
            m_CompleteEffectObject = Instantiate(m_CompleteEffectPrefab, transform.position, Quaternion.identity, transform);
        }

        void AdjustEffectPositionAndRotation()
        {
            const float distanceFromCamera = 5f;

            Vector3 cameraForward = m_MainCamera.transform.forward;
            Vector3 effectPosition = m_MainCamera.transform.position + cameraForward * distanceFromCamera;

            m_CompleteEffectObject.transform.position = effectPosition;
            m_CompleteEffectObject.transform.LookAt(m_MainCamera.transform);
        }
    }
}
