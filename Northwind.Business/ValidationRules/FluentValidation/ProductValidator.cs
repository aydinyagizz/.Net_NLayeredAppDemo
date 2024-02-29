using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // eğer kendi mesajımızı eklemek istersek WithMessage ekliyoruz.
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0); // sıfırdan büyük olmalı
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);

            // eğer categoryId 2 ise UnitPrice 10'da büyük olmalı gibi koşullar da ekleyebiliriz.
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);

            //kendi kuralımızı yazarken Must() kullanıyoruz ve içerisine method ismimizi yazıyoruz.
            // ürün ismi A ile başlamalı gibi kural verdik.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            // ürün ismi A ile başlamalı gibi kural verdik.
            return arg.StartsWith("A");
        }
    }
}
