
namespace CapaDominio
{
    using System;
    using System.Collections.Generic;
    
    public class Gerente
    {
        public Gerente()
        {
            this.Producto = new HashSet<Producto>();
        }
    
        public String GerenteCodigo { get; set; }
        public String GerenteNegocio { get; set; }
        public String GerenteUser { get; set; }
        public String GerentePassword { get; set; }
        public String PersonaCodigo { get; set; }
    
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
