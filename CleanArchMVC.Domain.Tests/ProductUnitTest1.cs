using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultOBjectValidState()
        {
            Action action = () => new Product(1,"Produto Name","Description",10,5,"Source Path");

            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative ID")]
        public void CreateProduty_WithNegativeIdValue_ResultDomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Produto Name", "Description", 10, 5, "Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortName_ResultDomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Description", 10, 5, "Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_ShortDescription_ResultDomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Produto Name", "Desc", 10, 5, "Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalide Price")]
        public void CreateProduct_NegativePrice_ResultDomainExceptionInvalidePrice()
        {
            Action action = () => new Product(1, "Produto Name", "Description", -10, 5, "Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Invalide Stock")]
        public void CreateProduct_NegativeStock_ResultDomainExceptionInvalideStock()
        {
            Action action = () => new Product(1, "Produto Name", "Description", 10, -5, "Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Invalide Image Name")]
        public void CreateProduct_InvalideImageName_ResultDomainExceptionInvalideImage()
        {
            Action action = () => new Product(1, "Produto Name", "Description", 10, 5, "Source Path,Source Path," +
                "Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path," +
                "Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path," +
                "Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path," +
                "Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path,Source Path");

            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_ResultNoDomainExecepiton()
        {
            Action action = () => new Product(1, "Produto Name", "Description", 10, 5,null);

            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_NoNullReferenceExcepiton()
        {
            Action action = () => new Product(1, "Produto Name", "Description", 10, 5, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }


    }
}
