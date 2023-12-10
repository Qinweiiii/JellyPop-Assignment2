using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class L4CameraShake : MonoBehaviour
{
    //public Musketeer_Shake usingShakeM;
    public int IsShake;

    private CinemachineVirtualCamera mCam;
    public float ShakeIntensity = 1.0f;
    public float ShakeTime = 0.5f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    void Awake()
    {
        mCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = mCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        //Debug.Log("Start to Shake");
        _cbmcp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = mCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsShake == 1)
        {
            ShakeCamera();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }

    }
}
