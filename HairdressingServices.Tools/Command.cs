using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Tools
{
    public class Command
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal IDictionary<string, object> Parameters { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isStoredProcedure"></param>
        public Command(string query, bool isStoredProcedure)
        {
            Query = query;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametersName"></param>
        /// <param name="value"></param>
        public void AddParameter(string parametersName, object value)
        {
            Parameters.Add(parametersName, value ?? DBNull.Value);
        }
    }
}
