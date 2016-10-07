using System;
using System.ComponentModel;

namespace Karellen.Web.Models.Log
{
    public class LogVM
    {
        public int Id { get; set; }
        [DisplayName(@"Endereço IP")]
        public string Ip { get; set; }
        [DisplayName(@"URL")]
        public string Local { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        [DisplayName(@"Dia/Hora")]
        public DateTime Data { get; set; }
        [DisplayName(@"Sessao")]
        public Guid SessaoId { get; set; }
        [DisplayName(@"Identificador Entidade")]
        public string EntidadeId { get; set; }
        [DisplayName(@"Entidade")]
        public string EntidadeNome { get; set; }
        public string Acao { get; set; }
    }
}