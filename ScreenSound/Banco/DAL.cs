using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class DAL<T> where T : class
    {
        protected readonly ScreenSoundContext Context;
        public DAL(ScreenSoundContext context)
        {
            Context = context;
        }

        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }
        public void Adicionar(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
        }
        public void Atualizar(T t)
        {
            Context.Set<T>().Update(t);
            Context.SaveChanges();
        }
        public void Deletar(T t)
        {
            Context.Set<T>().Remove(t);
            Context.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return Context.Set<T>().FirstOrDefault(condicao);
        }
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return Context.Set<T>().Where(condicao);
        }

    }
}
