using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// 常にカメラの方を向くオブジェクトを設定します。
    /// </summary>
    class BillboardSprite : MonoBehaviour
    {
        const float k_TransparentDistance = 5;
        SpriteRenderer m_SpriteRenderer;

        void Awake()
        {
            TryGetComponent(out m_SpriteRenderer);
        }

        void Update()
        {
            if (Camera.main == null)
            {
                return;
            }

            transform.forward = -Camera.main.transform.forward;
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            m_SpriteRenderer.color = distance < k_TransparentDistance ?
                new Color(1, 1, 1, distance / k_TransparentDistance) :
                new Color(1, 1, 1, 1);
        }
    }
}