using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using System.Xml;
using NHConfiguration = NHibernate.Cfg.Configuration;
using SystemConfiguration = System.Configuration.Configuration;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace GerenciamentodePecasdeVeículos.ConfigDb
{
    internal class ConfigDB
    {
        private static ISessionFactory sessionFactory;

        public static NHibernate.Cfg.Configuration SimpleConfig()
        {
            string connectionstr = "Data Source=PCLUCAS\\SQLEXPRESS;Initial Catalog=EstoqueVeiculos;Integrated Security=True;;";

            var config = new NHibernate.Cfg.Configuration();
            config.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionstr;
                x.Dialect<MsSql2012Dialect>();
                x.Driver<SqlClientDriver>();
            });

           config.AddAssembly(Assembly.GetExecutingAssembly());
           config.AddAssembly(typeof(PecaData).Assembly);

            config.AddFile("C:\\Users\\lucas\\OneDrive\\Documentos\\GitHub\\GerenciamentodePecasdeVeículos\\Mappings\\Peca.hbm.xml");
            string mappingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mappings", "Peca.hbm.xml");

            return config;
        }

    }
}
