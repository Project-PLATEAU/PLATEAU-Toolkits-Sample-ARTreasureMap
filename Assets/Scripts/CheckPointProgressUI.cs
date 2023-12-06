using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントの進捗を表示するUI
    /// </summary>
    public class CheckPointProgressUI : MonoBehaviour
    {
        [SerializeField] Image[] m_CheckPointImages;

        void Start()
        {
            foreach (Image checkPointImage in m_CheckPointImages)
            {
                checkPointImage.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
            }
        }

        /// <summary>
        /// すでにコンプリートしたチェックポイントの数を設定します。
        /// </summary>
        /// <param name="count"></param>
        public void SetCompletedCount(int count)
        {
            Debug.Log($"Set Complete Count: {count}");
            for (int i = 0; i < Mathf.Min(count, m_CheckPointImages.Length); i++)
            {
                Debug.Log($"Set complete {i} icon");
                m_CheckPointImages[i].color = new Color(1, 1, 1, 1);
            }
        }
    }
}