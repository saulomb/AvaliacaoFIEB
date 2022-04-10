using Avaliacao.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Domain.RH
{
    public class Cargo : Entity<int>
    {

        public string Nome { get; private set; }
    }
}
