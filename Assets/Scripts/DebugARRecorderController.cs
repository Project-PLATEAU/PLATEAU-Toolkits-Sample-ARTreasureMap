using PlateauToolkit.AR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.TreasureMap
{
    class DebugARRecorderController : MonoBehaviour
    {
        [SerializeField] ARCoreSessionRecorder m_SessionRecorder;
        [SerializeField] Button m_StartRecordButton;
        [SerializeField] Button m_StopPlaybackButton;
        [SerializeField] Button m_StartPlaybackButtonPrefab;

        readonly List<GameObject> m_PlaybackButtons = new();

        void OnEnable()
        {

            if (!m_SessionRecorder.GetController(out ARCoreSessionRecorder.RecorderController controller))
            {
                return;
            }

            m_StartRecordButton.onClick.AddListener(() =>
            {
                if (controller.IsRecording())
                {
                    controller.StopRecording();
                    RefreshPlaybacks(controller);
                }
                else
                {
                    controller.StartRecording(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".mp4");
                }
            });

            RefreshPlaybacks(controller);

            m_StopPlaybackButton.transform.SetAsLastSibling();
            m_StopPlaybackButton.onClick.AddListener(() =>
            {
                controller.StopPlayback();
            });

            StartCoroutine(UpdateButton(controller));
        }

        void RefreshPlaybacks(ARCoreSessionRecorder.RecorderController controller)
        {
            m_StartPlaybackButtonPrefab.gameObject.SetActive(false);
            foreach (GameObject playbackButton in m_PlaybackButtons)
            {
                Destroy(playbackButton);
            }
            m_PlaybackButtons.Clear();
            foreach (string path in m_SessionRecorder.GetPlaybackPaths())
            {
                Button button = Instantiate(
                    m_StartPlaybackButtonPrefab, m_StartPlaybackButtonPrefab.transform.parent, false);
                button.gameObject.SetActive(true);
                m_PlaybackButtons.Add(button.gameObject);
                button.GetComponentInChildren<TMP_Text>().text = Path.GetFileName(path);
                button.onClick.AddListener(() =>
                {
                    controller.StartPlayback(path);
                });
            }
        }

        IEnumerator UpdateButton(ARCoreSessionRecorder.RecorderController controller)
        {
            while (true)
            {
                if (controller.IsRecording())
                {
                    m_StartRecordButton.GetComponentInChildren<TMP_Text>().text = "レコードを終了";
                }
                else
                {
                    m_StartRecordButton.GetComponentInChildren<TMP_Text>().text = "レコードを開始";
                }
                yield return null;
            }
        }

        void OnDisable()
        {
            m_StartRecordButton.onClick.RemoveAllListeners();
            m_StopPlaybackButton.onClick.RemoveAllListeners();
        }
    }
}