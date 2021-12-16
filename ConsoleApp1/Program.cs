using System;
using System.Data.SqlClient;

namespace CRUD_Console
{
    public class Program
    {
        static void Main(string[] args)

        {
            //MENU DE OPÇÕES
            Console.WriteLine("Digite 1 para adicionar registro");
            Console.WriteLine("Digite 2 para exibir todos registro");
            Console.WriteLine("Digite 3 deletar registro");
            Console.WriteLine("Digite 4 atualizar registro");
            Console.Write("Digite uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                //ADICIONAR REGISTROS
                SqlConnection sqlConnection;
                string cs = ("DATA SOURCE=NOTE-RENANOGA; INITIAL CATALOG=FTI; Trusted_Connection=True");
                try
                {
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                    Console.WriteLine("Conexão Estabelecida com sucesso!");

                    Console.Write("Digite o ID da banda: ");
                    int ID = int.Parse(Console.ReadLine());
                    Console.Write("Digite a descrição da banda: ");
                    string descricao = Console.ReadLine();

                    string insertQuery = "INSERT INTO Bandas VALUES (" + ID + ",'" + descricao + "')";
                    SqlCommand command = new SqlCommand(insertQuery, sqlConnection);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.WriteLine("Registro adicionado com sucesso!!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            //EXIBIR REGISTROS
            else
                if (opcao == 2)
            {
                SqlConnection sqlConnection;
                string cs = ("DATA SOURCE=NOTE-RENANOGA; INITIAL CATALOG=FTI; Trusted_Connection=True");
                try
                {
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                    Console.WriteLine("Conexão Estabelecida com sucesso!");

                    string visQuery = "SELECT*FROM Bandas ORDER BY ID DESC";
                    SqlCommand command = new SqlCommand(visQuery, sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) //true eqto ainda possuir linhas
                    {
                        Console.Write("Id: " + reader.GetInt32(0));
                        Console.WriteLine(" Descrição: " + reader.GetString(1));
                    }
                    reader.Close();
                    sqlConnection.Close();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            //DELETAR REGISTROS
            else if (opcao == 3)
            {
                SqlConnection sqlConnection;
                string cs = ("DATA SOURCE=NOTE-RENANOGA; INITIAL CATALOG=FTI; Trusted_Connection=True");
                try
                {
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                    Console.WriteLine("Conexão Estabelecida com sucesso!");
                    Console.Write("Digite o ID que quer excluir: ");
                    int exc = int.Parse(Console.ReadLine());
                    string delQuery = "DELETE FROM Bandas WHERE ID = " + exc;

                    SqlCommand command = new SqlCommand(delQuery, sqlConnection);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.Write("Registro deletado com sucesso!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            //ATUALIZAR REGISTRO
            else if (opcao == 4)
            {
                SqlConnection sqlConnection;
                string cs = ("DATA SOURCE=NOTE-RENANOGA; INITIAL CATALOG=FTI; Trusted_Connection=True");
                try
                {
                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();

                    Console.WriteLine("Conexão Estabelecida com sucesso!");
                    Console.Write("Digite o ID que quer atualizar: ");
                    int id_at = int.Parse(Console.ReadLine());
                    Console.Write("Digite a nova descrição: ");
                    string desc_at = Console.ReadLine();

                    string updateQuery = "UPDATE Bandas SET descricao = " + "'" + desc_at + "'" + " WHERE ID = " + id_at;
                    Console.Write("Registro atualizado com sucesso!");

                    SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                }
                catch (Exception e) { Console.WriteLine(e); }
            }
        }
    }
}
