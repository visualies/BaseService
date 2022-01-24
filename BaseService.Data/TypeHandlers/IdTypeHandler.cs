using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Data.TypeHandlers
{
    public class IdTypeHandler : SqlMapper.TypeHandler<ulong>
    {
        public override ulong Parse(object value)
        {
            return Convert.ToUInt64(value);
        }

        public override void SetValue(IDbDataParameter parameter, ulong value)
        {
            parameter.Value = value.ToString();
        }
    }
}
