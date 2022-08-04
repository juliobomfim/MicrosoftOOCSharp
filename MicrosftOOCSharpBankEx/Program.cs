using MicrosftOOCSharpBankEx.Classes;

//BankAccount invalidAccount;
//BankAccount account = new ("Júlio Bomfim", 1000);

//account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
//Console.WriteLine(account.Balance);
//account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
//Console.WriteLine(account.Balance);
//Console.WriteLine(account.GetAccountHistory());
//Console.ReadKey();

//try
//{
//    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
//}
//catch (InvalidOperationException ex)
//{
//    Console.WriteLine("Exception caught trying to overdraw");
//    Console.WriteLine(ex.ToString());
//}


//try
//{
//    invalidAccount = new ("invalid", -55);
//}
//catch(ArgumentOutOfRangeException ex)
//{
//    Console.WriteLine("Exception caught creating account with negative balance");
//    Console.WriteLine(ex.ToString());
//    return;
//}

GiftCardAccount giftCard = new ("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();

giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

InterestEarningAccount savings = new ("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "need to pay monthly bills");

savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

LineOfCreditAccount lineOfCredit = new ("line of credit", 0, 2000);
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "partial restoration on rapairs");

lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());