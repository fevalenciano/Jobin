using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jobin.Model.ValueObjects;

namespace Jobin.Model.DataStoreInterface
{
    public partial interface IUsuariosDalc
    {
        void UpdateUserName(string emailAtual, string emailNovo);
    }
}
