using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionAttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var loanValidator = new LoanValidator();
                loanValidator.CheckLoanApplication();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ExceptionHelper.GetDetailMessage(ex);
                Console.Write(exceptionMessage);
                Console.Read();
            }
        }
    }
}
