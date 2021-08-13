﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class FormularioTiempo
    {
        private HorasExtraEntities entities;



        public FormularioTiempo()
        {
            entities = new HorasExtraEntities();

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

        public string CrearFormularioTiempo(string email, string motivo, FORMULARIOS_TIEMPO tarea)
        {
            try
            {
                if (idFormularioAvalado(email, motivo) != 0)
                {
                    try
                    {
                        entities.FORMULARIOS_TIEMPO.Add(tarea);
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
                else
                {
                    return "No existe Formulario avalado";

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

        public List<FORMULARIOS_TIEMPO> obternerFormularioTiempo(string email,string motivo)
        {
            try
            {
                int id = idFormularioAvalado(email, motivo);

                List<FORMULARIOS_TIEMPO> model = new List<FORMULARIOS_TIEMPO>();
                var query = from c in entities.FORMULARIOS_TIEMPO
                            where c.idFormularioAvalado == id
                            select c;
                model = query.ToList<FORMULARIOS_TIEMPO>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}