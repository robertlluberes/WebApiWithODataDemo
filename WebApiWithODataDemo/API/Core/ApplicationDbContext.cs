using API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Community> Communities { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<CommunityMember> CommunityMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunityMember>()
                .HasKey(cm => new { cm.CommunityId, cm.MemberId });

            modelBuilder.Entity<CommunityMember>()
                .HasOne(cm => cm.Community)
                .WithMany(c => c.CommunityMembers)
                .HasForeignKey(cm => cm.CommunityId);

            modelBuilder.Entity<CommunityMember>()
                .HasOne(cm => cm.Member)
                .WithMany(m => m.CommunityMembers)
                .HasForeignKey(cm => cm.MemberId);

            #region Data Seed

            modelBuilder.Entity<Community>().HasData(
               new Community() { CommunityId = 1, Name = "La Comarca", Description = "Somos una comunidad amante de la creatividad y la tecnología en sus diferentes fases que busca fomentar, inspirar y motivar el desarrollo personal y profesional de personas interesadas. Sin importar la tecnología o el sector, siempre estamos unidos. La Comarca reúne la creatividad de diferentes sectores e industrias en un mismo entorno, con la visión de ayudar a crecer profesionalmente a nuevos líderes de la innovación." },
               new Community() { CommunityId = 2, Name = "Mujeres TICs RD", Description = "Somos una comunidad de mujeres apasionadas por la tecnología, profesionales en distintas áreas de las TIC que buscan inspirar, motivar, involucrar y educar a más chicas en el área, a través de acciones de capacitación y coaching para niñas y mujeres interesadas." },
               new Community() { CommunityId = 3, Name = ".NET Dominicana", Description = ".NET Dominicana es una comunidad abierta a todos los desarrolladores en el país interesados en aprender y expandir sus conocimientos sobre las tecnologías Microsoft .NET y todo lo que tiene para ofrecer, todos los meses realizamos eventos elegidos por la comunidad. \n El objetivo es hacer nuevos amigos, aprender algo nuevo cada mes de los miembros de nuestra comunidad y compartir esto con nuestro entorno tecnológico." },
               new Community() { CommunityId = 4, Name = "Aprendiendo BD con SQL Server", Description = "Somos un grupo amante de las tecnologías propias del área de datos, desde la administración hasta analítica avanzada." },
               new Community() { CommunityId = 5, Name = "Linux Dominicana", Description = "Un lugar donde tratar temas relacionados al Open Source, Software Libre y distribuciones GNU/Linux." },
               new Community() { CommunityId = 6, Name = "UI / UX Dominicana", Description = "Usergroup de Experiencia de Usuario y Diseño de Interfaces de República Dominicana." },
               new Community() { CommunityId = 7, Name = "Developers Dominicanos", Description = "Esta es una comunidad de desarrolladores dominicanos, para conocer quiénes somos, en qué estamos, y de paso compartir temas, ayudarnos unos a otros a solucionar problemas que no encontremos en MSDN o StackOverflow, como por ejemplo problemas relevantes al desarrollo local, y publicar ofertas de trabajo." },
               new Community() { CommunityId = 8, Name = "GDG Santo Domingo", Description = "Google Developer Groups Santo Domingo" },
               new Community() { CommunityId = 9, Name = "Agile Dominicana", Description = "Somos un grupo de apasionados que deseamos compartir y promover los conocimientos de metodologias agiles para el beneficio de la comunidad." },
               new Community() { CommunityId = 10, Name = "fria.js", Description = "Vamos a beber cerveza y tal vez hablar de JavaScript." },
               new Community() { CommunityId = 11, Name = "TECHNOLOGY INNOVATION SUMMIT", Description = "Es un evento de tecnología donde los participantes aprenden acerca de los temas tecnológicos de vanguardia, y donde pueden conocer otras personas que compartan sus intereses." },
               new Community() { CommunityId = 12, Name = "Caribbean Developers Conference", Description = "CDC reune a profesionales de software y emprendedores de diferentes idiomas, plataformas e industrias. \n Los participantes tienen la oportunidad de compartir, participar y aprender sobre temas de tendencias que están configurando el futuro de las TI y las empresas, hoy." },
               new Community() { CommunityId = 13, Name = "CodeCampSDQ", Description = "CodeCampSDQ es una conferencia técnica con el objetivo primordial de educar a la comunidad de profesionales de TI en el Caribe en temas como: Desarrollo móvil y Web, Cloud Computing, DevOps, servicios cognitivos, entre otros." },
               new Community() { CommunityId = 14, Name = "Hackers and Founders", Description = "Formado por emprendedores, H / F da cabida a programadores, desarrolladores de tecnología, emprendedores y todos aquellos amantes de las tecnologías que buscan emprender un proyecto y no saben por dónde empezar.Todo se trata del “networking” ¿Quiénes ampliar tu red de contactos ? entonces “Hackers & Founders” es donde debes estar." },
               new Community() { CommunityId = 15, Name = "Open Saturday Conference", Description = "Surge como una iniciativa a compartir conocimientos sobre herramientas FOSS entre jóvenes profesionales, con el fin de aumentar la calidad de los servicios técnicos." },
               new Community() { CommunityId = 16, Name = "Mujeres Cambiando el Mundo", Description = "“Mujeres Cambiando el Mundo - MCM”, o su versión en inglés “Women Changing the World - WCW”, con el lema: Por más chicas en Ciencia y Tecnología!. Busca a través de una serie de charlas y paneles, poder ayudar a las chicas a que vean la carrera de tecnología como una oportunidad, de que ellas tienen espacio y que pueden desarrollarse y llegar tan lejos como se lo propongan." },
               new Community() { CommunityId = 17, Name = "Oddo Dominicana", Description = "Odoo Dominicana es una comunidad, que reúne personas de diferentes disciplinas de negocios, con la finalidad de compartir el conocimiento en el desarrollo de soluciones tecnológicas que faciliten los procesos en las empresas." },
               new Community() { CommunityId = 18, Name = "Python Dominicana", Description = "Python Interest Group in the Dominican Republic If you want to enjoy discounts on o'reilly just use the 50% Discount with the ebooks and 40% with the printed media using the code PCBW on your purchases at http://shop.oreilly.com/" },
               new Community() { CommunityId = 19, Name = "OWASP RD", Description = "Capitulo de Owasp Republica Dominicana " }
               );

            modelBuilder.Entity<Technology>().HasData(
                new Technology() { TechnologyId = 1, Name = "Microsoft" },
                new Technology() { TechnologyId = 2, Name = "Linux" },
                new Technology() { TechnologyId = 3, Name = "Kotlin" },
                new Technology() { TechnologyId = 4, Name = "Python" },
                new Technology() { TechnologyId = 5, Name = "Javascript" },
                new Technology() { TechnologyId = 6, Name = "Sketch" },
                new Technology() { TechnologyId = 7, Name = "Docker" },
                new Technology() { TechnologyId = 8, Name = "Xamarin" }
                );

            modelBuilder.Entity<Member>().HasData(
                new Member() { MemberId = 1, Name = "Andres Pineda", Salary = 200000, TechnologyId = 1 },
                new Member() { MemberId = 2, Name = "Claudio Sanchez", Salary = 188300, TechnologyId = 1 },
                new Member() { MemberId = 3, Name = "Victor Recio", Salary = 180000, TechnologyId = 2 },
                new Member() { MemberId = 4, Name = "Stanley Lara", Salary = 163500, TechnologyId = 1 },
                new Member() { MemberId = 5, Name = "Shailyn Ortíz", Salary = 151000, TechnologyId = 4 },
                new Member() { MemberId = 6, Name = "Yulissa Mateo", Salary = 150000, TechnologyId = 1 },
                new Member() { MemberId = 7, Name = "Ángel García", Salary = 140000, TechnologyId = 1 },
                new Member() { MemberId = 8, Name = "Luis Matos", Salary = 131900, TechnologyId = 8 },
                new Member() { MemberId = 9, Name = "Charlin Agramonte", Salary = 145000, TechnologyId = 8 },
                new Member() { MemberId = 10, Name = "Jearel Alcántara", Salary = 120000, TechnologyId = 2 },
                new Member() { MemberId = 11, Name = "Leomaris Reyes", Salary = 120000, TechnologyId = 8 },
                new Member() { MemberId = 12, Name = "Yhorby Matías", Salary = 130200, TechnologyId = 1 },
                new Member() { MemberId = 13, Name = "Emmanuel Toribio", Salary = 150000, TechnologyId = 1 },
                new Member() { MemberId = 14, Name = "Kenny Beltre", Salary = 120000, TechnologyId = 6 },
                new Member() { MemberId = 15, Name = "Saira Isaac Hermandez", Salary = 145000, TechnologyId = 2 },
                new Member() { MemberId = 16, Name = "Adonis Mendoza", Salary = 110000, TechnologyId = 5 }
                );

            modelBuilder.Entity<CommunityMember>().HasData(
                new CommunityMember() { CommunityId = 12, MemberId = 1 },
                new CommunityMember() { CommunityId = 13, MemberId = 1 },
                new CommunityMember() { CommunityId = 14, MemberId = 1 },
                new CommunityMember() { CommunityId = 18, MemberId = 1 },
                new CommunityMember() { CommunityId = 12, MemberId = 2 },
                new CommunityMember() { CommunityId = 13, MemberId = 2 },
                new CommunityMember() { CommunityId = 14, MemberId = 2 },
                new CommunityMember() { CommunityId = 5, MemberId = 3 },
                new CommunityMember() { CommunityId = 14, MemberId = 3 },
                new CommunityMember() { CommunityId = 15, MemberId = 3 },
                new CommunityMember() { CommunityId = 1, MemberId = 4 },
                new CommunityMember() { CommunityId = 2, MemberId = 4 },
                new CommunityMember() { CommunityId = 4, MemberId = 4 },
                new CommunityMember() { CommunityId = 11, MemberId = 4 },
                new CommunityMember() { CommunityId = 14, MemberId = 4 },
                new CommunityMember() { CommunityId = 5, MemberId = 5 },
                new CommunityMember() { CommunityId = 11, MemberId = 5 },
                new CommunityMember() { CommunityId = 1, MemberId = 5 },
                new CommunityMember() { CommunityId = 18, MemberId = 5 },
                new CommunityMember() { CommunityId = 1, MemberId = 6 },
                new CommunityMember() { CommunityId = 2, MemberId = 6 },
                new CommunityMember() { CommunityId = 12, MemberId = 6 },
                new CommunityMember() { CommunityId = 13, MemberId = 6 },
                new CommunityMember() { CommunityId = 14, MemberId = 6 },
                new CommunityMember() { CommunityId = 15, MemberId = 6 },
                new CommunityMember() { CommunityId = 16, MemberId = 6 },
                new CommunityMember() { CommunityId = 1, MemberId = 7 },
                new CommunityMember() { CommunityId = 2, MemberId = 7 },
                new CommunityMember() { CommunityId = 3, MemberId = 7 },
                new CommunityMember() { CommunityId = 11, MemberId = 7 },
                new CommunityMember() { CommunityId = 12, MemberId = 7 },
                new CommunityMember() { CommunityId = 13, MemberId = 7 },
                new CommunityMember() { CommunityId = 1, MemberId = 8 },
                new CommunityMember() { CommunityId = 2, MemberId = 8 },
                new CommunityMember() { CommunityId = 3, MemberId = 8 },
                new CommunityMember() { CommunityId = 4, MemberId = 8 },
                new CommunityMember() { CommunityId = 12, MemberId = 8 },
                new CommunityMember() { CommunityId = 13, MemberId = 8 },
                new CommunityMember() { CommunityId = 14, MemberId = 8 },
                new CommunityMember() { CommunityId = 2, MemberId = 9 },
                new CommunityMember() { CommunityId = 3, MemberId = 9 },
                new CommunityMember() { CommunityId = 4, MemberId = 9 },
                new CommunityMember() { CommunityId = 12, MemberId = 9 },
                new CommunityMember() { CommunityId = 13, MemberId = 9 },
                new CommunityMember() { CommunityId = 14, MemberId = 9 },
                new CommunityMember() { CommunityId = 1, MemberId = 10 },
                new CommunityMember() { CommunityId = 18, MemberId = 10 },
                new CommunityMember() { CommunityId = 5, MemberId = 10 },
                new CommunityMember() { CommunityId = 2, MemberId = 11 },
                new CommunityMember() { CommunityId = 3, MemberId = 11 },
                new CommunityMember() { CommunityId = 12, MemberId = 11 },
                new CommunityMember() { CommunityId = 16, MemberId = 11 },
                new CommunityMember() { CommunityId = 3, MemberId = 12 },
                new CommunityMember() { CommunityId = 5, MemberId = 12 },
                new CommunityMember() { CommunityId = 11, MemberId = 12 },
                new CommunityMember() { CommunityId = 12, MemberId = 12 },
                new CommunityMember() { CommunityId = 13, MemberId = 12 },
                new CommunityMember() { CommunityId = 1, MemberId = 13 },
                new CommunityMember() { CommunityId = 2, MemberId = 13 },
                new CommunityMember() { CommunityId = 3, MemberId = 13 },
                new CommunityMember() { CommunityId = 11, MemberId = 13 },
                new CommunityMember() { CommunityId = 12, MemberId = 13 },
                new CommunityMember() { CommunityId = 13, MemberId = 13 },
                new CommunityMember() { CommunityId = 1, MemberId = 14 },
                new CommunityMember() { CommunityId = 2, MemberId = 14 },
                new CommunityMember() { CommunityId = 6, MemberId = 14 },
                new CommunityMember() { CommunityId = 12, MemberId = 14 },
                new CommunityMember() { CommunityId = 13, MemberId = 14 },
                new CommunityMember() { CommunityId = 14, MemberId = 14 },
                new CommunityMember() { CommunityId = 15, MemberId = 14 },
                new CommunityMember() { CommunityId = 16, MemberId = 14 },
                new CommunityMember() { CommunityId = 1, MemberId = 15 },
                new CommunityMember() { CommunityId = 2, MemberId = 15 },
                new CommunityMember() { CommunityId = 12, MemberId = 15 },
                new CommunityMember() { CommunityId = 13, MemberId = 15 },
                new CommunityMember() { CommunityId = 14, MemberId = 15 },
                new CommunityMember() { CommunityId = 15, MemberId = 15 },
                new CommunityMember() { CommunityId = 16, MemberId = 15 },
                new CommunityMember() { CommunityId = 19, MemberId = 15 },
                new CommunityMember() { CommunityId = 1, MemberId = 16 },
                new CommunityMember() { CommunityId = 2, MemberId = 16 },
                new CommunityMember() { CommunityId = 3, MemberId = 16 },
                new CommunityMember() { CommunityId = 4, MemberId = 16 },
                new CommunityMember() { CommunityId = 10, MemberId = 16 }
                );

            #endregion Data Seed
        }
    }
}