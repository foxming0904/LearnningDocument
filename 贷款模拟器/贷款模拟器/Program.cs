using System;

class Program
{
    static void Main()
    {
        double totalPrice = 600000; // 房屋总价值
        double annualInterestRate = 0.0325; // 年利率
        int loanTermYears = 20; // 贷款期限（年）

        // 计算贷款金额
        double loanAmount = totalPrice;

        // 计算月利率
        double monthlyInterestRate = annualInterestRate / 12;

        // 计算还款期数（总月数）
        int totalPayments = loanTermYears * 12;

        // 使用等额本息计算公式计算每月还款额
        double monthlyPayment = loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalPayments)
                                / (Math.Pow(1 + monthlyInterestRate, totalPayments) - 1);

        // 计算总共还款额
        double totalPaymentsAmount = monthlyPayment * totalPayments;

        Console.WriteLine("每月还款额：" + monthlyPayment.ToString("C2")); // 输出每月还款额
        Console.WriteLine("总共还款额：" + totalPaymentsAmount.ToString("C2")); // 输出总共还款额

        Console.Read();
    }
}
