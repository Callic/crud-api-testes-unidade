using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Enums
{
    public enum ContatoTipo
    {
        [Description("Telefone")]
        Tefelone = 1,

        [Description("E-mail")]
        Email = 2,

        [Description("WhatsApp")]
        WhatsApp = 3
    }
}
