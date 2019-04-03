using CopaFilmes.Model.Base;

namespace CopaFilmes.Model
{
    public class MovieModel : ModelBase
    {
        #region Fields
        private string _titulo;
        private int _ano;
        private double _nota;
        #endregion

        #region Properties
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                RaisedPropertyChanged(() => Titulo);
            }
        }

        public int Ano
        {
            get => _ano;
            set
            {
                _ano = value;
                RaisedPropertyChanged(() => Ano);
            }
        }

        public double Nota
        {
            get => _nota;
            set
            {
                _nota = value;
                RaisedPropertyChanged(() => Nota);
            }
        } 
        #endregion
    }
}
