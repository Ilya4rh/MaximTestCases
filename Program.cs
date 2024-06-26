using MaximTestCases.RequestsLimitLogic;
using MaximTestCases.Task1;
using MaximTestCases.WordsBlackListLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.TryAddWordsBlackList();
builder.Services.TryAddRequestsLimit();

// Первое задание
// TaskSolution.Process();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();