﻿using System.ComponentModel;

namespace AddinTGM
{
    public class Z_Padrao
    {
        [DisplayName("Código")]
        [DataObjectField(true, false)]
        public int Codigo { get; set; }

        [DisplayName("Descrição")]
        [DataObjectField(false, true)]
        public string Descricao { get; set; }
    }
}
