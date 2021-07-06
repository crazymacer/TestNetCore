using Core.DTOs;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    public class ProductoValidator : AbstractValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.Nombre)
                .NotNull()
                .Length(5, 250);

            RuleFor(producto => producto.Stock)
                .NotNull();
            
            //RuleFor(producto => producto.Stock)
            //    .NotNull();
        }
    }
}
