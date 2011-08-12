using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobin.Model;
using Jobin.Model.DataStoreInterface;
using Jobin.Model.DataStore;
using ES.Practices.Common;

namespace Jobin.Model
{
    public partial class Usuarios : IEqualityComparer<Usuarios>
    {

    }

    public partial class UsuariosFactory : ESContextBoundObject
    {
        public void UpdateUserName(string emailAtual, string emailNovo)
        {
            IUsuariosDalc dalc = Factory.Get().Resolve<IUsuariosDalc>();
            dalc.UpdateUserName(emailAtual, emailNovo);
        }
    }
}
