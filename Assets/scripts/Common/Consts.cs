using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scenes.script.Project
{
    public enum MoveState
    {
        TimeMove,
        DestMove,
        Hold
    }

    class Consts
    {
        public const float MoveTime = 2F;
        public const float MoveSpeed = 0.1F;
    }
}
