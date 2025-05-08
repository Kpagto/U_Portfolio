using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // 追従する対象（プレイヤーなど）
    public float yFixed = 4.1f;   // 固定したいY座標
    public bool followEnabled = true;

    void LateUpdate()
    {
        if (followEnabled == true && target != null)
        {
            // Xだけ追従Yは固定
            transform.position = new Vector3(target.position.x, yFixed, transform.position.z);
        }
    }
}
