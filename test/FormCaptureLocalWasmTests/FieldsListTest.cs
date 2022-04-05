using Xunit;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using FormCaptureLocalWasm.Shared.Components;
using FormCaptureLocalWasm.Models.DbModels;
using System.Collections.Generic;

namespace FormCaptureLocalWasmTests;

/// <summary>
/// Template's fields list tests.
/// </summary>
public class FieldsListTests
{
    /// <summary>
    /// Test if fields list displays items correctly.
    /// </summary>
    [Fact]
    public void FieldsListDisplayTest()
    {
        List<Field> data = new List<Field>()
        {
            new Field() { ID = 1, Name = "Test field 1" },
            new Field() { ID = 2, Name = "Test field 2" },
            new Field() { ID = 3, Name = "Test field 3" }
        };
        using var context = new TestContext();
        //Add services to context
        _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        var fieldsList = context.RenderComponent<FieldsList>();
        fieldsList.Instance.Fields = data;
    }
}