using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenkenWeb.Common;
using TenkenWeb.Models;

namespace TenkenWeb.Providers
{
    public class BookProvider
    {
        public static IList<Book> getBookList(SqlConnection connect, int bookType)
        {
            IList<Book> result = new List<Book>();
            try
            {
                Book book = new Book();
                string sql = "[tk].[book_list_get]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeID", bookType);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    book.bookID = int.Parse(reader["BookID"].ToString());
                    book.bookName = reader["BookName"].ToString();
                    book.bookTypeID = int.Parse(reader["BookTypeID"].ToString());
                    book.bookTypeName = reader["BookTypeName"].ToString();
                    book.price = int.Parse(reader["Price"].ToString());
                    book.description = reader["Description"].ToString();
                    book.ImageUrl = reader["Image"].ToString();
                    result.Add(book);
                }
            }
            catch (Exception e)
            {
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }

        public static IList<BookType> getBookType(SqlConnection connect)
        {
            IList<BookType> result = new List<BookType>();
            try
            {
                BookType type = new BookType();
                string sql = "[tk].[book_type_get]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@BookTypeName", bookTypeName);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    type.bookTypeID = int.Parse(reader["BookTypeID"].ToString());
                    type.bookTypeName = reader["BookTypeName"].ToString();
                    result.Add(type);
                }
            }
            catch (Exception e)
            {
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }

        public static HttpResult book_insert(SqlConnection connect, Book book)
        {
            HttpResult result = new HttpResult();
            try
            {
                string sql = "[tk].[book_insert]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", book.bookName);
                cmd.Parameters.AddWithValue("@BookTypeID", book.bookTypeID);
                cmd.Parameters.AddWithValue("@Price", book.price);
                cmd.Parameters.AddWithValue("@Quantity", book.quantity);
                cmd.Parameters.AddWithValue("@Desciption", book.description);
                cmd.Parameters.AddWithValue("@Image", book.ImageUrl);
                cmd.Parameters.Add("@bookIDOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@resultOut", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                connect.Open();
                cmd.ExecuteNonQuery();
                result.ID = (int)cmd.Parameters["@bookIDOut"].Value;
                result.Message = cmd.Parameters["@resultOut"].Value.ToString();
                result.Result = result.ID > 0 ? true : false;
            }
            catch (Exception e)
            {
                result.ID = 1;
                result.Message = TkConstant.UnexpectedError;
                result.Result = false;
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }

        public static HttpResult book_merge(SqlConnection connect, Book book)
        {
            HttpResult result = new HttpResult();
            try
            {
                string sql = "[tk].[book_merge]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", book.bookName);
                cmd.Parameters.AddWithValue("@BookTypeID", book.bookTypeID);
                cmd.Parameters.AddWithValue("@Price", book.price);
                cmd.Parameters.AddWithValue("@Quantity", book.quantity);
                cmd.Parameters.AddWithValue("@Desciption", book.description);
                cmd.Parameters.AddWithValue("@Image", book.ImageUrl);
                cmd.Parameters.Add("@bookIDOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@resultOut", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                connect.Open();
                cmd.ExecuteNonQuery();
                result.ID = (int)cmd.Parameters["@bookIDOut"].Value;
                result.Message = cmd.Parameters["@resultOut"].Value.ToString();
                result.Result = result.ID > 0 ? true : false;
            }
            catch (Exception e)
            {
                result.ID = 1;
                result.Message = TkConstant.UnexpectedError;
                result.Result = false;
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }

        public static HttpResult book_type_insert(SqlConnection connect, BookType book)
        {
            HttpResult result = new HttpResult();
            try
            {
                string sql = "[tk].[book_type_insert]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeName", book.bookTypeName);
                cmd.Parameters.Add("@bookTypeIDOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@resultOut", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                connect.Open();
                cmd.ExecuteNonQuery();
                result.ID = (int)cmd.Parameters["@bookTypeIDOut"].Value;
                result.Message = cmd.Parameters["@resultOut"].Value.ToString();
                result.Result = result.ID > 0 ? true : false;
            }
            catch (Exception e)
            {
                result.ID = 1;
                result.Message = TkConstant.UnexpectedError;
                result.Result = false;
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }

        public static HttpResult book_type_merge(SqlConnection connect, BookType book)
        {
            HttpResult result = new HttpResult();
            try
            {
                string sql = "[tk].[book_type_merge]";
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeName", book.bookTypeName);
                cmd.Parameters.Add("@bookTypeIDOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@resultOut", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                connect.Open();
                cmd.ExecuteNonQuery();
                result.ID = (int)cmd.Parameters["@bookTypeIDOut"].Value;
                result.Message = cmd.Parameters["@resultOut"].Value.ToString();
                result.Result = result.ID > 0 ? true : false;
            }
            catch (Exception e)
            {
                result.ID = 1;
                result.Message = TkConstant.UnexpectedError;
                result.Result = false;
                connect.Close();
                return result;
            }
            connect.Close();
            return result;
        }
    }
}
