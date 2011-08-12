using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobin.Model.DataStoreInterface;
using System.Data.Common;
using System.Data;

namespace Jobin.Model.DataStore
{
    public partial class UsuariosDalc : IUsuariosDalc
    {
        public void UpdateUserName(string emailAtual, string emailNovo)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.DWC_Change_User");
            db.AddInParameter(command, "@currentEmail", DbType.String, emailAtual);
            db.AddInParameter(command, "@emailchangeto", DbType.String, emailNovo);

            db.ExecuteNonQuery(command);
        }
    }
}
