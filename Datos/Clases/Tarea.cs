//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Datos.Clases
//{
//    public class Tarea
//    {
//        private HorasExtraEntities entities;

//        public Tarea()
//        {
//            entities = new HorasExtraEntities();
//        }

//        public bool ExisteTarea(string descripcion)
//        {
//            try
//            {
//                var query = from c in entities.TAREAS
//                            where c.Descripcion == descripcion
//                            select c;

//                List<TAREAS> user = query.ToList<TAREAS>();

//                if (user.Count > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public int getIDTarea(string descripcion)
//        {
//            try
//            {
//                var query = from c in entities.TAREAS
//                            where c.Descripcion == descripcion
//                            select c;

//                List<TAREAS> tareas = query.ToList<TAREAS>();

//                foreach(TAREAS t in tareas)
//                {
//                    if (t.Descripcion.Equals(descripcion))
//                    {
//                        return t.idTarea;
//                    }
//                }

//                return 0;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public int crearTarea(TAREAS tarea)
//        {
//            try
//            {
//                entities.TAREAS.Add(tarea);
//                return entities.SaveChanges();

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }

//    }
//}
