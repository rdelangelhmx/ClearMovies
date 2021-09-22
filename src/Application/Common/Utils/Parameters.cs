using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Application.Common.Utils
{
    public static class Parameters
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetItemName(object item)
        {
            return item.GetType().Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetParams(object item)
        {
            try
            {
                Dictionary<string, object> Parametros = new Dictionary<string, object>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                        Parametros.Add("@" + key.Replace("-", "_").Replace("[", "").Replace("]", ""), coleccionDatos[key]);
                }
                return Parametros;
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetRoute(object item)
        {
            try
            {
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if ((coleccionDatos[key] is int) ||
                            (coleccionDatos[key] is decimal) ||
                            (coleccionDatos[key] is double) ||
                            (coleccionDatos[key] is float))
                            Parametros.Add(key + "=" + coleccionDatos[key]);
                        else if (coleccionDatos[key] is DateTime)
                            Parametros.Add(key + "='" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", coleccionDatos[key]) + "'");
                        else if (coleccionDatos[key] is bool)
                            Parametros.Add(key + "=" + ((bool)coleccionDatos[key] ? 1 : 0));
                        else
                            Parametros.Add(key + "='" + coleccionDatos[key] + "'");
                    }
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetValues(object item)
        {
            try
            {
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if ((coleccionDatos[key] is int) ||
                            (coleccionDatos[key] is decimal) ||
                            (coleccionDatos[key] is double) ||
                            (coleccionDatos[key] is float))
                            Parametros.Add(key + " = " + coleccionDatos[key]);
                        else if (coleccionDatos[key] is DateTime)
                            Parametros.Add(key + " = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", coleccionDatos[key]) + "'");
                        else if (coleccionDatos[key] is bool)
                            Parametros.Add(key + " = " + ((bool)coleccionDatos[key] ? 1 : 0));
                        else
                            Parametros.Add(key + " = '" + coleccionDatos[key] + "'");
                    }
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetValuesParams(object item)
        {
            try
            {
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                        Parametros.Add($"{key} = @{key.Replace("-", "_").Replace("[", "").Replace("]", "")}");
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetFields(object item)
        {
            try
            {
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                        Parametros.Add(key);
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetFieldsParams(object item)
        {
            try
            {
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                        Parametros.Add($"@{key.Replace("-", "_").Replace("[", "").Replace("]", "")}");
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetCamposParams(string[] items)
        {
            try
            {
                List<string> Parametros = new List<string>();
                var i = 0;
                foreach (string key in items)
                {
                    Parametros.Add($"@p{i}");
                    i++;
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static object[] GetInsert(object item)
        {
            try
            {
                List<object> Parametros = new List<object>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if ((coleccionDatos[key] is int) ||
                            (coleccionDatos[key] is decimal) ||
                            (coleccionDatos[key] is double) ||
                            (coleccionDatos[key] is float))
                            Parametros.Add(coleccionDatos[key]);
                        else if (coleccionDatos[key] is DateTime)
                            Parametros.Add("'" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", coleccionDatos[key]) + "'");
                        else if (coleccionDatos[key] is bool)
                            Parametros.Add((bool)coleccionDatos[key] ? 1 : 0);
                        else
                            Parametros.Add("'" + coleccionDatos[key] + "'");
                    }
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetWhere(object item)
        {
            try
            {
                int index = 0;
                List<string> Parametros = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if ((coleccionDatos[key] is int) ||
                            coleccionDatos[key] is decimal ||
                            coleccionDatos[key] is double ||
                            coleccionDatos[key] is float ||
                            coleccionDatos[key] is DateTime ||
                            coleccionDatos[key] is bool)
                            Parametros.Add($"{key} == @{index}");
                        else
                            Parametros.Add($"{key}.ToLower().Contains(@{index})");
                        index++;
                    }
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetPredicate<T>(object item)
        {
            try
            {
                Dictionary<string, object> coleccionDatos = ObtenerElementosNotNull(item, MemberTypes.Property);
                var parameter = Expression.Parameter(typeof(T), "x");
                if (coleccionDatos.Keys.Count <= 0)
                    return null;
                string keyCurr = coleccionDatos.Keys.First();
                var currExpr = MakeExpressionEqual<T>(new Condition()
                {
                    Operator = Operator.And,
                    FieldName = keyCurr,
                    Value = coleccionDatos[keyCurr] is Enum ? (int)coleccionDatos[keyCurr] : coleccionDatos[keyCurr]
                }, parameter);
                foreach (string key in coleccionDatos.Keys.Skip(1))
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        var nextExpr = MakeExpressionEqual<T>(new Condition()
                        {
                            Operator = Domain.Enums.Operator.And,
                            FieldName = key,
                            Value = coleccionDatos[key] is Enum ? (int)coleccionDatos[key] : coleccionDatos[key]
                        }, parameter);
                        currExpr = Expression.And(currExpr, nextExpr);
                    }
                }
                return Expression.Lambda<Func<T, bool>>(currExpr, parameter);
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetPredicate<T>(T item)
        {
            try
            {
                Dictionary<string, object> coleccionDatos = ObtenerElementosNotNull(item, MemberTypes.Property);
                var parameter = Expression.Parameter(typeof(T), "x");
                if (coleccionDatos.Keys.Count <= 0)
                    return null;
                string keyCurr = coleccionDatos.Keys.First();
                var currExpr = MakeExpressionEqual<T>(new Condition()
                {
                    Operator = Operator.And,
                    FieldName = keyCurr,
                    Value = coleccionDatos[keyCurr] is Enum ? (int)coleccionDatos[keyCurr] : coleccionDatos[keyCurr]
                }, parameter);
                foreach (string key in coleccionDatos.Keys.Skip(1))
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        var nextExpr = MakeExpressionEqual<T>(new Condition()
                        {
                            Operator = Operator.And,
                            FieldName = key,
                            Value = coleccionDatos[key] is Enum ? (int)coleccionDatos[key] : coleccionDatos[key]
                        }, parameter);
                        currExpr = Expression.And(currExpr, nextExpr);
                    }
                }
                return Expression.Lambda<Func<T, bool>>(currExpr, parameter);
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        static BinaryExpression MakeExpressionEqual<T>(Condition condition, ParameterExpression parameter)
        {
            return Expression.Equal(
                Expression.MakeMemberAccess(parameter, typeof(T).GetMember(condition.FieldName)[0]),
                Expression.Constant(condition.Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static object[] GetWhereValues(object item)
        {
            try
            {
                List<object> Parametros = new List<object>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if ((coleccionDatos[key] is int) ||
                            coleccionDatos[key] is decimal ||
                            coleccionDatos[key] is double ||
                            coleccionDatos[key] is float ||
                            coleccionDatos[key] is DateTime ||
                            coleccionDatos[key] is bool)
                            Parametros.Add(coleccionDatos[key]);
                        else
                            Parametros.Add(coleccionDatos[key].ToString().Replace("%", ""));
                    }
                }
                return Parametros.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetLike(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;
            return $"{data}%";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetLikeAll(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;
            return $"%{data}%";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stIn"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(string stIn)
        {
            try
            {
                string stFormD = stIn.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();

                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[ich]);
                    }
                }
                return (sb.ToString().Normalize(NormalizationForm.FormC));
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetData(object item)
        {
            try
            {
                List<string> Fieldnames = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    if (coleccionDatos[key] != null && !ValidateInjection(coleccionDatos[key].ToString()))
                    {
                        if (coleccionDatos[key] is DateTime)
                            Fieldnames.Add(string.Format("{0:yyyy-MM-dd hh:mm:ss}", coleccionDatos[key]));
                        else if (coleccionDatos[key] is bool)
                            Fieldnames.Add(((bool)coleccionDatos[key] ? "true" : "false"));
                        else
                            Fieldnames.Add(coleccionDatos[key].ToString());
                    }
                    else
                    {
                        Fieldnames.Add("");
                    }
                }
                return Fieldnames.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string[] GetHeaders(object item)
        {
            try
            {
                List<string> Fieldnames = new List<string>();
                Dictionary<string, object> coleccionDatos = ObtenerElementos(item, MemberTypes.Property);
                foreach (string key in coleccionDatos.Keys)
                {
                    Fieldnames.Add(key);
                }
                return Fieldnames.ToArray();
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public static bool ValidateInjection(string Valor)
        {
            return Valor.ToLower().Contains("select") || Valor.ToLower().Contains("update") || Valor.ToLower().Contains("insert") || Valor.ToLower().Contains("delete");
        }

        ///
        /// Función encargada de devolver un tipo de elemento en concreto de un objeto en un conjunto
        /// de pares clave - valor.
        /// <changelog>
        /// Rodrigo del Angel    14/08/2011    Creación
        /// </changelog>
        /// <summary>
        /// Obtener la estructura de datos de un objeto
        /// </summary>
        /// <param name="objeto">Estructura de Datos</param>
        /// <param name="TipoElemento">Propiedades de la Estructura de Datos</param>
        /// <returns>Diccionaro de la Estructura de Datos</returns>
        public static Dictionary<string, object> ObtenerElementos(object objeto, MemberTypes TipoElemento)
        {
            try
            {
                // Declaramos un Diccionario que contendra el nombre de los elementos del objeto y el
                //contenido de cada elemento.
                Dictionary<string, object> Elementos = new Dictionary<string, object>();

                // Se recorren los miembros del objeto
                foreach (MemberInfo infoMiembro in objeto.GetType().GetMembers())
                {
                    // Si el tipo del objeto es del tipo que buscamos, se añade al diccionario
                    if (infoMiembro.MemberType == TipoElemento && (PropertyInfo)infoMiembro != null)
                    {
                        Elementos.Add(((PropertyInfo)infoMiembro).Name, ((PropertyInfo)infoMiembro).GetValue(objeto, null));
                    }
                }
                return Elementos;
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="TipoElemento"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ObtenerElementosNotNull(object objeto, MemberTypes TipoElemento)
        {
            try
            {
                // Declaramos un Diccionario que contendra el nombre de los elementos del objeto y el
                //contenido de cada elemento.
                Dictionary<string, object> Elementos = new Dictionary<string, object>();

                // Se recorren los miembros del objeto
                foreach (MemberInfo infoMiembro in objeto.GetType().GetMembers())
                {
                    // Si el tipo del objeto es del tipo que buscamos, se añade al diccionario
                    if (infoMiembro.MemberType == TipoElemento && (PropertyInfo)infoMiembro != null)
                    {
                        var valor = ((PropertyInfo)infoMiembro).GetValue(objeto, null);
                        if (valor != null)
                        {
                            Elementos.Add(((PropertyInfo)infoMiembro).Name, valor);
                        }
                    }
                }
                return Elementos;
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// Get a property info object from Item class filtering by property name.
        /// </summary>
        /// <param name="name">name of the property</param>
        /// <returns>property info object</returns>
        public static PropertyInfo GetProperty(string name, PropertyInfo[] properties)
        {
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        /// <summary>
        /// Process a list of items according to Form data parameters
        /// </summary>
        /// <param name="lstElements">list of elements</param>
        /// <param name="requestFormData">collection of form data sent from client side</param>
        /// <returns>list of items processed</returns>
        public static IEnumerable<object> ProcessCollection(IEnumerable<object> lstElements, IFormCollection requestFormData)
        {
            try
            {
                var skip = Convert.ToInt32(requestFormData["start"].ToString());
                var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
                Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

                if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
                {
                    var columnIndex = requestFormData["order[0][column]"].ToString();
                    var sortDirection = requestFormData["order[0][dir]"].ToString();
                    tempOrder = new[] { "" };
                    if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                    {
                        var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                        if (pageSize > 0)
                        {
                            var prop = GetProperty(columName, GetListPropertyInfo(lstElements));
                            if (sortDirection == "asc")
                            {
                                return lstElements.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                            }
                            else
                                return lstElements.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                            return lstElements;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                var exErr = ex;
                throw exErr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="someList"></param>
        /// <returns></returns>
        public static Type GetListType(IEnumerable<object> someList)
        {
            return someList.First().GetType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="someList"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetListPropertyInfo(IEnumerable<object> someList)
        {
            return someList.First()
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionType"></param>
        /// <returns></returns>
        public static Type GetItemType(Type collectionType)
        {
            return collectionType.GetMethod("Get_Item").ReturnType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, string value)
        {
            FieldInfo fi = Enum.Parse(enumType, value).GetType().GetField(value);

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, int value)
        {
            var item = Enum.ToObject(enumType, value);

            return GetDescription(enumType, item.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(ext);
            if (registrykey != null && registrykey.GetValue("Content Type") != null)
                contentType = registrykey.GetValue("Content Type").ToString();
            return contentType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int? TryParseNullable(string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (int?)outValue : null;
        }

    }
}
