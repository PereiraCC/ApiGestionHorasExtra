using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class FormularioTiempo
    {
        private HorasExtraEntities entities;
        private FormulariosAvalados formulariosAvalados;


        public FormularioTiempo()
        {
            entities = new HorasExtraEntities();
            formulariosAvalados = new FormulariosAvalados();

        }


        public int idFormularioAvalado(string email, string motivo)
        {
            try
            {
                var query = from c in entities.ObtenerFormularioAvaladoTiempo
                            where c.Email == email && c.Motivo == motivo
                            select c;

                List<ObtenerFormularioAvaladoTiempo> lista = query.ToList<ObtenerFormularioAvaladoTiempo>();
                int id = 0;
                foreach (ObtenerFormularioAvaladoTiempo t in lista)
                {
                    id = t.idFormularioAvalado;
                }

                return id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string CrearFormularioTiempo(FORMULARIOS_TIEMPO formulario)
        {
            try
            {
                entities.FORMULARIOS_TIEMPO.Add(formulario);
                int res = entities.SaveChanges();
                if (res == 1)
                {
                    return formulariosAvalados.ActualizarFormularioAvalado(formulario.idFormularioAvalado);
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception ex) 
            {
                throw ex;
            }
   

        }

        public int obterneridFormularioTiempo(string email, string motivo)
        {
            try
            {
                int id = idFormularioAvalado(email, motivo);

                List<FORMULARIOS_TIEMPO> model = new List<FORMULARIOS_TIEMPO>();
                var query = from c in entities.FORMULARIOS_TIEMPO
                            where c.idFormularioAvalado == id
                            select c;
                model = query.ToList<FORMULARIOS_TIEMPO>();
                int id1 = 0;
                foreach(FORMULARIOS_TIEMPO t in model)
                {
                    id1 = t.idFormularioTiempo;

                }
                return id1;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ObtenerFormularioAvaladoTiempo> obternerFormularioTiempo(string email)
        {
            try
            {
                //int id = idFormularioAvalado(email, motivo);

                List<ObtenerFormularioAvaladoTiempo> model = new List<ObtenerFormularioAvaladoTiempo>();
                var query = from c in entities.ObtenerFormularioAvaladoTiempo
                            where c.Email == email && c.Estado == false
                            select c;
                model = query.ToList<ObtenerFormularioAvaladoTiempo>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ActualizarFormularioTiempo(int idFormularioTiempo)
        {

            try
            {
                FORMULARIOS_TIEMPO f = entities.FORMULARIOS_TIEMPO.First<FORMULARIOS_TIEMPO>(x => x.idFormularioTiempo == idFormularioTiempo);
                f.Estado = true;

                entities.Entry(f).State = EntityState.Modified;

                int res = entities.SaveChanges();
                if (res == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
