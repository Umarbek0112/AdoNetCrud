using ExamProgram.Domain.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ExamProgram.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            return @params.PageIndex > 0 && @params.PageSize >= 0
                ? source.Skip((@params.PageIndex - 1) * @params.PageSize)
                    .Take(@params.PageSize)
                : source;
        }

        public static string EncryptPassword(this string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            bytes = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
