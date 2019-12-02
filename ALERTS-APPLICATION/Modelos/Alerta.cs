using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ALERTS_APPLICATION
{
    [DataContract]
    class Alerta
    {
        [DataMember]
        public LinkedList<Parametro> Parametros { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int Ativado { get; set; }

        [DataMember]
        public DateTime DataCriacao { get; set; }

        public void adicionarParametro(Parametro parametro)
        {
            this.Parametros.AddLast(parametro);
        }

        public bool removerParametro(Parametro parametro)
        {
            return this.Parametros.Remove(parametro);
        }

        public override string ToString()
        {
            return Descricao + UserID + DataCriacao;
        }

    }
}
