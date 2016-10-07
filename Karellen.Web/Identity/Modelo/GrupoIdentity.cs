using Microsoft.AspNet.Identity;

namespace Karellen.Web.Identity.Modelo
{
    public class GrupoIdentity : IRole<int>
    {
        public GrupoIdentity()
        {
        }

        public GrupoIdentity(string nome) : this()
        {
            Name = nome;
        }

        public GrupoIdentity(string nome, int id)
        {
            Name = nome;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}