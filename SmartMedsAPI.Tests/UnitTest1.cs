using FluentAssertions;
using SmartMedsAPI.Models.DTOs;

namespace SmartMedsAPI.Tests;

public class MedicationCreateDtoTests
{
    [Fact]
    public void Quantity_zero_deve_falhar_validacao()
    {
        var dto = new MedicationCreateDTO { Name = "Trinox", Quantity = 0 };
        var errors = ValidationHelper.Validate(dto);
        errors.Should().Contain(e => e.ErrorMessage!.Contains("greater than 0"));
    }

    [Fact]
    public void Quantity_maior_que_zero_deve_ser_valido()
    {
        var dto = new MedicationCreateDTO { Name = "Trinox", Quantity = 1 };
        var errors = ValidationHelper.Validate(dto);
        errors.Should().BeEmpty();
    }
}
