//using Datos;
//using Datos.Clases;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Negocios.Clases
//{
//    public class CTask
//    {
//        private Tarea tarea;

//        public CTask()
//        {
//            tarea = new Tarea();
//        }

//        private string validarTarea(string descripcion)
//        {
//            try
//            {
//                if (!Validaciones.ValidarNulos(descripcion))
//                {
//                    if (!Validaciones.validarCaracteresEspeciales(descripcion))
//                    {
//                        if (!Validaciones.validarKeyWords(descripcion))
//                        {
//                            return "1";
//                        }
//                        else
//                        {
//                            return "Los datos contienen informacion invalida.";
//                        }
//                    }
//                    else
//                    {
//                        return "La descripcion de la tarea tiene un formato invalido";
//                    }
//                }
//                else
//                {
//                    return "El campo de descripcion de la tarea es Obligatorio";
//                }
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string crearTarea(TAREAS t)
//        {
//            try
//            {
//                string resp = validarTarea(t.Descripcion);
//                if (resp.Equals("1"))
//                {
//                    if (!tarea.ExisteTarea(t.Descripcion))
//                    {
//                        int res = tarea.crearTarea(t);

//                        if (res == 1)
//                        {
//                            return "1";
//                        }
//                        else
//                        {
//                            return "0";
//                        }
//                    }
//                    else
//                    {
//                        return "Tarea Existe";
//                    }
//                }
//                else
//                {
//                    return resp;
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
