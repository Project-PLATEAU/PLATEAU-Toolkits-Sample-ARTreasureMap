using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// シーン操作機能を提供します。
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// メインシーンを再読み込みします。
        /// </summary>
        /// <remarks>
        /// ゲームクリア時にゲームを終了する際に使用されます。
        /// </remarks>
        [Preserve]
        public void ReloadMainScene()
        {
            SceneManager.LoadScene("Main");
        }
    }
}