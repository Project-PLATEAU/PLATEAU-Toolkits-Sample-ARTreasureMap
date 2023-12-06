using TMPro;
using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// 画面上部スナックバーUI
    /// </summary>
    public class SnackbarUI : MonoBehaviour
    {
        [SerializeField] TMP_Text m_Message;

        /// <summary>
        /// スナックバーに表示するメッセージを設定します。
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            m_Message.text = message;
        }
    }
}