using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MVC_LIVRARIA.Models
{
    public class LivroDAO
    {
        string connectionString = "";

        //Pegar tud All
        public IEnumerable<Livro> GetAllLivros()
        {
            List<Livro> livroList = new List<Livro>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllLivro", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.EndExecuteReader();
                while (dr.Read())
                {
                    Livro livro = new Livro();
                    livro.ID = Convert.ToInt32(dr["ID"].ToString());
                    livro.Titulo = dr["Titulo"].ToString();
                    livro.Genero = dr["Genero"].ToString();
                    livro.Autor = dr["Autor"].ToString();
                    livro.NumeroPaginas = Convert.ToInt32(dr["NumeroPaginas"].ToString());

                    livroList.Add(livro);
                }
                con.Close();
            }
            return livroList;
        }

        //Adicionar Livro
        public void AddLivro(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertLivro", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", livro.Autor);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@NumeroPaginas", livro.NumeroPaginas);
                cmd.Parameters.AddWithValue("@TemIlustra", livro.TemIlustra);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Alterar
        public void UpdateLivro(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateLivro", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", livro.ID);
                cmd.Parameters.AddWithValue("@Autor", livro.Autor);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@NumeroPaginas", livro.NumeroPaginas);
                cmd.Parameters.AddWithValue("@TemIlustra", livro.TemIlustra);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Deletar
        public void DeleteLivro(int? livroID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteLivro", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", livroID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Pegar Livro por ID
        public Livro GetLivroByID(int ? livroID)
        {
            Livro livro = new Livro();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetLivroById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", livroID);
                con.Open();
                SqlDataReader dr = cmd.EndExecuteReader();
                while (dr.Read())
                {
                    livro.ID = Convert.ToInt32(dr["ID"].ToString());
                    livro.Titulo = dr["Titulo"].ToString();
                    livro.Genero = dr["Genero"].ToString();
                    livro.Autor = dr["Autor"].ToString();
                    livro.NumeroPaginas = Convert.ToInt32(dr["NumeroPaginas"].ToString());

                }
                con.Close();
            }
            return livro;
        }
    }
}