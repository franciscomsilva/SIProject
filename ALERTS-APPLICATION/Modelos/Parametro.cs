using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ALERTS_APPLICATION
{
    [DataContract]
    class Parametro
    {
        [DataMember]
        public string Condicao { get; set; }
        [DataMember]
        public TipoDado TipoDado { get; set; }
        [DataMember]
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return Condicao + TipoDado + Valor;
        }



    }



}
