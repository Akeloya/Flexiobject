using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.Test
{
    static class TestHelpers
    {
        public static string GetRandName()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
