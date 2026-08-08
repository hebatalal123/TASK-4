using System;

public class Account
{
    public string Name { get; set; }
    public double Balance { get; set; }

    public Account(string name = "Unnamed Account", double balance = 0.0)
    {
        this.Name = name;
        this.Balance = balance;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount < 0)
            return false;

        Balance += amount;
        return true;
    }

    public virtual bool Withdraw(double amount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"[{Name}: {Balance:C}]";
    }
}



public class SavingsAccount : Account
{
    public double InterestRate { get; set; }

    public SavingsAccount(
        string name = "Unnamed Savings Account",
        double balance = 0.0,
        double interestRate = 0.0)
        : base(name, balance)
    {
        InterestRate = interestRate;
    }

    public override bool Deposit(double amount)
    {
        if (amount < 0)
            return false;

        double interest = Balance * (InterestRate / 100);

        Balance += amount + interest;

        return true;
    }
}




public class CheckingAccount : Account
{
    private const double Fee = 1.50;

    public CheckingAccount(
        string name = "Unnamed Checking Account",
        double balance = 0.0)
        : base(name, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        double total = amount + Fee;

        if (Balance - total >= 0)
        {
            Balance -= total;
            return true;
        }

        return false;
    }
}

public class TrustAccount : Account
{
    public double InterestRate { get; set; }

    private int withdrawalCount = 0;

    public TrustAccount(
        string name = "Unnamed Trust Account",
        double balance = 0.0,
        double interestRate = 0.0)
        : base(name, balance)
    {
        InterestRate = interestRate;
    }

    public override bool Deposit(double amount)
    {
        if (amount < 0)
            return false;

        double interest = Balance * (InterestRate / 100);

        Balance += amount + interest;

        
        if (amount >= 5000)
        {
            Balance += 50;
        }

        return true;
    }

    public override bool Withdraw(double amount)
    {
      
        if (withdrawalCount >= 3)
            return false;

        
        if (amount >= Balance * 0.20)
            return false;

        if (amount <= 0)
            return false;

        Balance -= amount;
        withdrawalCount++;

        return true;
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        
        Account account = new Account("Heba", 1000);

        Console.WriteLine(account);

        account.Deposit(500);
        Console.WriteLine(account);

        account.Withdraw(200);
        Console.WriteLine(account);


      
        SavingsAccount savings =
            new SavingsAccount("Savings", 1000, 10);

        Console.WriteLine(savings);

        savings.Deposit(500);
        Console.WriteLine(savings);


        
        CheckingAccount checking =
            new CheckingAccount("Checking", 1000);

        Console.WriteLine(checking);

        checking.Withdraw(100);
        Console.WriteLine(checking);


        
        TrustAccount trust =
            new TrustAccount("Trust", 10000, 5);

        Console.WriteLine(trust);

        trust.Deposit(5000);
        Console.WriteLine(trust);

        trust.Withdraw(1000);
        Console.WriteLine(trust);

        Console.ReadLine();
    }
}