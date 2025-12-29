using UnityEngine;

public class BreakTest : MonoBehaviour
{
    public FixedJoint2D joint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("FORCE BREAK");
            Destroy(joint);
        }
    }
}
