using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // �Ǐ]����Ώہi�v���C���[�Ȃǁj
    public float yFixed = 4.1f;   // �Œ肵����Y���W
    public bool followEnabled = true;

    void LateUpdate()
    {
        if (followEnabled == true && target != null)
        {
            // X�����Ǐ]Y�͌Œ�
            transform.position = new Vector3(target.position.x, yFixed, transform.position.z);
        }
    }
}
