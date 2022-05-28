# Controle de contatos

<b>1-</b> Vá ao program.cs.<br>
<b>3-</b> Inclua o seu login de conexão do SQL server.<br>
<b>3-</b> Altere o nome do banco de dados.<br><br>

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer("Server=SuaConexao;Database=NomeDoBancoDeDados;Trusted_Connection=True;"));

            var app = builder.Build();
