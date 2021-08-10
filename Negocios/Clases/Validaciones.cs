using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocios
{
    public class Validaciones
    {
        public string ValidarAlmacen(string descripcion)
        {
            try
            {
                if (!ValidarNulos(descripcion))
                {
                    if (!validarKeyWords(descripcion))
                    {
                        return "1";
                    }
                    else
                    {
                        return "La descripcion del almacen es invalida.";
                    }
                }
                else
                {
                    return "La descripcion del almacen es obligatoria.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosProducto(string descripcion, string codigo, string cantidad, string nombreAlmacen)
        {
            try
            {
                if (!ValidarNulos(descripcion) || !ValidarNulos(codigo) || !ValidarNulos(cantidad) || !ValidarNulos(nombreAlmacen))
                {
                    if (ValidarNumero(codigo) || ValidarNumero(cantidad))
                    {
                        if (validarTexto(descripcion))
                        {
                            if (!validarKeyWords(descripcion) || !validarKeyWords(codigo) || !validarKeyWords(cantidad) || !validarKeyWords(nombreAlmacen))
                            {
                                return "1";
                            }
                            else
                            {
                                return "Los datos contienen informacion invalida.";
                            }
                        }
                        else
                        {
                            return "El campo Descripcion deben contener solo letras.";
                        }
                    }
                    else
                    {
                        return "El campo Codigo y Cantidad deben contener solo numeros.";
                    }
                }
                else
                {
                    return "Los datos estan incompletos.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarCodigoP(string data)
        {
            try
            {
                if (ValidarNulos(data) == false && ValidarNumero(data))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarNombreP(string data)
        {
            try
            {
                if (ValidarNulos(data) == false && validarTexto(data))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarTexto(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                if (data.All(char.IsLetter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool ValidarNumero(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                if (data.All(char.IsDigit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarNulos(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarKeyWords(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                data = data.ToUpper();
                if ((data.Contains("SELECT") || data.Equals("SELECT")) || (data.Contains("UPDATE") || data.Equals("UPDATE")) || (data.Contains("INSERT") || data.Equals("INSERT")) || (data.Contains("DELETE")) || data.Equals("DELETE"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarEmail(string email)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (!Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool validarCaracteresEspeciales(string data)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (data.Contains(item)) return true;
            }

            return false;
        }
    }

}

