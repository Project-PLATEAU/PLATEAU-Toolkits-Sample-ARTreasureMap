using JetBrains.Annotations;
using PlateauAR;
using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// ARアプリケーション設定UI
    /// </summary>
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] Vector3InputUI m_OffsetInputUI;
        [SerializeField] AROffsetControllerUI m_OffsetControllerUI;
        [SerializeField] Toggle m_OccluderToggle;
        [SerializeField] GameObject m_PositioningUIContainer;

        public Vector3InputUI OffsetInputUI => m_OffsetInputUI;
        public AROffsetControllerUI OffsetControllerUI => m_OffsetControllerUI;
        public Toggle OccluderToggle => m_OccluderToggle;

        /// <summary>
        /// アクティブ・非アクティブを切り替えます。
        /// </summary>
        /// <remarks>
        /// シーンのボタンのコールバックに設定されています。
        /// </remarks>
        [UsedImplicitly]
        public void SwitchActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        /// <summary>
        /// 位置調整UIの表示を切り替えます。
        /// </summary>
        /// <remarks>
        /// 位置調整は<see cref="PlateauToolkit.AR.PlateauARPositioning" />を使用している際に
        /// 利用できる機能のため、<see cref="PlateauToolkit.AR.PlateauARMarkerCityModel" />を
        /// 使用する場合は表示になります。
        /// </remarks>
        public void SetPositioningUIEnable(bool enable)
        {
            m_PositioningUIContainer.SetActive(enable);
        }
    }
}