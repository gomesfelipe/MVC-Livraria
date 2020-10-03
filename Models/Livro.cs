using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_LIVRARIA.Models
{
    public enum CategoriaLivros
    {
        Admin, Artes, Autoajuda, Aventura, Biografias, Ciencias, ConcursoPublico, ContosCronicas, DicinariosManuais, Direito, Diversos, Economia, Ensaios, FiccaoCientifica, FiccaoFantastica, FiccaoSuspense, Filosofia, GeografiaHistoria, Humor, InfantoJuvenil, Linguistica, Medicina, Poesia, Policial, Psicologia, Regimes, Religiao, Romance, TeoriaCritica, TerrorSuspense, Turismo
    }
    public class Livro
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public CategoriaLivros Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public bool TemIlustra { get; set; }
        public bool Favorito { get; set; }

        //public int ApplicationUserId { get; set; }

        //[ForeignKey("ApplicationUserId")]
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}