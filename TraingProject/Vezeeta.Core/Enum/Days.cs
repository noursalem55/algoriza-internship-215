using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Enum
{
    public enum Days
    {
        [Description("السبت")]
        Saturday = 1,
        [Description("الاحد")]
        Sunday = 2,
        [Description("الاثنين")]
        Monday = 3,
        [Description("الثلاثاء")]
        Tuesday = 4,
        [Description("الاربعاء")]
        Wednesday = 5,
        [Description("الخميس")]
        Thursday = 6,
        [Description("الجمعة")]
        Friday = 7
    }
}
