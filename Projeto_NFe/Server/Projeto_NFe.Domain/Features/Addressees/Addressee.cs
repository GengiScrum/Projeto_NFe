using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addressees
{
    public class Addressee
    {
        public virtual int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public Address Address { get; set; }
        public EnumPersonType PersonType { get; set; }

        public virtual void Validate()
        {
            //if (Name.Length < 4 || Name.Length > 40) throw new AddresseeNameInvalidExcecao();
            //if (Address == null) throw new AddresseeAddressInvalidExcecao();

            //if (PersonType == EnumPersonType.PessoaFisica)
            //{
            //    bool existeCaracterInvalid = Regex.IsMatch(Cpf, "[^0-9]+");
            //    if (Cpf.Length != 11 || existeCaracterInvalid) throw new AddresseeCpfInvalidExcecao();
            //    if (!String.IsNullOrEmpty(Cnpj)) throw new AddresseePessoaFisicaNaoPodePossuirCnpjExcecao();
            //    if (!String.IsNullOrEmpty(CorporateName)) throw new AddresseePessoaFisicaNaoPodePossuirCorporateNameExcecao();
            //    if (!String.IsNullOrEmpty(StateRegistration)) throw new AddresseePessoaFisicaNaoPodePossuirStateRegistrationExcecao();
            //}
            //if (PersonType == EnumPersonType.PessoaJuridica)
            //{
            //    if (CorporateName.Length < 3 || CorporateName.Length > 40) throw new AddresseeCorporateNameInvalidExcecao();
            //    bool existeCaracterInvalid = Regex.IsMatch(Cnpj, "[^0-9]+");
            //    if (Cnpj.Length != 14 || existeCaracterInvalid) throw new AddresseeCnpjInvalidExcecao();
            //    if (!String.IsNullOrEmpty(Cpf)) throw new AddresseePessoaJuridicaNaoPodePossuirCpfExcecao();
            //    if (String.IsNullOrEmpty(StateRegistration)) throw new AddresseeStateRegistrationInvalidExcecao();
            //}
        }
    }
}
