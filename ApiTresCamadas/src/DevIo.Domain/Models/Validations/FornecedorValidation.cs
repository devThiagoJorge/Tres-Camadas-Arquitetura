using DevIo.Domain.Models.Validations.DocumentosValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Domain.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            When(c => c.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(c => CpfCnpjUtils.IsCpf(c.Documento))
                .Equal(true).WithMessage("O documento fornecido é inválido.");
            });

            When(c => c.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(c => CpfCnpjUtils.IsCnpj(c.Documento))
                .Equal(true).WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
