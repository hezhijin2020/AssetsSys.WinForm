using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RightingSys.WinForm.Utils.clsEnum
{
    /// <summary>
    /// 资产状态枚举
    /// </summary>
    public enum AssetsStatus
    {
        [Description("在用")]
        ZY=1,
        [Description("借用")]
        JY =2,
        [Description("维修")]
        WX =3,
        [Description("报废")]
        BF =4,
        [Description("闲置")]
        XZ =5,
        [Description("删除")]
        SC =6
    }
}
