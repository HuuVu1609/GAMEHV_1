using UnityEngine;

public class VisionWithObstacle : MonoBehaviour
{
    [Header("Cài đặt tầm nhìn")]
    public float visionRadius = 5f;
    public LayerMask obstacleMask;   // Layer của vật cản (cần set trong Inspector)

    private void OnDrawGizmos()
    {
        // Vẽ vùng tầm nhìn (màu vàng)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        // Tìm tất cả các collider trong bán kính vision
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, visionRadius, obstacleMask);

        foreach (Collider2D hit in hits)
        {
            // Lấy hướng từ player đến vật cản
            Vector3 dir = hit.transform.position - transform.position;

            // Raycast kiểm tra xem có bị che chắn không
            RaycastHit2D ray = Physics2D.Raycast(transform.position, dir.normalized, visionRadius, obstacleMask);

            if (ray.collider != null)
            {
                // Vẽ đường màu xanh từ player đến điểm va chạm
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, ray.point);

                // (tuỳ chọn) vẽ 1 chấm nhỏ tại điểm va chạm
                Gizmos.DrawSphere(ray.point, 0.1f);
            }
        }
    }
}