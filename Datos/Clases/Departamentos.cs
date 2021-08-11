using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Departamento
    {

        private HorasExtraEntities entities;

        public Departamento()
        {
            entities = new HorasExtraEntities();
        }

        public int getIdDepartamento(string nombre)
        {
            try
            {
                var query = from c in entities.DEPARTAMENTOS
                            where c.Descripcion == nombre
                            select c;

                List<DEPARTAMENTOS> depar = query.ToList<DEPARTAMENTOS>();

                foreach(DEPARTAMENTOS d in depar)
                {
                    if(d.Descripcion == nombre)
                    {
                        return d.idDepartamento;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getNombreDepartamento(int id)
        {
            try
            {
                var query = from c in entities.DEPARTAMENTOS
                            where c.idDepartamento == id
                            select c;

                List<DEPARTAMENTOS> depar = query.ToList<DEPARTAMENTOS>();

                foreach (DEPARTAMENTOS d in depar)
                {
                    if (d.idDepartamento == id)
                    {
                        return d.Descripcion;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
