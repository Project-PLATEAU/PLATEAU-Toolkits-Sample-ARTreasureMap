using Google.XR.ARCoreExtensions;
using PlateauToolkit.AR;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントを管理します。
    /// </summary>
    public class CheckPointManager : MonoBehaviour
    {
        const float k_CheckPointDistance = 5;
        const float k_RoutePointMargin = 5;

        [SerializeField] RoutePoint[] m_CheckPoints;
        [SerializeField] Camera m_ARCamera;
        [SerializeField] GameObject m_PathPointPrefab;

        [SerializeField] Transform m_PathPointParent;

        [SerializeField] CheckPointProgressUI m_CheckPointProgressUI;
        [SerializeField] GameObject m_CompleteModalUI;
        [SerializeField] SnackbarUI m_SnackbarUI;
        [SerializeField] SnackbarUI m_CameraSnackbarUI;

        [SerializeField] bool m_IsShowingCompletedCheckpointEffect;

        [SerializeField] AREarthManager m_EarthManager;
        [SerializeField] PlateauARMarkerCityModel m_ARMarkerCityModel;

        public bool IsShowingCompletedCheckpointEffect
        {
            get => m_IsShowingCompletedCheckpointEffect;
            set
            {
                if (m_IsShowingCompletedCheckpointEffect != value)
                {
                    m_IsShowingCompletedCheckpointEffect = value;
                    OnCompletedCheckpointEffectChanged();
                }
            }
        }

        public event Action<int> OnCheckPointCompleted;

        readonly List<GameObject> m_PathPointGameObjects = new();

        int m_CheckPointCount;
        int m_CompletedCheckPointCount;
        int m_LastCompletedCheckPoint = -1;

        void OnCompletedCheckpointEffectChanged()
        {
            if (m_IsShowingCompletedCheckpointEffect)
            {
                // Nothing special is done while the completion effect is displayed.
            }
            else
            {
                if (m_CompletedCheckPointCount == m_CheckPointCount)
                {
                    m_SnackbarUI.gameObject.SetActive(false);
                    Debug.Log("All checkpoints completed!");
                    m_CompleteModalUI.SetActive(true);
                }
                else
                {
                    UpdateSnackbarText();
                }
            }
        }
        void Start()
        {
            m_CheckPointCount = m_CheckPoints.Count(p => p.IsCheckPoint);
            m_SnackbarUI.SetMessage("最初のチェックポイントを目指してください。");
            ShowPathPointsToNextCheckPoint();
        }

        void Update()
        {
            if (m_EarthManager != null)
            {
                GeospatialPose pose = m_EarthManager.CameraGeospatialPose;
                if (m_EarthManager.EarthTrackingState != TrackingState.Tracking ||
                    pose.HorizontalAccuracy > 1f ||
                    pose.VerticalAccuracy > 1f ||
                    pose.OrientationYawAccuracy > 30)
                {
                    m_CameraSnackbarUI.gameObject.SetActive(true);
                    m_CameraSnackbarUI.SetMessage("周囲の建物にカメラをかざしてください。");
                    return;
                }

                m_CameraSnackbarUI.gameObject.SetActive(false);
            }

            if (m_ARMarkerCityModel != null)
            {
                if (m_ARMarkerCityModel.CurrentTrackingStatus is null or TrackingState.None)
                {
                    m_CameraSnackbarUI.gameObject.SetActive(true);
                    m_CameraSnackbarUI.SetMessage("ARマーカーを読み取ってください。");
                    return;
                }

                m_CameraSnackbarUI.gameObject.SetActive(false);
            }

            RoutePoint nextCheckPoint = null;
            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    nextCheckPoint = m_CheckPoints[i];
                    break;
                }
            }

            if (nextCheckPoint == null)
            {
                return;
            }

            var nextCheckPointPosition = Vector3.ProjectOnPlane(
                nextCheckPoint.transform.position,
                nextCheckPoint.transform.up);
            var cameraPosition = Vector3.ProjectOnPlane(
                m_ARCamera.transform.position,
                nextCheckPoint.transform.up);
            float checkPointDistance = Vector3.Distance(nextCheckPointPosition, cameraPosition);

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C キーが押されました。テスト用のチェックポイント完了処理を実行します。");
                checkPointDistance = 0;
            }
