using System;
namespace cadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }
        public override double pagarImposto(float rendimento){
            if (rendimento <= 1500)
            {
               return 0; 
            }else if(rendimento > 1500 && rendimento <= 5000){
                return (rendimento * 0.03); 
            }
            return (rendimento * 0.05);
        }
        public bool ValidarDataNascimento(DateTime dateNasc) {
            DateTime dateAtual = DateTime.Today;

            double anos = (dateAtual - dateNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }else{
                return false;
            }

        }
        
        
        
        
    }
}