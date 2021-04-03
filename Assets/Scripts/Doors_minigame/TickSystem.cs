using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    public class OnTickEvents : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEvents> OnTick;
    
    public int tick;
    public static float maxTick = .5f;
    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    public static void SpeedThingsUp()
    {
        maxTick -= .01f;
    }
    
    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= maxTick)
        {
            tickTimer -= maxTick;
            tick++;
            if (OnTick != null)
            {
                OnTick(this, new OnTickEvents() { tick = tick });
            }
        }
    }
}
