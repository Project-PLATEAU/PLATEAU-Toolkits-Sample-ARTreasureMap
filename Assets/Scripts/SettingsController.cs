using PlateauToolkit.AR;
using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// AR設定を制御します。
    /// </summary>
    public class SettingsController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] SettingsUI m_ARSettingsUI;

        [Header("AR Components")]
        [SerializeField] PlateauARPositioning m_ARPositioning;
        [SerializeField] Material m_OccluderMaterial;

        void Awake()
        {
            if (m_ARPositioning != null)
            {
                m_ARSettingsUI.OffsetInputUI.OnApplied.AddListener(() =>
                {
                    m_ARPositioning.SetOffset(m_ARSettingsUI.OffsetInputUI.Value);
                });
                m_ARSettingsUI.OffsetControllerUI.OnOffsetChanged += offsetDelta =>
                {
                    if (!m_ARPositioning.GetOffset(out Vector3 offset))
                    {
                        return;
                    }

                    offset += offsetDelta;
                    m_ARPositioning.SetOffset(offset);
                    m_ARSettingsUI.OffsetInputUI.Value = offset;
                };
            }
            else
            {
                m_ARSettingsUI.SetPositioningUIEnable(false);
            }

            m_ARSettingsUI.OccluderToggle.onValueChanged.AddListener(isOn =>
            {
                Color color = m_OccluderMaterial.color;
                color.a = isOn ? 0.5f : 0f;
                m_OccluderMaterial.color = color;
            });
        }
    }
}