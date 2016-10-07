using System;
using System.ComponentModel;
using System.Resources;

namespace Karellen.Negocio.Util.Atributo
{
    public class DescricaoAtributo : DescriptionAttribute
    {
        private readonly string _resourcekey;
        private readonly ResourceManager _resourceManager;

        public DescricaoAtributo(string resourcekey, Type resourceType)
        {
            _resourcekey = resourcekey;
            _resourceManager = new ResourceManager(resourceType);
        }

        public override string Description
        {
            get
            {
                string displayName = _resourceManager.GetString(_resourcekey);

                return string.IsNullOrEmpty(displayName) ? string.Format("[[{0}]]", _resourcekey) : displayName;
            }
        }
    }
}
