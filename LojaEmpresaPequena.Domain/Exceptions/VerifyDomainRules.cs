using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Exceptions
{
    public   class VerifyDomainRules
    {
        public List<string> Errors = new List<string>();

        public static VerifyDomainRules CreateInstance()
        {
            return new VerifyDomainRules();
        }

        public  VerifyDomainRules VerifyRule(bool condition, string msg)
        {
            if (condition == true)
            {
                Errors.Add(msg);
            }
            return this;
        }

        public void ThrowExceptionDomain()
        {
            if(Errors.Count > 0)
            {
            throw new DominioException(Errors);
            }
        }


    }
}
