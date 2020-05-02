using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.WinForm.AppPublic.appClass
{
    public class SqlParameters
    {
        private System.Collections.Generic.List<SqlParameter> pars;

        public SqlParameters()
        {
            this.pars = new System.Collections.Generic.List<SqlParameter>();
        }

        private bool Exists(string parameterName)
        {
            return (from c in this.pars
                    where c.ParameterName.ToUpper() == parameterName
                    select c).FirstOrDefault<SqlParameter>() != null;
        }

        public void Clear()
        {
            if (this.pars != null)
            {
                this.pars.Clear();
            }
        }

        public SqlParameter GetParameter(string paraName)
        {
            return (from c in this.pars
                    where 0 == string.Compare(c.ParameterName, paraName, true)
                    select c).FirstOrDefault<SqlParameter>();
        }

        public bool SetParaValue(string paraName, object value)
        {
            SqlParameter parameter = this.GetParameter(paraName);
            if (parameter != null)
            {
                parameter.Value = value;
                return true;
            }
            return false;
        }

        public bool AddWithValue(string parameterName, object value)
        {
            if (this.Exists(parameterName))
            {
                return false;
            }
            this.pars.Add(new SqlParameter(parameterName, value));
            return true;
        }

        public bool Add(string parameterName, SqlDbType dbType, int size, object value)
        {
            if (this.Exists(parameterName))
            {
                return false;
            }
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.Size = size;
            sqlParameter.SqlDbType = dbType;
            sqlParameter.Value = value;
            this.pars.Add(sqlParameter);
            return true;
        }

        public bool Add(SqlParameter par)
        {
            if (this.Exists(par.ParameterName))
            {
                return false;
            }
            this.pars.Add(par);
            return true;
        }

        public SqlParameter[] ToArray()
        {
            return this.pars.ToArray<SqlParameter>();
        }
    }
}
