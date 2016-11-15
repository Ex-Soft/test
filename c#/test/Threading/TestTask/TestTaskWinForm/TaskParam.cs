
namespace TestTaskWinForm
{
    class TaskParam
    {
        public int
            i,
            mSec;

        public TaskParam(int _i, int _mSec)
        {
            i = _i;
            mSec = _mSec;
        }

        public TaskParam(TaskParam obj) : this(obj.i, obj.mSec)
        {}
    }
}
