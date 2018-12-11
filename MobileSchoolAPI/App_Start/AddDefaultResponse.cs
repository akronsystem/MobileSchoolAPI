using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Description;

namespace AgroApp.App_Start
{
    public class AddFormDataUploadParamTypes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "HomeWork_Test")
            {
                operation.consumes.Add("multipart/form-data");
                operation.parameters = new[]
                {
                    new Parameter
                        {
                            name = "Userid",
                            @in  = "formData",
                            description = "name of register person",
                            required = false,
                            type = "string",
                            format = "uuid"

                        },
                        new Parameter
                        {
                            name = "address",
                            @in  = "formData",
                            description = "",
                            required = false,
                            type = "string",
                            format = "uuid"
                        },
                        new Parameter
                        {
                            name = "mobileno",
                            @in  = "formData",
                            description = "",
                            required = true,
                            type = "string"
                        },
                        new Parameter
                        {
                            name = "farmdetails",
                            @in  = "formData",
                            description = "",
                            required = false,
                            type = "string"
                        }, 
                        new Parameter 
                        { 
                            name = "file", 
                            @in = "formData", 
                            description = "File to upload.",
                            required = true, 
                            type = "file" 
                        }
                    };
            }
            
           
        }
    }
}
