using System;

namespace bankapp.oldbank
{
    public class conta
    {

        private TipoConta account {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private string Nome {get; set;}

        public conta(TipoConta account, double saldo, double credito, string nome)
        {
            this.account = account;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool withdraw(double valorSaque){

            if(this.Saldo - valorSaque < (this.Credito*(-1))){
                Console.WriteLine("Insuficcient Funds!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} is: {this.Saldo}");

            return true;
        }


        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta e: {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, conta contaDestino){
            if (this.withdraw(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno = $"Account User: {this.Nome}";
            return retorno;
        }

    }
}