using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> Listar()
        {
            try
            {
                var Lista = new List<Artista>();

                using var connection = new Connection().ObterConexao();
                connection.Open();

                string Sql = "SELECT * FROM Artistas";
                SqlCommand Commnand = new SqlCommand(Sql, connection);
                using SqlDataReader DataReader = Commnand.ExecuteReader();

                while (DataReader.Read())
                {
                    string NomeArtista = Convert.ToString(DataReader["Nome"]);
                    string BioArtista = Convert.ToString(DataReader["Bio"]);
                    int IdArtista = Convert.ToInt32(DataReader["Id"]);
                    Artista artista = new(NomeArtista, BioArtista) { Id = IdArtista };

                    Lista.Add(artista);

                }

                return Lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Adicionar(Artista artista)
        {
            try
            {
                using var connection = new Connection().ObterConexao();
                connection.Open();

                string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";

                SqlCommand Command = new SqlCommand(sql, connection);

                Command.Parameters.AddWithValue("@nome", artista.Nome);
                Command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
                Command.Parameters.AddWithValue("@bio", artista.Bio);

                int retorno = Command.ExecuteNonQuery();

                if(retorno > 0)
                {
                    Console.WriteLine("Registro Inserido com Sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível inserir o registro, revise as informações.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Artista artista)
        {
            try
            {
                using var connection = new Connection().ObterConexao();
                connection.Open();

                string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
                SqlCommand Command = new SqlCommand(sql, connection);

                Command.Parameters.AddWithValue("@nome", artista.Nome);
                Command.Parameters.AddWithValue("@bio", artista.Bio);
                Command.Parameters.AddWithValue("@id", artista.Id);

                int retorno = Command.ExecuteNonQuery();

                if (retorno > 0)
                {
                    Console.WriteLine("Registro Inserido com Sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível inserir o registro, revise as informações.");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Artista artista)
        {
            try
            {
                using var connection = new Connection().ObterConexao();
                connection.Open();

                string sql = "DELETE FROM Artistas WHERE Id = @id";
                SqlCommand Command = new SqlCommand(sql, connection);

                Command.Parameters.AddWithValue("@id", artista.Id);

                int retorno = Command.ExecuteNonQuery();

                if (retorno > 0)
                {
                    Console.WriteLine("Registro apagado com Sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível apagar o registro, revise as informações.");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
