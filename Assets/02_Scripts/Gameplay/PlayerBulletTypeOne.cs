using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTypeOne : BaseBullet
{
    public static Action<Vector3> Hit_Event;

    // Update is called once per frame
    protected override void Update() => base.Update();
    protected override void OnEnable() => base.OnEnable();

}
