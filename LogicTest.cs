using System;
using System.Threading.Tasks;
using System.Threading;
using UnityCycle;

namespace LogicTest
{
    public class LogicA : UniCycle
    {
        int count = 0;
        public override void Awake()
        {
            // �f�o�b�O�J�n���Ɉ�x�������s����܂��B
        }
        public override void Start()
        {
            // Update�����s�����ŏ��̈��Ɏ��s����܂��B
        }

        public override void Update()
        {
            // ���t���[�����s����܂��B
        }
        public override void FixedUpdate()
        {
            // ���b���s����܂��B
        }
    }
}