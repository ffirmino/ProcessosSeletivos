using Webmotors.Shared.Entities;

namespace Webmotors.Domain.Entities
{
    public class Anuncio : EntityBase
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public int Quilometragem { get; private set; }
        public string Observacao { get; private set; }

        public Anuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }
    }
}
