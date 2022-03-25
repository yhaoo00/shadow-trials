using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform hider;
    public Transform seeker;
    public Camera cam;

    public int maxX;
    public int maxY;
    public int minX;
    public int minY;

    private Player.PlayMode playMode;
    private Vector3 cameraPos;

    private void Start()
    {
        playMode = Player.Instance.GetPlayMode();
    }

    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (playMode == Player.PlayMode.Hider)
        {
            cameraPos = Vector3.Lerp(cam.transform.position, hider.position, 3 * Time.deltaTime);
            
        }
        else
        {
            cameraPos = Vector3.Lerp(cam.transform.position, seeker.position, 3 * Time.deltaTime);
        }
        cameraPos.z = -10;

        if (cameraPos.y < minY)
            cameraPos.y = minY;

        if (cameraPos.x < minX)
            cameraPos.x = minX;

        if (cameraPos.y > maxY)
            cameraPos.y = maxY;

        if (cameraPos.x > maxX)
            cameraPos.x = maxX;

        cam.transform.position = cameraPos;
    }
}
