namespace MicrosftOOCSharpBankEx.Classes
{
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;
        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}
