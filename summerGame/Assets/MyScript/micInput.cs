﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class micInput : MonoBehaviour
{
    public float testSound;
    public static float MicLoudness;
    private string _device;
    private AudioClip _clipRecord;
    private int _sampleWindow = 128;
    private bool _isInitialized;
    public float volume;

    void InitMic()
    {
        if (_device == null)
        {
            _device = Microphone.devices[0];
            _clipRecord = Microphone.Start(_device, true, 999, 44100);
            Debug.Log(_clipRecord);
        }
    }
    /*
    void StopMicrophone()
    {
        Microphone.End(_device);
    }
    */
    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1);
        if (micPosition < 0)
        {
            return 0;
        }
        _clipRecord.GetData(waveData, micPosition);
        for (int i = 0; i < _sampleWindow; ++i)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    void Update()
    {
        MicLoudness = LevelMax();
        if(MicLoudness < 0.01) { testSound = 0; }
        else
        {
            testSound = MicLoudness * 100.0f;
        }

    }

    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
    }
    /*
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestory()
    {
        StopMicrophone();
    }
    */
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (!_isInitialized)
            {
                InitMic();
                _isInitialized = true;
            }
        }
        /*
        if (!focus)
        {
            StopMicrophone();
            _isInitialized = false;
        }
        */
    }

}
