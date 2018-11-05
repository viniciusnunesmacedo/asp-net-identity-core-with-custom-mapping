using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Table: IdentityUser => Usuario
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.UserName).HasColumnName("NomeUsuario");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.NormalizedUserName).HasColumnName("NomeUsuarioNormalizado");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.Email).HasColumnName("Email");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.NormalizedEmail).HasColumnName("EmailNormalizado");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.EmailConfirmed).HasColumnName("EmailConfirmado");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.PasswordHash).HasColumnName("Senha");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.SecurityStamp).HasColumnName("ChaveSenha");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.ConcurrencyStamp).HasColumnName("ChaveAlteracao");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.PhoneNumber).HasColumnName("Telefone");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.PhoneNumberConfirmed).HasColumnName("TelefoneConfirmado");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.TwoFactorEnabled).HasColumnName("DoisFatoresAtivado");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.LockoutEnd).HasColumnName("Saida");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.LockoutEnabled).HasColumnName("PodeSair");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.AccessFailedCount).HasColumnName("QuantidadeFalhas");

            //Table: IdentityUserToken => UsuarioProvedor
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuarioProvedor").Property(p => p.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuarioProvedor").Property(p => p.LoginProvider).HasColumnName("LoginProvedor");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuarioProvedor").Property(p => p.Name).HasColumnName("Nome");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuarioProvedor").Property(p => p.Value).HasColumnName("Valor");

            //Table: IdentityUserRole => UsuarioPerfil
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfil").Property(p => p.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfil").Property(p => p.RoleId).HasColumnName("PerfilId");

            //Table: IdentityUserLogin => UsuarioProvedorLogin
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioProvedorLogin").Property(p => p.LoginProvider).HasColumnName("LoginProvedor");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioProvedorLogin").Property(p => p.ProviderKey).HasColumnName("ChaveProvedor");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioProvedorLogin").Property(p => p.ProviderDisplayName).HasColumnName("NomeProvedor");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioProvedorLogin").Property(p => p.UserId).HasColumnName("UsuarioId");

            //Table: IdentityUserClaims => UsuarioAtributo
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioAtributo").Property(p => p.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioAtributo").Property(p => p.ClaimType).HasColumnName("TipoAtributo");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioAtributo").Property(p => p.ClaimValue).HasColumnName("ValorAtributo");

            //Table: IdentityRole => Perfil
            modelBuilder.Entity<IdentityRole>().ToTable("Perfil").Property(p => p.Name).HasColumnName("Nome");
            modelBuilder.Entity<IdentityRole>().ToTable("Perfil").Property(p => p.NormalizedName).HasColumnName("NomeNormalizado");
            modelBuilder.Entity<IdentityRole>().ToTable("Perfil").Property(p => p.ConcurrencyStamp).HasColumnName("ChaveAlteracao");

            //Table: IdentityRoleClaim => PerfilAtributo
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilAtributo").Property(p => p.RoleId).HasColumnName("PerfilId");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilAtributo").Property(p => p.ClaimType).HasColumnName("TipoAtributo");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilAtributo").Property(p => p.ClaimValue).HasColumnName("ValorAtributo");
        }

    }
}
