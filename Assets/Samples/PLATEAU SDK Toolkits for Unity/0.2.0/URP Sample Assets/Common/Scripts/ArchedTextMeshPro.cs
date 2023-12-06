using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class ArchedTextMeshPro : MonoBehaviour
{
    [Header("Arc Configuration")]
    public float m_InitialRotation = 270.0f; // ÉeÉLÉXÉgÇÃèâä˙âÒì]äpìx
    public float m_CharacterSpacing = 18.0f; // å ÇÃä‘äuÅiï∂éöä‘ÇÃäpìxÅj
    public float m_ArcRadius = 20.0f; // å ÇÃîºåa

    private bool m_IsInitialized = false;
    TMP_Text m_TextComponent;

    void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        Initialize();
    }

    void Update()
    {
        if (!m_IsInitialized)
        {
            Initialize();
        }

        UpdateCurveMesh();
    }
    void Initialize()
    {
        if (m_TextComponent == null)
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
        }
        UpdateCurveMesh();
        m_IsInitialized = true;
    }

    void UpdateCurveMesh()
    {
        if (m_TextComponent == null)
        {
            return;
        }

        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        int characterCount = textInfo.characterCount;

        if (characterCount == 0)
        {
            return;
        }

        Vector3[] vertices;
        Matrix4x4 matrix;
        float currentRotation = m_InitialRotation;

        // Calculate the rotation offset based on the characterSpacing
        float rotationOffset = m_CharacterSpacing * (characterCount - 1) / 2;

        for (int i = 0; i < characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
            {
                continue;
            }

            int vertexIndex = charInfo.vertexIndex;
            int materialIndex = charInfo.materialReferenceIndex;
            vertices = textInfo.meshInfo[materialIndex].vertices;

            // Calculate the angle for the character
            float angle = m_InitialRotation + (m_CharacterSpacing * i) - rotationOffset;
            Vector3 charMidBaseline = (vertices[vertexIndex] + vertices[vertexIndex + 3]) / 2;
            Vector3 arcPoint = new Vector3(
                Mathf.Cos(Mathf.Deg2Rad * angle) * m_ArcRadius,
                Mathf.Sin(Mathf.Deg2Rad * angle) * m_ArcRadius,
                0);

            // Adjust character rotation to face outward from the arc center
            float charRotationAngle = angle - 270.0f; // Offset by 90 degrees to align top of the character with the arc direction

            matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, charRotationAngle));
            Vector3 offset = arcPoint - charMidBaseline;

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j] = matrix.MultiplyPoint3x4(vertices[vertexIndex + j] - charMidBaseline) + offset + charMidBaseline;
            }
        }

        m_TextComponent.UpdateVertexData();
    }

#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        UpdateCurveMesh();
    }

    void OnDisable()
    {
        m_TextComponent.ForceMeshUpdate();
    }
#endif
}
