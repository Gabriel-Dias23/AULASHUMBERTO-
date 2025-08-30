namespace MinhaApi.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        // Propriedade calculada (não precisa ser armazenada na lista)
        public double Imc => Peso / (Altura * Altura);
    }
}
