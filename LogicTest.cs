using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEx;
using System.Diagnostics;
using Debug = UniEx.Debug;

namespace LogicTest
{
    public class Sample : UniCycle
    {
        public override void Start()
        {
            // 初回フレームに1度だけ実行されます。
        }
        public override void Update()
        {
            // 毎フレーム実行されます。
        }
    }
}