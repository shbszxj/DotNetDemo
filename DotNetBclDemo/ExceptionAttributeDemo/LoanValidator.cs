using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionAttributeDemo
{
    public class LoanValidator
    {
        [MethodDescriptionAttribute("Validating loan application")]
        public bool CheckLoanApplication()
        {
            bool isValidPersonalDetail = CheckPersonalDetail();
            bool isValidEmploymentDetail = CheckEmploymentDetail();
            bool isValidBankAccountDetail = CheckBankAccountDetail();

            if (isValidPersonalDetail && isValidEmploymentDetail && isValidBankAccountDetail)
                return true;
            else
                return false;
        }

        [MethodDescriptionAttribute("Checking personal detail")]
        private bool CheckPersonalDetail()
        {
            return true;
        }

        [MethodDescriptionAttribute("Checking employment detail")]
        private bool CheckEmploymentDetail()
        {
            return true;
        }
        [MethodDescriptionAttribute("Checking bank account detail")]
        private bool CheckBankAccountDetail()
        {
            CheckAnyOutstanding();
            return true;
        }

        [MethodDescriptionAttribute("Checking outstanding detail from common web server")]
        private bool CheckAnyOutstanding()
        {
            throw new WebException();
        }
    }
}
