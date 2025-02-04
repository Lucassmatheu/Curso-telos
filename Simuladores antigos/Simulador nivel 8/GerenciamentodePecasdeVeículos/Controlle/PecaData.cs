using NHibernate;
using System.Linq;
using System.Collections.Generic;
using GerenciamentodePecasdeVeículos.ConfigDb;
using GerenciamentodePecasdeVeículos.Produto;


public class PecaData
{
    public void Cadastrar(Peca peca)
    {
        var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
        using (var session = sessionfac.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Save(peca);
            transaction.Commit();
        }
    }

    public IList<Peca> ConsultarTodos()
    {
        var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
        using (var session = sessionfac.OpenSession())
        {
            return session.Query<Peca>().ToList();
        }
    }

    public void Editar(Peca peca)
    {
        var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
        using (var session = sessionfac.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Update(peca);
            transaction.Commit();
        }
    }

    public void Excluir(int id)
    {
        var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
        using (var session = sessionfac.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            var peca = session.Get<Peca>(id);
            if (peca != null)
            {
                peca.Status = "Inativo";
                session.Update(peca);
                transaction.Commit();
            }
        }
    }
}