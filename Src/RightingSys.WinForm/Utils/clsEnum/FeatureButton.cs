using System.ComponentModel;

namespace RightingSys.WinForm.Utils.clsEnum
{
    /// <summary>
    /// 操作功能枚举
    /// </summary>
    public enum FeatureButton
    {
        [Description("无")]
         None=0,
        [Description("新增")]
        Add =1,
        [Description("查询")]
        Query =2,
        [Description("修改")]
        Modify = 4,
        [Description("删除")]
        Delete = 8,
        [Description("取消")]
        Cancel = 16,
        [Description("保存")]
        Save = 32,
        [Description("审核")]
        Approve = 64,
        [Description("反审")]
        UnApprove = 128,
        [Description("导入")]
        Import = 256,
        [Description("导出")]
        Export = 512,
        [Description("预览")]
        Preview = 1024,
        [Description("打印")]
        Print = 2048,
        [Description("首笔")]
        First = 4096,
        [Description("上一笔")]
        Previous = 8192,
        [Description("下一笔")]
        Next = 16384,
        [Description("末笔")]
        Last = 32768
    }
}
