using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private readonly ScreenSoundContext Context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            Context = context;
        }

        public IEnumerable<Artista> Listar()
        {
            try
            {
                return Context.Artistas.ToList();
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
                Context.Artistas.Add(artista);
                Context.SaveChanges();
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
                Context.Artistas.Update(artista);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Artista artista)
        {
            try
            {
                Context.Artistas.Remove(artista);
                Context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Artista? RecuperarPeloNome(string nome)
        {
            try
            {
                return Context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
