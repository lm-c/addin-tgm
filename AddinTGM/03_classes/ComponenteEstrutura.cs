using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinTGM
{
    public class ComponenteEstrutura
    {
        public string Nivel { get; set; }

        public string CadigoMaterial { get; set; }

        public string CodProduto { get; set; }

        public string CompCodInterno { get; set; }

        public string MaterialDescricao { get; set; }

        public string Denominacao { get; set; }

        public string NomeComponente { get; set; }

        public string PathName { get; set; }

        public string ConfigName { get; set; }

        public string Espessura { get; set; }

        public string Largura { get; set; }

        public string Comprimento { get; set; }

        public string Check { get; set; }

        public bool EhItemPai { get; set; }

        public bool Terceiro { get; set; }

        public bool Seriado { get; set; }

        public string Operacao { get; set; }

        public string Maquina { get; set; }

        public double Massa { get; set; }

        public int Quantidade { get; set; }

        // public bool FoiAdicionado { get; set; } 

        public List<ComponenteEstrutura> CompFilhos = new List<ComponenteEstrutura>();
    }
}
