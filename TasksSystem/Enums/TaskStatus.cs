using System.ComponentModel;

namespace TasksSystem.Enums
{
    public enum TaskStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("InProgress")]
        InProgress = 2,
        [Description("Finished")]
        Finished = 3
    }
}
