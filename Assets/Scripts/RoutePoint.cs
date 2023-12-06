using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// AR空間上のルート上の一点を表現します。
    /// </summary>
    /// <remarks>
    /// プレイヤーが目指すチェックポイントとそのチェックポイントの道を表現するルートポイントの
    /// 2種類の<see cref="RoutePoint" />が存在します。
    /// </remarks>
    public class RoutePoint : MonoBehaviour
    {
        /// <summary>チェックポイントかどうか</summary>
        [SerializeField] bool m_IsCheckPoint;

        /// <inheritdoc cref="m_IsCheckPoint" />
        public bool IsCheckPoint => m_IsCheckPoint;
    }
}