﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_to_Mediator_Structure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] commands = new string[]
        {
            "Create",
            "Update",
            "Remove"
        };
        string[] handlers = new string[]
     {
            "Create",
            "Update",
            "Remove"
     };
        StringBuilder stringBuilder = new StringBuilder();
        StringBuilder stringBuilder2 = new StringBuilder();
        StringBuilder stringBuilder3 = new StringBuilder();
        StringBuilder stringBuilder4 = new StringBuilder();
        StringBuilder stringBuilder5 = new StringBuilder();
        StringBuilder stringBuilder6 = new StringBuilder();
        StringBuilder stringBuilder7 = new StringBuilder();

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Commands");
            Directory.CreateDirectory("Queries");
            Directory.CreateDirectory("Handlers");
            Directory.CreateDirectory("Results");
            Directory.CreateDirectory("Dtos");
            Directory.CreateDirectory("Dtos//"+textBox2.Text+"Dtos");
            Directory.CreateDirectory("Views");
            Directory.CreateDirectory("Views//Admin"+textBox2.Text);

            Directory.CreateDirectory("Commands//" + textBox2.Text + "Commands");
            Directory.CreateDirectory("Queries//" + textBox2.Text + "Queries");
            Directory.CreateDirectory("Handlers//" + textBox2.Text + "Handlers");
            Directory.CreateDirectory("Results//" + textBox2.Text + "Results");

            for (int i = 0; i < commands.Length; i++)
            {

                stringBuilder.Clear();
                for (int j = 0; j < richTextBox1.Lines.Length; j++)
                {
                    if (i == 0)
                    {
                        if (j != 0)
                            stringBuilder.Append(richTextBox1.Lines[j] + "\n");
                    }
                    else if (i == 1)
                    {
                        stringBuilder.Append(richTextBox1.Lines[j] + "\n");

                    }
                    else if (i == 2)
                    {
                        if (j == 0)
                            stringBuilder.Append(" public int Id { get; set; }\r\n\r\n        public Remove" + textBox2.Text + "Command(int id)\r\n        {\r\n            Id = id;\r\n        }");
                    }
                }
                File.WriteAllText("Commands//" + textBox2.Text + "Commands" + "//" + commands[i] + textBox2.Text + "Command.cs",
                    "using MediatR;\n" +
                    $"namespace {textBox1.Text}.Application.Features.Mediator.Commands.{textBox2.Text}Commands\n" +
                    "{\n" +
                    $"\tpublic class {commands[i]}{textBox2.Text}Command : IRequest\n" +
                    "\t{\n" + stringBuilder + "\n" +
                    "}" +
                    "}"

                    );
                if (i != 2)
                {

                File.WriteAllText("Dtos//" + textBox2.Text + "Dtos" + "//" + commands[i] + textBox2.Text + "Dto.cs",
                                       "namespace " + textBox1.Text + ".Dtos." + textBox2.Text + "Dtos\n" +
                                                          "{\n" +
                                                                             "    public class "+ commands[i] + textBox2.Text + "Dto\n" +
                                                                                                "    {\n" + stringBuilder + "\n" +
                                                                                                                   "    }\n" +
                                                                                                                                      "}\n"
                                                                                                                                                         );

                }



            }
            for (int i = 0; i < handlers.Length; i++)
            {
                stringBuilder.Clear();
                stringBuilder2.Clear();
                stringBuilder3.Clear();
                stringBuilder4.Clear();
                stringBuilder5.Clear();
                for (int j = 0; j < richTextBox1.Lines.Length; j++)
                {
                    if (j != 0)
                    {
                        stringBuilder2.Append(richTextBox1.Lines[j].Split(' ')[2] + " = request." + richTextBox1.Lines[j].Split(' ')[2] + ",\n");
                        stringBuilder3.Append("values." + richTextBox1.Lines[j].Split(' ')[2] + " = request." + richTextBox1.Lines[j].Split(' ')[2] + ";\n");

                    }
                }
                if (i == 0)
                {
                    File.WriteAllText("Handlers//" + textBox2.Text + "Handlers" + "//" + handlers[i] + textBox2.Text + "CommandHandler.cs"

                        ,
                    $"using {textBox1.Text}.Application.Features.Mediator.Commands.{textBox2.Text}Commands;\r\n" +
                        $"using {textBox1.Text}.Application.Interfaces;\r\n" +
                        $"using {textBox1.Text}.Domain.Entities;\r\n" +
                        $"using MediatR;\r\n" +
                        $"using System;\r\n" +
                        $"using System.Collections.Generic;\r\n" +
                        $"using System.Linq;\r\n" +
                        $"using System.Text;\r\n" +
                        $"using System.Threading.Tasks;\r\n" +
                        $"\r\n" +
                        $"namespace {textBox1.Text}.Application.Features.Mediator.Handlers.{textBox2.Text}Handlers\r\n" +
                        $"{{\r\n    public class {handlers[i]}{textBox2.Text}CommandHandler : IRequestHandler<{handlers[i]}{textBox2.Text}Command>\r\n    " +
                        $"{{\r\n        private readonly IRepository<{textBox2.Text}> _repository;\r\n\r\n        " +
                        $"public {handlers[i]}{textBox2.Text}CommandHandler(IRepository<{textBox2.Text}> repository)\r\n        " +
                        $"{{\r\n            _repository = repository;\r\n        }}\r\n\r\n        " +
                        $"public async Task Handle({handlers[i]}{textBox2.Text}Command request, CancellationToken cancellationToken)\r\n        " +
                        $"{{\r\n            await _repository.CreateAsync(new {textBox2.Text}\r\n            " +
                        $"{{\r\n                " +
                        stringBuilder2 + "\n" +

                        $"}});\r\n        " +
                        $"}}\r\n    " +
                        $"}}\r\n}}\r\n");
                }
                if (i == 1)
                {
                    File.WriteAllText("Handlers//" + textBox2.Text + "Handlers" + "//" + handlers[i] + textBox2.Text + "CommandHandler.cs"

                        ,
                    $"using {textBox1.Text}.Application.Features.Mediator.Commands.{textBox2.Text}Commands;\r\n" +
                        $"using {textBox1.Text}.Application.Interfaces;\r\n" +
                        $"using {textBox1.Text}.Domain.Entities;\r\n" +
                        $"using MediatR;\r\n" +
                        $"using System;\r\n" +
                        $"using System.Collections.Generic;\r\n" +
                        $"using System.Linq;\r\n" +
                        $"using System.Text;\r\n" +
                        $"using System.Threading.Tasks;\r\n" +
                        $"\r\n" +
                        $"namespace {textBox1.Text}.Application.Features.Mediator.Handlers.{textBox2.Text}Handlers\r\n" +
                        $"{{\r\n    public class {handlers[i]}{textBox2.Text}CommandHandler : IRequestHandler<{handlers[i]}{textBox2.Text}Command>\r\n    " +
                        $"{{\r\n        private readonly IRepository<{textBox2.Text}> _repository;\r\n\r\n        " +
                        $"public {handlers[i]}{textBox2.Text}CommandHandler(IRepository<{textBox2.Text}> repository)\r\n        " +
                        $"{{\r\n            _repository = repository;\r\n        }}\r\n\r\n        " +
                        $"public async Task Handle({handlers[i]}{textBox2.Text}Command request, CancellationToken cancellationToken)\r\n        " +
                        $"{{\r\n             var values = await _repository.GetByIdAsync(request.{textBox2.Text}Id);\n" +
                        stringBuilder3 + "\n" +
                       $"await _repository.UpdateAsync(values);" +
                       $"}}}}}}");

                }
                if (i == 2)
                {
                    File.WriteAllText("Handlers//" + textBox2.Text + "Handlers" + "//" + handlers[i] + textBox2.Text + "CommandHandler.cs"

                        ,
                    $"using {textBox1.Text}.Application.Features.Mediator.Commands.{textBox2.Text}Commands;\r\n" +
                        $"using {textBox1.Text}.Application.Interfaces;\r\n" +
                        $"using {textBox1.Text}.Domain.Entities;\r\n" +
                        $"using MediatR;\r\n" +
                        $"using System;\r\n" +
                        $"using System.Collections.Generic;\r\n" +
                        $"using System.Linq;\r\n" +
                        $"using System.Text;\r\n" +
                        $"using System.Threading.Tasks;\r\n" +
                        $"\r\n" +
                        $"namespace {textBox1.Text}.Application.Features.Mediator.Handlers.{textBox2.Text}Handlers\r\n" +
                        $"{{\r\n    public class {handlers[i]}{textBox2.Text}CommandHandler : IRequestHandler<{handlers[i]}{textBox2.Text}Command>\r\n    " +
                        $"{{\r\n        private readonly IRepository<{textBox2.Text}> _repository;\r\n\r\n        " +
                        $"public {handlers[i]}{textBox2.Text}CommandHandler(IRepository<{textBox2.Text}> repository)\r\n        " +
                        $"{{\r\n            _repository = repository;\r\n        }}\r\n\r\n        " +
                        $"public async Task Handle({handlers[i]}{textBox2.Text}Command request, CancellationToken cancellationToken)\r\n        " +
                        $"{{\r\n  var values=await _repository.GetByIdAsync(request.Id);\r\n            await _repository.RemoveAsync(values);}}\r\n    }}\r\n}}\r\n");

                }

            }

            for (int i = 0; i < 2; i++)
            {
                stringBuilder5.Clear();
                for (int j = 0; j < richTextBox1.Lines.Length; j++)
                {

                    stringBuilder4.Append(richTextBox1.Lines[j].Split(' ')[2] + " = x." + richTextBox1.Lines[j].Split(' ')[2] + ",\n");
                    stringBuilder5.Append(richTextBox1.Lines[j].Split(' ')[2] + " = values." + richTextBox1.Lines[j].Split(' ')[2] + ",\n");


                }
                if (i == 0)
                {

                    File.WriteAllText("Handlers//" + textBox2.Text + "Handlers" + "//" + "Get" + textBox2.Text + "QueryHandler.cs"

                          ,
                          $"using {textBox1.Text}.Application.Features.Mediator.Queries.{textBox2.Text}Queries;\r\nusing {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results;\r\nusing {textBox1.Text}.Application.Interfaces;\r\nusing {textBox1.Text}.Domain.Entities;\r\nusing MediatR;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace {textBox1.Text}.Application.Features.Mediator.Handlers.{textBox2.Text}Handlers\r\n{{\r\n    public class Get{textBox2.Text}QueryHandler : IRequestHandler<Get{textBox2.Text}Query, List<Get{textBox2.Text}QueryResult>>\r\n    {{\r\n        private readonly IRepository<{textBox2.Text}> _repository;\r\n\r\n        public Get{textBox2.Text}QueryHandler(IRepository<{textBox2.Text}> repository)\r\n        {{\r\n            _repository = repository;\r\n        }}\r\n        public async Task<List<Get{textBox2.Text}QueryResult>> Handle(Get{textBox2.Text}Query request, CancellationToken cancellationToken)\r\n        {{\r\n            var values = await _repository.GetAllAsync();\r\n            return values.Select(x => new Get{textBox2.Text}QueryResult\r\n            {{" +
                          stringBuilder4 + $"\n}}).ToList();\r\n        }}\r\n    }}\r\n}}\r\n");

                }
                if (i == 1)
                {
                    File.WriteAllText("Handlers//" + textBox2.Text + "Handlers" + "//" + "Get" + textBox2.Text + "ByIdQueryHandler.cs"

                          ,
                          $"using {textBox1.Text}.Application.Features.Mediator.Queries.{textBox2.Text}Queries;\r\nusing {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results;\r\nusing {textBox1.Text}.Application.Interfaces;\r\nusing {textBox1.Text}.Domain.Entities;\r\nusing MediatR;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace {textBox1.Text}.Application.Features.Mediator.Handlers.{textBox2.Text}Handlers\r\n{{\r\n    public class Get{textBox2.Text}ByIdQueryHandler : IRequestHandler<Get{textBox2.Text}ByIdQuery, Get{textBox2.Text}ByIdQueryResult>\r\n    {{\r\n        private readonly IRepository<{textBox2.Text}> _repository;\r\n\r\n        public Get{textBox2.Text}ByIdQueryHandler(IRepository<{textBox2.Text}> repository)\r\n        {{\r\n            _repository = repository;\r\n        }}\r\n\r\n        public async Task<Get{textBox2.Text}ByIdQueryResult> Handle(Get{textBox2.Text}ByIdQuery request, CancellationToken cancellationToken)\r\n        {{\r\n            var values = await _repository.GetByIdAsync(request.Id);\r\n            return new Get{textBox2.Text}ByIdQueryResult\r\n            {{" +
                          stringBuilder5 + $"}};\r\n        }}\r\n    }}\r\n}}\r\n");
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    File.WriteAllText("Queries//" + textBox2.Text + "Queries" + "//" + "Get" + textBox2.Text + "Query.cs"

                         ,
                         $"using {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results;\r\nusing MediatR;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace {textBox1.Text}.Application.Features.Mediator.Queries.{textBox2.Text}Queries\r\n{{\r\n    public class Get{textBox2.Text}Query: IRequest<List<Get{textBox2.Text}QueryResult>>\r\n    {{\r\n    }}\r\n}}\r\n");
                }
                if (i == 1)
                {
                    File.WriteAllText("Queries//" + textBox2.Text + "Queries" + "//" + "Get" + textBox2.Text + "ByIdQuery.cs"

                        ,
                        $"using {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results;\r\nusing MediatR;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace {textBox1.Text}.Application.Features.Mediator.Queries.{textBox2.Text}Queries\r\n{{\r\n    public class Get{textBox2.Text}ByIdQuery:IRequest<Get{textBox2.Text}ByIdQueryResult>\r\n    {{\r\n        public int Id {{ get; set; }}\r\n\r\n        public Get{textBox2.Text}ByIdQuery(int id)\r\n        {{\r\n            Id = id;\r\n        }}\r\n    }}\r\n}}\r\n");
                }

            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    File.WriteAllText("Results//" + textBox2.Text + "Results" + "//" + "Get" + textBox2.Text + "QueryResult.cs"

                         ,
                         $"namespace {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results\r\n{{\r\n    public class Get{textBox2.Text}QueryResult\r\n    {{"+richTextBox1.Text+$"" +
                         $"    }}\r\n}}\r\n");
                    File.WriteAllText("Dtos//" + textBox2.Text + "Dtos" + "//" + "Result" + textBox2.Text + "Dto.cs",
                                                              "namespace " + textBox1.Text + ".Dtos." + textBox2.Text + "Dtos\n" +
                                                                                                                       "{\n" +
                                                                                                                                                                                                   "    public class Result" + textBox2.Text + "Dto\n" +
                                                                                                                                                                                                                                                                                                  "    {\n" + richTextBox1.Text + "\n" +
                                                                                                                                                                                                                                                                                                                                                                                                                    "    }\n" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "}\n");
                }
                if (i == 1)
                {
                    File.WriteAllText("Results//" + textBox2.Text + "Results" + "//" + "Get" + textBox2.Text + "ByIdQueryResult.cs"

                        ,
                        $"namespace {textBox1.Text}.Application.Features.Mediator.Results.{textBox2.Text}Results\r\n{{\r\n    public class Get{textBox2.Text}ByIdQueryResult\r\n    {{"+richTextBox1.Text+$"" +
                        $"}}\r\n}}\r\n");
                }
            }


            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                if (i != 0)
                {
                    stringBuilder6.Append("<th>" + richTextBox1.Lines[i].Split(' ')[2].ToString() + "</th>\n");
                    stringBuilder7.Append("<td>@item." + richTextBox1.Lines[i].Split(' ')[2].ToString() + "</td>\n");

                }
            }


           string main= " @using "+textBox1.Text+".Dtos."+textBox2.Text+"Dtos\n" +
 "@model List<Result"+textBox2.Text+"Dto> \n" +
 "@{\n" +
 "    ViewData[\"Title\"] = \"Index\";\n" +
 "    Layout = \"~/Views/AdminLayout/Index.cshtml\";\n" +
 "    int count = 1;\n" +
 "}\n" +

 "< !-- Plugins css -->\n" +
 "< link href=\"~/Admin/plugins/datatables/dataTables.bootstrap4.css\" rel=\"stylesheet\" type=\"text/css\" />\n" +
 "<link href=\"~/Admin/plugins/datatables/responsive.bootstrap4.css\" rel=\"stylesheet\" type=\"text/css\" />\n" +
 "<link href=\"~/Admin/plugins/datatables/buttons.bootstrap4.css\" rel=\"stylesheet\" type=\"text/css\" />\n" +
 "<link href=\"~/Admin/plugins/datatables/select.bootstrap4.css\" rel=\"stylesheet\" type=\"text/css\" />\n" +

 "< div class=\"page-content\">\n" +
 "    <div class=\"container-fluid\">\n" +

 "        < !-- start page title -->\n" +
 "        < div class=\"row\">\n" +
 "            <div class=\"col-12\">\n" +
 "                <div class=\"card\">\n" +
 "                    <div class=\"card-body\">\n" +
 "                        <h4 class=\"card-title\">"+textBox2.Text+"</h4>\n" +
 "                        <p class=\"card-subtitle mb-4\">\n" +
 "                            "+textBox2.Text+" bu kısımda görüntüleyebilirsiniz.\n" +

 "                        </p>\n" +

 "                        <table id=\"basic-datatable\" class=\"table dt-responsive\">\n" +
 "                            <thead>\n" +
 "                                <tr>\n" +
 "                                    <th>#</th>\n" +stringBuilder6.ToString()+"\n"+                                 
 "                                    <th>Güncelle</th>\n" +
 "                                    <th>Kaldır</th>\n" +
 "                                    <th></th>\n" +
 "                                </tr>\n" +
 "                            </thead>\n" +

 "                            <tbody>\n" +
 "                                @foreach (var item in Model)\n" +
 "                                {\n" +

 "                                    <tr>\n" +
 "                                        <td>@count</td>\n" + stringBuilder7.ToString()+"\n"+                                     
 "                                        <td><a href=\"/User/Update"+textBox2.Text+"/@item.Id\" class=\"btn btn-success\">Güncelle</a></td>\n" +
 "                                        <td><a href=\"/User/Remove"+textBox2.Text+"/@item.Id\" class=\"btn btn-danger\">Kaldır</a></td>\n" +
 "                                        <td></td>\n" +

 "                                    </tr>\n" +
 "                                    count++;\n" +
 "                                }\n" +
 "                            </tbody>\n" +
 "                        </table>\n" +

 "                    </div> <!-- end card body-->\n" +
 "                </div> <!-- end card -->\n" +
 "            </div><!-- end col-->\n" +
 "        </div>\n" +
 "        < !-- end page title -->\n" +

 "    </div> <!-- container-fluid -->\n" +
 "</div>";

            File.WriteAllText("Views//Admin" + textBox2.Text + "//Index.cshtml", main);

        }
    }
}

