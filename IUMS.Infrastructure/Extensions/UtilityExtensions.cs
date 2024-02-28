using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Extensions
{
    public static class UtilityExtensions
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] == DBNull.Value)
                        {
                            if (pro.IsNullableProperty())
                            {
                                pro.SetValue(obj, null, null);
                            }
                            else if (column.DataType.Name == "Int32")
                            {
                                pro.SetValue(obj, 0, null);
                            }
                            else if (column.DataType.Name == "Decimal" && !pro.IsNullableProperty())
                            {
                                pro.SetValue(obj, Convert.ToDecimal(0.00), null);
                            }
                            else if (column.DataType.Name == "String")
                            {
                                pro.SetValue(obj, null, null);
                            }
                            else if (column.DataType.Name == "DateTime")
                            {
                                pro.SetValue(obj, null, null);
                            }
                            else if (column.DataType.Name == "Boolean")
                            {
                                pro.SetValue(obj, false, null);
                            }
                            else if (column.DataType.Name == "Byte[]")
                            {
                                pro.SetValue(obj, null, null);
                            }
                            else
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }



        public static string GetModelStateError(this ModelStateDictionary ModelState)
        {
          return  string.Join(Environment.NewLine, ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
        }
        /// <summary>
        /// Convert "dd/MM/yyyy" to "MM/dd/yyyy"
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator"></param>
        /// <param name="length"></param>
        /// <returns>string as a date format "MM/dd/yyyy"</returns>
        public static string DateCovertFormat(this string date,string separator , int length)
        {
            string result = "";
            string[] array;
            if (date != null && length == 3)
            {
                array = date.Split(separator);
                result = array[1].ToString() + separator + array[0].ToString() + separator + array[2];
            }
           
            return result;
        }

        private static readonly Random random = new();

        public static string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static async Task<string> SaveFileAsync(IFormFile file, string destinationPath, string prefix= "", string existedUrl = "", bool isFileNameRequird = false)
        {
            
            if (file is not null && file.Length > 0)
            {
                string baseDirectory = Directory.GetCurrentDirectory();
                if (!string.IsNullOrEmpty(existedUrl))
                {
                    var oldFileUrl = $"{baseDirectory}{existedUrl}";
                    if (File.Exists(oldFileUrl))
                        File.Delete(oldFileUrl);
                }
                string basePath = baseDirectory +  destinationPath;
                string fileName;
                if (isFileNameRequird)
                {
                     fileName = prefix + "_" + Path.GetFileNameWithoutExtension(file.FileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
                else
                {
                     fileName = prefix + "_"  + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
                string extension = Path.GetExtension(file.FileName);
                string fileNameWithPath = fileName + extension;
                string filePath = Path.Combine(basePath, fileNameWithPath);
                using var fs = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fs);
                if (destinationPath.Contains("wwwroot"))
                {
                    //destinationPath.Remove(0, 8);
                    return $"{destinationPath.Replace("/wwwroot", string.Empty)}/{fileName}{extension}";
                   // return $"/lms/{fileName}{extension}";
                }
                return $"{destinationPath}/{fileName}{extension}";
            }
            return null;
        }
    }

    public static class PropertyInfoExtension
    {
        public static bool IsNullableProperty(this PropertyInfo propertyInfo)
            => propertyInfo.PropertyType.Name.IndexOf("Nullable`", StringComparison.Ordinal) > -1;
    }
}
