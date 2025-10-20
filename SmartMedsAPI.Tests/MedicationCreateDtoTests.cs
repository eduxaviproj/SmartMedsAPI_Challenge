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
        errors.Should().Contain(e => e.ErrorMessage!.Contains("greater than 0")); // ASSERT: Confirma que o erro esperado (relacionado à restrição "greater than 0")
    }                                                                             //            está presente na lista de resultados de validação

    [Fact]
    public void Quantity_maior_que_zero_deve_ser_valido()
    {
        var dto = new MedicationCreateDTO { Name = "Trinoxide", Quantity = 1 };
        var errors = ValidationHelper.Validate(dto);
        errors.Should().BeEmpty();
    }
}
