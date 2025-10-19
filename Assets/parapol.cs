using UnityEngine;

public class ParabolaMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float height = 2f;
    public float duration = 1f;

    private float time;

    void Update()
    {
        time += Time.deltaTime / duration;
        time = Mathf.Clamp01(time);

        // Tính vị trí theo parabol
        Vector3 position = Vector3.Lerp(pointA.position, pointB.position, time);
        position.y += height * Mathf.Sin(Mathf.PI * time); // tạo cong theo chiều Y

        transform.position = position;
    }
}
