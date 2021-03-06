﻿using System.Collections.Generic;
using Equinor.Procosys.DDDAPI.WebApi.Misc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Equinor.Procosys.DDDAPI.WebApi.Middleware
{
    public class AddSchemaHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = PlantProvider.PlantHeader,
                In = ParameterLocation.Header,
                Required = true
            });
        }
    }
}
