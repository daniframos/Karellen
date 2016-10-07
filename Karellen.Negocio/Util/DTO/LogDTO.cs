using System;

namespace Karellen.Negocio.Util.DTO
{
    // ReSharper disable once InconsistentNaming
    public class LogDTO
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Local { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public DateTime Data { get; set; }

        public Guid SessaoId { get; set; }

        public string EntidadeNome { get; set; }
        public string EntidadeId { get; set; }
        public string Acao { get; set; }
    }
}