#endif

            if (checkPointDistance <= k_CheckPointDistance)
            {
                CompleteCheckPoint();
            }
            else
            {
                return;
            }

            m_CompletedCheckPointCount++;
            OnCheckPointCompleted?.Invoke(m_CompletedCheckPointCount);
            Debug.Log($"Completed Check Points: {m_CompletedCheckPointCount}");

            m_CheckPointProgressUI.SetCompletedCount(m_CompletedCheckPointCount);
            m_SnackbarUI.SetMessage("コインを獲得しました！");
        }
        void UpdateSnackbarText()
        {
            if (m_CompletedCheckPointCount < m_CheckPointCount - 1)
            {
                m_SnackbarUI.SetMessage("次のチェックポイントを目指してください。");
            }
            else if (m_CompletedCheckPointCount == m_CheckPointCount - 1)
            {
                m_SnackbarUI.SetMessage("最後のチェックポイントを目指してください。");
            }
        }

        bool CompleteCheckPoint()
        {
            Debug.Log($"{nameof(CompleteCheckPoint)}");

            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    Debug.Log($"Completed a check point: {i}");
                    m_LastCompletedCheckPoint = i;
                    break;
                }
            }

            ClearPathPoints();
            return ShowPathPointsToNextCheckPoint();
        }

        void ClearPathPoints()
        {
            foreach (GameObject pathPoint in m_PathPointGameObjects)
            {
                Destroy(pathPoint);
            }
            m_PathPointGameObjects.Clear();
        }

        bool ShowPathPointsToNextCheckPoint()
        {
            Debug.Log($"{nameof(ShowPathPointsToNextCheckPoint)}: LastCompletedCheckPoint = {m_LastCompletedCheckPoint}");

            int nextCheckPointIndex = 0;
            RoutePoint nextCheckPoint = null;
            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    nextCheckPoint = m_CheckPoints[i];
                    nextCheckPointIndex = i;
                    break;
                }
            }

            if (nextCheckPoint == null)
            {
                return false;
            }

            for (int i = Mathf.Max(m_LastCompletedCheckPoint, 0); i < nextCheckPointIndex; i++)
            {
                RoutePoint routePoint = m_CheckPoints[i];
                RoutePoint nextPoint = m_CheckPoints[i + 1];

                if (!routePoint.IsCheckPoint)
                {
                    GameObject pathPoint = Instantiate(m_PathPointPrefab, m_PathPointParent, false);
                    m_PathPointGameObjects.Add(pathPoint);
                    pathPoint.transform.position = routePoint.transform.position;
                }

                Vector3 currentToNext = nextPoint.transform.position - routePoint.transform.position;
                Vector3 currentToNextDirection = currentToNext.normalized;
                float currentToNextDistance = currentToNext.magnitude;

                int pathPointCount = Mathf.CeilToInt(currentToNextDistance / k_RoutePointMargin) - 1;
                for (int j = 0; j < pathPointCount; j++)
                {
                    GameObject pathPoint = Instantiate(m_PathPointPrefab, m_PathPointParent, false);
                    m_PathPointGameObjects.Add(pathPoint);
                    pathPoint.transform.position =
                        routePoint.transform.position + (j + 1) * k_RoutePointMargin * currentToNextDirection;
                }

                Debug.Log($"Show Path: {i} -> {i + 1} ({pathPointCount} path points)");

                if (nextPoint.IsCheckPoint)
                {
                    break;
                }
            }

            return true;
        }

        void OnDrawGizmos()
        {
            if (m_CheckPoints == null)
            {
                return;
            }

            Gizmos.color = new Color(1, 1, 0, 0.7f);
            foreach (RoutePoint checkPoint in m_CheckPoints)
            {
                if (checkPoint != null && checkPoint.IsCheckPoint)
                {
                    Gizmos.DrawCube(checkPoint.transform.position, new Vector3(1, 3, 1));
                }
            }

            Gizmos.color = Color.green;
            for (int i = 0; i < m_CheckPoints.Length - 1; i++)
            {
                RoutePoint a = m_CheckPoints[i];
                RoutePoint b = m_CheckPoints[i + 1];

                if (a == null || b == null)
                {
                    continue;
                }

                Gizmos.DrawLine(a.transform.position, b.transform.position);
            }
        }
    }
}