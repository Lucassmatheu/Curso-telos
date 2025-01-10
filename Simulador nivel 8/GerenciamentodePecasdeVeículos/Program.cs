using GerenciamentodePecasdeVeículos.ConfigDb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentodePecasdeVeículos
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //try
            //{
            //    // Verifica se os arquivos necessários estão no local correto
            //        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mappings", "hibernate.cfg.xml");
            //    string mappingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mappings","Peca.hbm.xml");

            //    Console.WriteLine(File.Exists(configPath) ? "Configuração encontrada!" : "Configuração não encontrada.");
            //    Console.WriteLine(File.Exists(mappingPath) ? "Mapeamento encontrado!" : "Mapeamento não encontrado.");

            //    // Configura e testa o NHibernate
            //    var sessionfac = ConfigDB.SimpleConfig().BuildSessionFactory();
            //    using (var session = sessionfac.OpenSession())
            //    {
            //        Console.WriteLine("Conexão com NHibernate configurada com sucesso!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Erro: {ex.Message}");
            //    if (ex.InnerException != null)
            //    {
            //        Console.WriteLine($"Detalhes: {ex.InnerException.Message}");
            //    }
            //}

            //// Finaliza o programa
            //Console.WriteLine("Pressione qualquer tecla para sair...");
           
        }

    }
}

