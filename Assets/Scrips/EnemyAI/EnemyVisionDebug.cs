using UnityEngine;

public class EnemyVisionGrid : MonoBehaviour
{
    public float bankinh = 5f;
    public float gocnhin = 120f;
    public float khoangcach = 0.5f;
    public LayerMask vatchan;
    public LayerMask player;

    void OnDrawGizmos()
    {
        //if(!Application.isPlaying)
        //{
        //    return;
        //}
        for (float x = -bankinh; x <= bankinh; x += khoangcach)
        {
            for (float y = -bankinh; y <= bankinh; y += khoangcach)
            {
                Vector2 diem = (Vector2)transform.position + new Vector2(x, y);
                Vector2 huong = (diem - (Vector2)transform.position).normalized;
                float khoangcachdi = Vector2.Distance(transform.position, diem);
                if(khoangcachdi > bankinh || Vector2.Angle(transform.right, huong) > gocnhin / 2)
                {
                    continue;
                }

                Color c = Color.yellow;
                if (Physics2D.Raycast(transform.position,huong, khoangcachdi, vatchan))
                {
                    c = Color.blue;
                }
                else if (Physics2D.Raycast(transform.position, huong, khoangcachdi, player))
                {
                    c = Color.red;
                }

                Gizmos.color = c;
                Gizmos.DrawSphere(diem, 0.07f);
            }
        }
    }
}
