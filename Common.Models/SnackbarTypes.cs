using System.ComponentModel;

namespace Common.Models
{
    public enum SnackbarTypes
    {
        [Description("default")]
        Default,

        [Description("error")]
        Error,

        [Description("success")]
        Success,

        [Description("warning")]
        Warning,

        [Description("info")]
        Info
    }
}
