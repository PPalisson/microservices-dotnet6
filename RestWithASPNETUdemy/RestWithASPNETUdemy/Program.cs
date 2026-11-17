// Program.cs: ponto de entrada; configura servicos, documentacao e rotas da API.
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;

// Carrega a configuracao e prepara a aplicacao.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Registra o suporte aos controllers.
builder.Services.AddControllers();
// Disponibiliza metadados de endpoints, inclusive Minimal APIs, para documentacao.
builder.Services.AddEndpointsApiExplorer();
// Registra o gerador do documento OpenAPI.
builder.Services.AddSwaggerGen();
// Injecao de dependencia: quando pedirem IPersonService, forneca PersonServiceImplementation.
// Scoped cria uma instancia por requisicao e a compartilha durante essa requisicao.
// Os registros ficam antes de builder.Build().
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

// Monta a aplicacao com os servicos registrados.
var app = builder.Build();

// Configure the HTTP request pipeline.
// A documentacao abaixo fica disponivel apenas no ambiente Development.
if (app.Environment.IsDevelopment()) {
    // Expoe a descricao da API em /swagger/v1/swagger.json.
    app.UseSwagger();
    // Expoe a interface de testes em /swagger; use Try it out e Execute para chamar a API.
    app.UseSwaggerUI();
}

// Redireciona HTTP para HTTPS quando a porta HTTPS esta configurada.
app.UseHttpsRedirection();

// Exemplo de previsao do tempo do template, independente dos endpoints Person.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// GET /weatherforecast: exemplo de Minimal API, declarado sem controller.
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Publica as rotas dos controllers, combinando [Route] com os atributos [Http...].
app.MapControllers();

// Inicia o servidor e aguarda o encerramento da aplicacao.
app.Run();

// Modelo usado somente pelo exemplo de previsao do tempo.
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
