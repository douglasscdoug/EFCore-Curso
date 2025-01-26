﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotation_FluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Diretores",
                newName: "id_diretor");

            migrationBuilder.AddColumn<decimal>(
                name: "Orcamento",
                table: "Filmes",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "DiretorDetalhe",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DiretorDetalhe",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DiretorDetalhe",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Orcamento",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orcamento",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "DiretorDetalhe");

            migrationBuilder.RenameColumn(
                name: "id_diretor",
                table: "Diretores",
                newName: "Id");
        }
    }
}
