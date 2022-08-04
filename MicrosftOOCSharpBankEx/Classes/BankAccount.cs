namespace MicrosftOOCSharpBankEx.Classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();

        private readonly decimal _minimumBalance;

        #region Class Constructors

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        public BankAccount(string name, decimal initialBalance, decimal minumumBalance)
        {
            Owner = name;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            _minimumBalance = minumumBalance;

            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        #endregion

        #region Properties
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance 
        {
            get 
            {
                decimal balance = 0;

                foreach(var transaction in allTransactions)
                    balance += transaction.Amount;

                return balance;
            } 
        }
        #endregion

        #region Main methods
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

            Transaction deposit = new (amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amountof withdrawal must be positive");

            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new (-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funs for this withdrawal ");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            }

            return report.ToString();
        }
        #endregion

        #region Polymorphism methods
        public virtual void PerformMonthEndTransactions()
        {
        }
        #endregion
    }
}
