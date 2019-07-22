using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    CommunityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityMembers",
                columns: table => new
                {
                    CommunityId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityMembers", x => new { x.CommunityId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_CommunityMembers_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "CommunityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Somos una comunidad amante de la creatividad y la tecnología en sus diferentes fases que busca fomentar, inspirar y motivar el desarrollo personal y profesional de personas interesadas. Sin importar la tecnología o el sector, siempre estamos unidos. La Comarca reúne la creatividad de diferentes sectores e industrias en un mismo entorno, con la visión de ayudar a crecer profesionalmente a nuevos líderes de la innovación.", "La Comarca" },
                    { 19, "Capitulo de Owasp Republica Dominicana ", "OWASP RD" },
                    { 18, "Python Interest Group in the Dominican Republic If you want to enjoy discounts on o'reilly just use the 50% Discount with the ebooks and 40% with the printed media using the code PCBW on your purchases at http://shop.oreilly.com/", "Python Dominicana" },
                    { 17, "Odoo Dominicana es una comunidad, que reúne personas de diferentes disciplinas de negocios, con la finalidad de compartir el conocimiento en el desarrollo de soluciones tecnológicas que faciliten los procesos en las empresas.", "Oddo Dominicana" },
                    { 16, "“Mujeres Cambiando el Mundo - MCM”, o su versión en inglés “Women Changing the World - WCW”, con el lema: Por más chicas en Ciencia y Tecnología!. Busca a través de una serie de charlas y paneles, poder ayudar a las chicas a que vean la carrera de tecnología como una oportunidad, de que ellas tienen espacio y que pueden desarrollarse y llegar tan lejos como se lo propongan.", "Mujeres Cambiando el Mundo" },
                    { 15, "Surge como una iniciativa a compartir conocimientos sobre herramientas FOSS entre jóvenes profesionales, con el fin de aumentar la calidad de los servicios técnicos.", "Open Saturday Conference" },
                    { 13, "CodeCampSDQ es una conferencia técnica con el objetivo primordial de educar a la comunidad de profesionales de TI en el Caribe en temas como: Desarrollo móvil y Web, Cloud Computing, DevOps, servicios cognitivos, entre otros.", "CodeCampSDQ" },
                    { 12, @"CDC reune a profesionales de software y emprendedores de diferentes idiomas, plataformas e industrias. 
                 Los participantes tienen la oportunidad de compartir, participar y aprender sobre temas de tendencias que están configurando el futuro de las TI y las empresas, hoy.", "Caribbean Developers Conference" },
                    { 11, "Es un evento de tecnología donde los participantes aprenden acerca de los temas tecnológicos de vanguardia, y donde pueden conocer otras personas que compartan sus intereses.", "TECHNOLOGY INNOVATION SUMMIT" },
                    { 14, "Formado por emprendedores, H / F da cabida a programadores, desarrolladores de tecnología, emprendedores y todos aquellos amantes de las tecnologías que buscan emprender un proyecto y no saben por dónde empezar.Todo se trata del “networking” ¿Quiénes ampliar tu red de contactos ? entonces “Hackers & Founders” es donde debes estar.", "Hackers and Founders" },
                    { 9, "Somos un grupo de apasionados que deseamos compartir y promover los conocimientos de metodologias agiles para el beneficio de la comunidad.", "Agile Dominicana" },
                    { 10, "Vamos a beber cerveza y tal vez hablar de JavaScript.", "fria.js" },
                    { 3, @".NET Dominicana es una comunidad abierta a todos los desarrolladores en el país interesados en aprender y expandir sus conocimientos sobre las tecnologías Microsoft .NET y todo lo que tiene para ofrecer, todos los meses realizamos eventos elegidos por la comunidad. 
                 El objetivo es hacer nuevos amigos, aprender algo nuevo cada mes de los miembros de nuestra comunidad y compartir esto con nuestro entorno tecnológico.", ".NET Dominicana" },
                    { 4, "Somos un grupo amante de las tecnologías propias del área de datos, desde la administración hasta analítica avanzada.", "Aprendiendo BD con SQL Server" },
                    { 5, "Un lugar donde tratar temas relacionados al Open Source, Software Libre y distribuciones GNU/Linux.", "Linux Dominicana" },
                    { 2, "Somos una comunidad de mujeres apasionadas por la tecnología, profesionales en distintas áreas de las TIC que buscan inspirar, motivar, involucrar y educar a más chicas en el área, a través de acciones de capacitación y coaching para niñas y mujeres interesadas.", "Mujeres TICs RD" },
                    { 7, "Esta es una comunidad de desarrolladores dominicanos, para conocer quiénes somos, en qué estamos, y de paso compartir temas, ayudarnos unos a otros a solucionar problemas que no encontremos en MSDN o StackOverflow, como por ejemplo problemas relevantes al desarrollo local, y publicar ofertas de trabajo.", "Developers Dominicanos" },
                    { 8, "Google Developer Groups Santo Domingo", "GDG Santo Domingo" },
                    { 6, "Usergroup de Experiencia de Usuario y Diseño de Interfaces de República Dominicana.", "UI / UX Dominicana" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Name" },
                values: new object[,]
                {
                    { 7, "Docker" },
                    { 1, "Microsoft" },
                    { 2, "Linux" },
                    { 3, "Kotlin" },
                    { 4, "Python" },
                    { 5, "Javascript" },
                    { 6, "Sketch" },
                    { 8, "Xamarin" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name", "Salary", "TechnologyId" },
                values: new object[,]
                {
                    { 1, "Andres Pineda", 200000.0, 1 },
                    { 2, "Claudio Sanchez", 188300.0, 1 },
                    { 4, "Stanley Lara", 163500.0, 1 },
                    { 6, "Yulissa Mateo", 150000.0, 1 },
                    { 7, "Ángel García", 140000.0, 1 },
                    { 12, "Yhorby Matías", 130200.0, 1 },
                    { 13, "Emmanuel Toribio", 150000.0, 1 },
                    { 3, "Victor Recio", 180000.0, 2 },
                    { 10, "Jearel Alcántara", 120000.0, 2 },
                    { 15, "Saira Isaac Hermandez", 145000.0, 2 },
                    { 5, "Shailyn Ortíz", 151000.0, 4 },
                    { 16, "Adonis Mendoza", 110000.0, 5 },
                    { 14, "Kenny Beltre", 120000.0, 6 },
                    { 8, "Luis Matos", 131900.0, 8 },
                    { 9, "Charlin Agramonte", 145000.0, 8 },
                    { 11, "Leomaris Reyes", 120000.0, 8 }
                });

            migrationBuilder.InsertData(
                table: "CommunityMembers",
                columns: new[] { "CommunityId", "MemberId" },
                values: new object[,]
                {
                    { 12, 1 },
                    { 2, 14 },
                    { 1, 14 },
                    { 10, 16 },
                    { 4, 16 },
                    { 3, 16 },
                    { 2, 16 },
                    { 1, 16 },
                    { 18, 5 },
                    { 1, 5 },
                    { 11, 5 },
                    { 5, 5 },
                    { 19, 15 },
                    { 16, 15 },
                    { 15, 15 },
                    { 14, 15 },
                    { 13, 15 },
                    { 12, 15 },
                    { 6, 14 },
                    { 2, 15 },
                    { 12, 14 },
                    { 14, 14 },
                    { 3, 11 },
                    { 2, 11 },
                    { 14, 9 },
                    { 13, 9 },
                    { 12, 9 },
                    { 4, 9 },
                    { 3, 9 },
                    { 2, 9 },
                    { 14, 8 },
                    { 13, 8 },
                    { 12, 8 },
                    { 4, 8 },
                    { 3, 8 },
                    { 2, 8 },
                    { 1, 8 },
                    { 16, 14 },
                    { 15, 14 },
                    { 13, 14 },
                    { 1, 15 },
                    { 5, 10 },
                    { 18, 10 },
                    { 15, 6 },
                    { 14, 6 },
                    { 13, 6 },
                    { 12, 6 },
                    { 2, 6 },
                    { 1, 6 },
                    { 14, 4 },
                    { 11, 4 },
                    { 4, 4 },
                    { 2, 4 },
                    { 1, 4 },
                    { 14, 2 },
                    { 13, 2 },
                    { 12, 2 },
                    { 18, 1 },
                    { 14, 1 },
                    { 13, 1 },
                    { 16, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 },
                    { 1, 10 },
                    { 15, 3 },
                    { 14, 3 },
                    { 5, 3 },
                    { 13, 13 },
                    { 12, 13 },
                    { 11, 13 },
                    { 3, 13 },
                    { 12, 11 },
                    { 2, 13 },
                    { 13, 12 },
                    { 12, 12 },
                    { 11, 12 },
                    { 5, 12 },
                    { 3, 12 },
                    { 13, 7 },
                    { 12, 7 },
                    { 11, 7 },
                    { 1, 13 },
                    { 16, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMembers_MemberId",
                table: "CommunityMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TechnologyId",
                table: "Members",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityMembers");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
