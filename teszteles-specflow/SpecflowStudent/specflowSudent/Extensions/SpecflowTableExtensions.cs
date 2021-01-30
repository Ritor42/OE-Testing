using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace specflowSudent.Extensions
{
    public static class SpecflowTableExtensions
    {
        public static string[] AsStrings(this Table table, string columnName)
        {
            return table.Rows.Select(r => r[columnName]).ToArray();
        }
    }
}
