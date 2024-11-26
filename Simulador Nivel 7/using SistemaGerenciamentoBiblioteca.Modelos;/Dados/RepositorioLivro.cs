using SistemaGerenciamentoBiblioteca.Modelos;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SistemaGerenciamentoBiblioteca.Dados
{
    public class RepositorioLivro
    {
        private const string CaminhoArquivo = "livros.xml"; // Nome do arquivo XML

        public List<Livro> ObterTodosLivros()
        {
            if (!File.Exists(CaminhoArquivo))
                return new List<Livro>();

            var stream = new FileStream(CaminhoArquivo, FileMode.Open);
            var serializer = new XmlSerializer(typeof(List<Livro>));
            return (List<Livro>)serializer.Deserialize(stream);
        }

        public void SalvarLivros(List<Livro> livros)
        {
            var stream = new FileStream(CaminhoArquivo, FileMode.Create);
            var serializer = new XmlSerializer(typeof(List<Livro>));
            serializer.Serialize(stream, livros);
        }
    }
}
