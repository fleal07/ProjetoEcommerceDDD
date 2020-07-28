using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        #region Propriedades

        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notificacoes { get; set; }

        #endregion

        #region Métodos

        public bool ValidarPropriedadesString(string valor, string nomepropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                //Adiciona uma notificação
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadesInt(int valor, string nomepropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                //Adiciona uma notificação
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadesDecimal(decimal valor, string nomepropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                //Adiciona uma notificação
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }

        #endregion
    }
}
