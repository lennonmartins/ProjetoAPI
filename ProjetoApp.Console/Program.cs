using Projeto.Aplicacao;
using Projeto.Dominio;

class Program
{
    public static void Main(string[] args)
    {
       /* CadastraFamiliaService cadastraFamiliaService = new CadastraFamiliaService();*/

     /*   Console.WriteLine("Informe o nome do responsável: ");
        string nomeDoResponsavel = Console.ReadLine();

        Console.WriteLine("Informe o Telefone ");
        string telefone = Console.ReadLine();

        Console.WriteLine("Informe o CPF: ");
        string cpf = Console.ReadLine();

        Console.WriteLine("Informe a renda total: ");
        decimal rendaTotalDaFamilia = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Informe a quantidade de dependentes: ");
        int quantidadeDeDepedentes = int.Parse(Console.ReadLine());
*/
        Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

        /*Familia familiaCadastrada = cadastraFamiliaService.Cadastrarfamilia(nomeDoResponsavel, telefone, cpf, rendaTotalDaFamilia, quantidadeDeDepedentes);

        Console.WriteLine(familiaCadastrada.NomeDoResponsavel);*/
    }
}
