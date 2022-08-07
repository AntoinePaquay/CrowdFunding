using CrowdFunding.BLL.Interfaces;
using CrowdFunding.BLL.Services;
using CrowdFunding.DAL.Interfaces;
using CrowdFunding.DAL.Context;
using CrowdFunding.DAL.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<IPrivateMessageService, PrivateMessageService>();
builder.Services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddDbContextFactory<CrowdfundingContext>(options => options.UseSql)

builder.Services.AddScoped<IDbConnection>(sp =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
