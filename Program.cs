using System;
using System.Collections.Generic;

namespace bankapp.oldbank

{
    class Program
    {
        static List<conta> listAccounts = new List<conta>();
        static void Main(string[] args)
        {
            string selectedOption = getUserOption();

            while(selectedOption.ToUpper() != "X"){

                switch (selectedOption){

                    case "1":
                        lsAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        transfer();
                        break;
                    case "4":
                        withdraw();
                        break;
                    case "5":
                        deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }

                selectedOption = getUserOption();
            }

            Console.WriteLine("Thank you for using our old services.");
            Console.ReadLine();
        
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert New Account: ");

            Console.Write("Type 1 for Conta Fisica or 2 for Juridica: ");
            int inputAccountKind = int.Parse(Console.ReadLine());

            Console.Write("Insert Client Name: ");
            string inputName = Console.ReadLine();

            Console.Write("Insert initial account money: ");
            double inputMoney = double.Parse(Console.ReadLine());

            Console.Write("Insert Desired Credit margin: ");
            double inputCredit = double.Parse(Console.ReadLine());

            conta newAccount = new conta(account: (TipoConta)inputAccountKind,
                                         saldo: inputMoney,
                                         credito: inputCredit,
                                         nome: inputName);

            listAccounts.Add(newAccount);

        }

        private static void lsAccounts(){
            Console.WriteLine("List of all account in old bank:");

            if (listAccounts.Count == 0){

                Console.WriteLine("No registered account");
                return;
            }
            for (int i = 0; i < listAccounts.Count; i++){
                conta account = listAccounts[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(account);
            }
        }

        private static void withdraw(){
            Console.Write("Insert account number: ");
            int iaccount = int.Parse(Console.ReadLine());

            Console.Write("Insert Amount to be withdrawn: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccounts[iaccount].withdraw(withdrawValue);
        }

        private static void deposit(){
            Console.Write("Insert account number: ");
            int iaccount = int.Parse(Console.ReadLine());

            Console.Write("Insert Amount to deposit: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccounts[iaccount].Depositar(depositValue);
        }

        private static void transfer(){
            Console.Write("Insert origin account number: ");
            int ioaccount = int.Parse(Console.ReadLine());

            Console.Write("Insert destin account number: ");
            int idaccount = int.Parse(Console.ReadLine());

            Console.Write("Insert Amount to Transfer: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccounts[ioaccount].Transferir(transferValue,listAccounts[idaccount]);
        }
        private static string getUserOption()
            {
            Console.WriteLine();
            Console.WriteLine("OldBank, the opposite of NuBankat your service: ");
            Console.WriteLine("Select Option: ");

            Console.WriteLine("1- List Accounts");
            Console.WriteLine("2- Insert New Account");
            Console.WriteLine("3- Transfer");
            Console.WriteLine("4- Withdraw");
            Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Clear Display");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

    }
}
