using Cursos.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Infra.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ProfessorCurso> ProfessorCursos { get; set; }
        public object Include { get; internal set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>().HasOne(t => t.Turma).WithMany(a => a.Alunos).HasForeignKey(t => t.IdTurma);
            builder.Entity<Nota>().HasOne(a => a.Aluno).WithMany(n => n.Notas).HasForeignKey(a => a.AlunoId);
            builder.Entity<Curso>().HasMany(t => t.Turmas).WithOne(c => c.Curso).HasForeignKey(c => c.CursoId);
            builder.Entity<Curso>().HasMany(p => p.Professores).WithOne(c => c.Curso).HasForeignKey(c => c.IdCurso);
            builder.Entity<Professor>().HasMany(p => p.Cursos).WithOne(c => c.Professor).HasForeignKey(c => c.IdProfessor);
            builder.Entity<ProfessorCurso>().HasKey(x => new { x.IdCurso, x.IdProfessor });

            base.OnModelCreating(builder);
        }
    }
}
