using System;
using System.Collections.Generic; 
using System.Threading;
using System.IO;
namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
=============================================================
|            BEM-VINDO AO SISTEMA DE CADASTRO               |
|            DE PESSOAS FÍSICA E JURIDICA                   |
=============================================================


");
            BarraCarregamento("Iniciando");
            
            string opcao;           
            do
            {
                Console.WriteLine(@$"
=============================================================
|                       PESSOA FÍSICA                       |
|                                                           |
|                1 - Cadastrar Pessoa Física                |
|                2 - Listar Pessoa Física                   |
|                3 - Remover Pessoa Física                  |
|                                                           |
|                       PESSOA JURIDICA                     |
|                4 - Cadastrar Pessoa Juridica              |
|                5 - Listar Pessoa Juridica                 |
|                6 - Remover Pessoa Juridica                |
|                                                           |
|                0 - Sair                                   |
|                                                           |
=============================================================
");
                opcao = Console.ReadLine();
            
                switch (opcao)
                {
                    case "1":
                    PessoaFisica pf = new PessoaFisica();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco end = new Endereco();

                    //Longradouro
                    // Console.WriteLine($"Digite seu longradoro\n"); 
                    // end.logradouro = Console.ReadLine();

                    // //Número
                    // Console.WriteLine($"Digite seu Número\n"); 
                    // end.numero = int.Parse(Console.ReadLine());

                    // //Complemento    
                    // Console.WriteLine($"Digite o complemento\n");
                    // end.complemento = Console.ReadLine();
                    
                    // //Endereço comercial
                    // Console.WriteLine($"Seu endereço é comercial? S ou N?\n");

                    // string endCom = Console.ReadLine().ToUpper();
                    
                    // if(endCom == "S"){
                    //     end.enderecoComercial = true;
                    // }else{
                    //     end.enderecoComercial = false;
                    // }
                    // novaPf.endereco = end;
                    
                    Console.WriteLine($"Digite seu nome\n");
                    novaPf.nome = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite seu cpf\n");
                    // novaPf.cpf = Console.ReadLine();
                    
                    // Console.WriteLine($"Digite seu rendimento\n");
                    // novaPf.rendimento = float.Parse(Console.ReadLine());

                    // Console.WriteLine($"Digite sua data de nascimento EX: AAAA-MM-DD\n");
                    // novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());
                    
                    // bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                    // if (idadeValida)
                    // {
                    //     Console.WriteLine($"Cadastro Aprovado");
                    //     listaPf.Add(novaPf);

                    // }else{
                    //     Console.WriteLine($"Cadastro Reprovado");
                    // }

                    // Console.WriteLine(pf.pagarImposto(novaPf.rendimento));

                        
                        
                        
                    using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                    {
                        sw.Write($"{novaPf.nome}");
                    }

                    using (StreamReader sr = new StreamReader($"{novaPf.nome}.txt"))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine($"{linha}");
                            
                        }
                    }

                        break;
                    
                    case "2":
                        foreach (var item in listaPf)
                        {
                            Console.WriteLine($"{item.nome},{item.cpf},{item.endereco.logradouro}");
                               
                        }
                        break;
                    case "3":
                        Console.WriteLine($"Digite o CPF que deseja remover");
                        string cpfProcurado = Console.ReadLine();
                        PessoaFisica pessoaEncontrada =  listaPf.Find(item => item.cpf==cpfProcurado);
                        if (pessoaEncontrada != null)
                        {
                            listaPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Removido com sucesso!");
                        }else{
                            Console.WriteLine($"CPF não encontrado!");
                        }
                        
                        break;
                    case "4":
                    PessoaJurica pj = new PessoaJurica();
                    PessoaJurica novaPj = new PessoaJurica();

                    Endereco endPj = new Endereco();
                    endPj.logradouro = "Rua X";
                    endPj.numero = 100;
                    endPj.complemento = "Complemento PJ";
                    endPj.enderecoComercial = true;

                    novaPj.endereco = endPj;
                    novaPj.cnpj = "34567890000190";
                    novaPj.razaoSocial = "Pessoa Juridica";
                    Console.WriteLine($"Digite seu nome juridico: \n");
                    novaPj.nome = Console.ReadLine();
                    novaPj.rendimento = 9030;



                    if (pj.ValidarCNPJ(novaPj.cnpj))
                    {
                        Console.WriteLine($"CNPJ VÁLIDO");

                    }
                    else
                    {
                        Console.WriteLine($"CNPJ INVÁLIDO");
                    }
                    //Console.WriteLine(pj.pagarImposto(novaPj.rendimento));
                    // pj.VerificarArquivo(pj.caminho);
                    // pj.Inserir(novaPj);

                    // if (pj.Ler().Count > 0)
                    // {
                    //     foreach (var item in pj.Ler())
                    //     {
                    //         Console.WriteLine($"Nome: {item.nome} - Razão social: {item.razaoSocial} - CNPJ: {item.cnpj}");
                            
                    //     }
                    // }else{
                    //     Console.WriteLine($"Lista Vazia");
                        
                    // }

                    using (StreamWriter sw = new StreamWriter($"{novaPj.nome}.txt"))
                    {
                        sw.Write($"{novaPj.nome}");
                    }

                    using (StreamReader sr = new StreamReader($"{novaPj.nome}.txt"))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine($"{linha}");
                            
                        }
                    }
                    
                    
                        break;
                    case "0":
                        Console.WriteLine($"Obrigado por usar nosso sistema!");
                        BarraCarregamento("Finalizando");
                        break;
                    default:
                        Console.WriteLine($"Opção inválida, digite uma opção válida");
                        break;
                }
                
            } while (opcao != "0");
            
            

            
        }
        static void BarraCarregamento(string textoCarregamento){
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);

            for (var i = 0; i < 10; i++)
            {
                Console.Write("_");
                Thread.Sleep(500);
            }
        }
    }
}
