using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Comic : ConnectionDB<Comic, int>
    {
        #region Atributos

        #endregion

        public override void Actualizar()
        {
            throw new NotImplementedException();
        }

        public override void Eliminar()
        {
            throw new NotImplementedException();
        }

        public override void Insertar()
        {
            throw new NotImplementedException();
        }

        public override Comic Leer(int codigo)
        {
            throw new NotImplementedException();
        }

        public override List<Comic> Todos()
        {
            throw new NotImplementedException();
        }
    }
}
