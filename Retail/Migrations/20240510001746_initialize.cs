using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Retail.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_Product",
                        column: x => x.Product,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electrodomesticos" },
                    { 2, "Tecnologia y Electronica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoracion" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Educativo" },
                    { 10, "Jardineria y Bricolaje" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0005d8f0-a327-4696-85f6-fb192489886a"), 8, "Los Nuevos Vegetales Deshidratados de Knorr son 100% vegetales naturales deshidratados. Son muy fáciles de usar, solamente tenes que hidratarlos por 3 minutos y ya están listos para usar. Agregalos también a tus salsas, arroz y otras preparaciones que contengan agua durante la cocción.", 30, "https://ardiaprod.vtexassets.com/arquivos/ids/279550-800-auto?v=638322629936030000&width=800&height=auto&aspect=true", "Zanahoria Deshidratada Knorr 100 Gr.", 1260.00m },
                    { new Guid("05fa83f3-ee36-4437-9dbb-fc9c72e2f74c"), 4, "En ALA quisimos dar el próximo paso con el nuevo ALA líquido concentrado para diluir con Bicarbonato. La nueva fórmula del jabón líquido concentrado para diluir ALA Ecolavado con Bicarbonato tiene un poder de limpieza superior y agentes de limpieza naturales que remueven las manchas más difíciles, en el primer lavado. Este jabón para diluir combate el mal olor y es ideal para ropa blanca y de color. Además de tener una fragancia duradera. Por otro lado, su fórmula, con una tecnología patentada que se potencia en contacto con el agua y el agregado del bicarbonato que contribuye a mantener la blancura de las prendas, hace de este jabón para ropa un producto de limpieza profunda y superior. Este jabón concentrado rinde 3 L dado que su formato es para diluir. Para prepararlo, solo tenés que llenar una botella vacía de ALA 3 L con 2,5?L de agua potable, agregar el ALA líquido para diluir, mezclar 5 veces de arriba hacia abajo - ¡Y listo, ya tenés tu jabón líquido preparado con la misma consistencia y fragancia riquísima de siempre! Se dosifican 100?ml para una carga de ropa completa o 150?ml para ropa muy sucia. ALA, porque ensuciarse hace bien. Ingresá a www.ala.com.ar y conocé más de nuestros productos.", 30, "https://ardiaprod.vtexassets.com/arquivos/ids/286084-800-auto?v=638362510764470000&width=800&height=auto&aspect=true", "Jabón Líquido Concentrado para Diluir Ala con Bicarbonato 500 Ml.", 6340.00m },
                    { new Guid("1917ab7d-1b52-4e5d-ad7c-7c484646069f"), 3, "Remera reciclada", 70, "https://carrefourar.vtexassets.com/arquivos/ids/495623-800-auto?v=638476787294530000&width=800&height=auto&aspect=true", "Remera deporte reciclada Everlast", 18990.00m },
                    { new Guid("1ed07f0a-0c75-4a25-94a9-04ba70d792d3"), 1, "INFORMACIÓN IMPORTANTE: > Tenemos stock de todos nuestros productos > Envío gratis a todo el país (excepto T. del Fuego) > Plazo de entrega: - CABA y GBA: hasta 8 días hábiles - Interior: hasta 12 días hábiles > Sólo realizamos ventas a consumidor final, motivo por el que únicamente emitimos Factura “B”. -------------------------------------- Heladera Whirlpool - Retro - 76 Litros Rojo Modelo: WRA09R1 Frigobar Whirlpool Retro roja rescata el diseño elegante de los años 50 con sus patas cromadas y un logo de época. Es compacto pero tiene espacio para todo lo que precisas guardar y posee compartimentos modulares, rack para latas y congelador. - Congelador El congelador del frigobar Retro es perfecto para almacenar pequeños alimentos o botellas. - Todo en su lugar Con los compartimentos modulares es posible organizar y personalizar el interior de tu frigobar Retro, que cuenta con: rack para latas, anaquel fijo en su puerta, compartimento extra frío y un cajón multiuso. - Pies removibles Sus pies de cromo que cuidan el piso al evitar ralladuras, pueden ser removidos para utilizar la heladera en formato built in. ESPECIFICACIONES TÉCNICAS - Marca: Whirlpool - Color: Rojo - Capacidad: 76 lts - Dimensiones (cm) Alto 80,7 x Ancho 48,2 x Profundidad 51,9 - Dimensiones con embalaje (cm) Alto 86 x Ancho 51 x Profundidad 57 - Peso: 29 kg - Peso con embalaje: 30 kg - Eficiencia Energética: A - Garantía de Fábrica: 12 meses - Origen: Brasil", 45, "https://ardiaprod.vtexassets.com/arquivos/ids/170531-800-auto?v=637314847891400000&width=800&height=auto&aspect=true", "Heladera Whirlpool Retro 76 Lts Roja", 781299.00m },
                    { new Guid("21b70782-9395-4ec0-bd44-98df281ff8af"), 8, "LA SERENÍSIMA CLÁSICO, postre, chocolate. El sabor y la cremosidad con la calidad que ya conoces, un postre ideal para toda la familia. POSTRE 95gr. Postre sabor a chocolate fortificado con vitaminas A, D y ácido fólico libre de gluten. Sin TACC.", 5, "https://ardiaprod.vtexassets.com/arquivos/ids/291428-800-auto?v=638443189318800000&width=800&height=auto&aspect=true", "Postre Chocolate La Serenisima 95 Gr.", 805.00m },
                    { new Guid("25a0b5a0-aea1-4460-b032-8453087ffd9c"), 10, "El Controlador Automático de Flujo (CAF) activa la bomba al detectar circulación de agua y la apaga en el instante que deja de fluir. No mantiene las cañerías presurizadas, reduciendo la probabilidad de roturas; y no se activa ante pequeñas pérdidas. El CAF requiere una presión mínima de ingreso de 0,05 Bar o tiene que haber entre la base del tanque y grifo / ducha mas cercana 50 cm (0,50 mca). - Evita que las cañerías permanezcan presurizadas - Impide el funcionamiento en seco - No enciende la bomba con pequeñas pérdidas - Totalmente silenciosa - Requiere presión mínima de ingreso de 0.02 bar o permanecer instalado a 0,2 metros por debajo del tanque elevado - Conexiones roscadas de 1 - Montaje directo sobre bombas de hasta 1,5 Hp - Alimentación: 220 V - Frecuencia: 50 / 60 Hz - Corriente máxima: 16 A - Temperatura máxima del agua: 60º C - Presión máxima de uso: 10 bar - Conexión de entrada: 1” - Conexión de salida: 1” - Grado de protección: IP 65 - Incluye Manual - Marca: Pluvius - Modelo: CAF 396 - Garantía: 6 meses", 30, "https://carrefourar.vtexassets.com/arquivos/ids/390844-800-auto?v=638321327057730000&width=800&height=auto&aspect=true", "Controlador automático de presion presurizador Pluvius CAF", 56350.00m },
                    { new Guid("2600e46f-16e1-4f9f-8337-a3f627363ca7"), 2, "Notebook", 55, "https://carrefourar.vtexassets.com/arquivos/ids/395378-1600-auto?v=638327142469700000&width=1600&height=auto&aspect=true", "Notebook Noblex 14 HD CEL N4020C / 4GB/ 128GB SSD", 563019.00m },
                    { new Guid("28591953-06ed-4db9-93a8-07eaa6400a3a"), 4, "Una lunchera", 5, "https://ardiaprod.vtexassets.com/arquivos/ids/271057-800-auto?v=638322514887730000&width=800&height=auto&aspect=true", "Lunchera Escolar Atom 1 Un.", 15000.00m },
                    { new Guid("2c521de1-09cb-4d0e-91ca-2816adc58580"), 7, "Pistola de dardos de espuma", 15, "https://carrefourar.vtexassets.com/arquivos/ids/492271-800-auto?v=638461087104970000&width=800&height=auto&aspect=true", "Set pistolas Nerf lanza dardos elite 2.0", 39990.00m },
                    { new Guid("35c56cb7-ef18-49b8-9d49-97223f5ceb70"), 8, "Las Papas fritas Lays Clásicas están hechas con solo 3 ingredientes: papa, aceite y sal. Están sazonadas a la perfección. Tienen una textura crujiente y poseen un sabor único. Lays®, las papas fritas preferidas de los argentinos, estarán presente en cada reunión y en cada encuentro con amigos con exquisitos sabores. Disfruta de este snack salado y acaba con tu antojo.", 20, "https://ardiaprod.vtexassets.com/arquivos/ids/290152-800-auto?v=638428254526570000&width=800&height=auto&aspect=true", "Papas Fritas Lays Clásicas X 134 Gr.", 3465.00m },
                    { new Guid("3bd72f42-727a-4a3b-b813-86ead171c342"), 3, "Buzo frisa", 25, "https://carrefourar.vtexassets.com/arquivos/ids/492835-800-auto?v=638464821124700000&width=800&height=auto&aspect=true", "Buzo frisa Tex Basic", 19990.00m },
                    { new Guid("40ab51de-2888-4b68-a005-cf12e746fd3d"), 5, "Los Apósitos adhesivos Curitas Tela elástica son ideales para cubrir todo tipo de heridas pequeñas. Las vendas se estiran y se adaptan a los diferentes movimientos de la piel. Además, poseen una almohadilla antiadherente que protege la herida y la deja respirar. Cabe destacar que las Curitas están disponibles en distintos tamaños para poder cubrir completamente la lesión y/o en paños para poder cortarse a la medida necesaria. Se adecúan a todo tipo de piel.", 30, "https://carrefourar.vtexassets.com/arquivos/ids/240325-800-auto?v=637847884090900000&width=800&height=auto&aspect=true", "Apósitos adhesivos Curitas tela elástica para todo tipo de piel x 20 uni", 1120.00m },
                    { new Guid("424cf939-7e93-48fe-8d05-074a603abf55"), 5, "Crema corporal", 15, "https://carrefourar.vtexassets.com/arquivos/ids/318455-800-auto?v=638180448741070000&width=800&height=auto&aspect=true", "Crema corporal hidratante Nivea milk nutritiva 5 en 1 para piel extra seca x 250 ml.", 3865.00m },
                    { new Guid("42a4ec94-0664-4408-8e65-68b50a451d5b"), 10, "- Círculo parcial o completo - Producto: Aspersor - Color: Negro (con boquillas de bronce) - Conexión: 3/4 - Tipo de rosca: Macho - Presión: 2 - 4 bar - Radio: 12 - 14 m. - Caudal: 1500 - 2300 litros/hora - Marca: Maison", 30, "https://carrefourar.vtexassets.com/arquivos/ids/397636-800-auto?v=638333260525730000&width=800&height=auto&aspect=true", "Aspersor de impacto 3/4'' para riego sectorizable 14 m.", 11426.00m },
                    { new Guid("4973a3d8-3afb-4788-8372-a9b8f13c4211"), 4, "Limpiador CIF EXPERT Antigrasa (450 ml) es un desengrasante líquido que con su innovadora tecnología brinda una limpieza fácil y rápida, ayudando a eliminar hasta la grasa quemada.", 25, "https://ardiaprod.vtexassets.com/arquivos/ids/285928-800-auto?v=638362508968370000&width=800&height=auto&aspect=true", "Limpiador Antigrasa Expert Cif 450 Ml.", 975.00m },
                    { new Guid("49bdab5f-bf45-498f-94bc-25645c6362b5"), 1, "Certificado de Seguridad Eléctrica: DC-E-A39-063.1 IRAM - Instituto Argentino de Normalizacion y Certificación. Microondas Empotrable con Gill Ariston", 50, "https://ardiaprod.vtexassets.com/arquivos/ids/196158-800-auto?v=637541842581470000&width=800&height=auto&aspect=true", "Microondas Empotrable con Gill Ariston", 1274999.00m },
                    { new Guid("5a7a2751-d2a7-492d-a9a3-c42c5bc1c4bb"), 4, "Lampara led", 10, "https://ardiaprod.vtexassets.com/arquivos/ids/276111-800-auto?v=638322588095230000&width=800&height=auto&aspect=true", "Lámpara Led Candela Fría 12w 1 Un.", 2245.00m },
                    { new Guid("5ae5f4eb-3b2f-4896-8ee6-e671bdac9fc8"), 1, "Dimensiones producto 62 x 110 x 66 cm (ancho x alto x profundidad) Dimensiones con embalaje 67 x 114 x 71 cm (ancho x alto x profundidad) Capacidad bruta 11KG Color Blanco Tipo (abertura de puerta) Superior con sistema soft close en bisgras. Puerta Vidrio templado Niveles de agua 5 (4 + sensado automático) Ciclos Anti-pelusas Antialérgico Remoción de manchas Pro Ropa de mascotas Diario Blanca Color Delicado Jeans Edredón Limpieza de tambor Sanitizar (ropa) Lavado Express Ciclos manuales: Remojar Lavar Enjuagar Desagotar y Centrifugar Filtro Sí Sexto Sentido No. Incluye otras funciones inteligentes. Otras funciones inteligentes Sí: Sensado automático Origen Argentina Sistema de lavado Impeller. Eje vertical, carga superior. Revoluciones por minuto 700 RPM Peso 41.6 KG (neto) Eficiencia Energética / Clase Climática A Pies Niveladores Sí Ruedas No Display Sí Control de temperatura Sí, 3 Alarma de puerta No Traba de seguridad Sí Antiarrugas Sí Tambor Acero inoxidable Garantía 12 meses Consumo de agua 195 Litros Media carga No. Incluye niveles de agua en el panel para seleccionar manualmente. Eficacia de Lavado A Eficacia del Centrifugado C Bomba de desagote Sí Lavado a Mano Incluye ciclo de lavado delicado Entrada Doble de agua Sí Exclusión de Centrifugado Incluye opción antiarrugas Agua fría / caliente Sí Tipo Doble entrada País de destino ARGENTINA Otras Características Incluye: Tecnología de detección automática del tamaño de la carga (sensado automático) Inicio diferido Bloqueo del panel Inluye filtro y lifters 10 años de garantía limitada en el motor* 5 años de garantía limitada en la tarjeta de interfaz", 25, "https://ardiaprod.vtexassets.com/arquivos/ids/230336-800-auto?v=638018938547830000&width=800&height=auto&aspect=true", "Lavarropas carga superior 11 KG blanco", 1199999.00m },
                    { new Guid("5dd29c53-6e36-46cc-a9e4-b60263a62672"), 7, "Peluche", 30, "https://carrefourar.vtexassets.com/arquivos/ids/494837-800-auto?v=638470795091900000&width=800&height=auto&aspect=true", "Peluche pato de 40 cm", 17990.00m },
                    { new Guid("60c9bf6c-dc8a-4f85-b698-203e94aca1c7"), 6, "Pesa", 15, "https://carrefourar.vtexassets.com/arquivos/ids/254508-800-auto?v=637973766158400000&width=800&height=auto&aspect=true", "Pesa grande recargable Quuz", 1990.00m },
                    { new Guid("65df4c37-7a0f-4115-b54e-2ec5cdf46bf8"), 1, "Certificado de Seguridad Eléctrica: DC-E-S23-047.19 IRAM - Instituto Argentino de Normalizacion y Certificación. INFORMACIÓN IMPORTANTE: > Tenemos stock de todos nuestros productos > Envío gratis a todo el país (excepto T. del Fuego) > Plazo de entrega: - CABA y GBA: hasta 8 días hábiles - Interior: hasta 12 días hábiles > Sólo realizamos ventas a consumidor final, motivo por el que únicamente emitimos Factura “B”. -------------------------------------- Campana Extractora 60 Cm Inox Modelo: WAI62AR Campana de pared de 60 cm con diseño moderno y sofisticado. Con salida al exterior, alta capacidad de succión y motor doble turbina que te permite un mayor ahorro de energía. - Cocina libre de olores Cuenta con 3 velocidades de aspiración que te permiten regular el nivel de potencia de acuerdo a los distintos tipos de comida que estés preparando, adaptándose fácilmente a tus necesidades. - Comodidad y visibilidad Posee 2 lámparas halógenas te brindan luminosidad sobre tu cocina y te facilitan la visibilidad para hacerte más cómodo y placentero el momento de cocinar. ESPECIFICACIONES TÉCNICAS - Marca: Whirlpool - Color: Inoxidable - Dimensiones (cm) Alto 62 x Ancho 60 x Profundidad 49 - Peso: 11kg - Capacidad: 450 m3/h - 2 Lámparas halógenas de 28 watts - 3 Velocidades de aspiración - Botonera tipo pulsante - Garantía de Fábrica: 12 meses - Origen: Industria Argentina", 30, "https://ardiaprod.vtexassets.com/arquivos/ids/170362-800-auto?v=637314837200870000&width=800&height=auto&aspect=true", "Campana Extractora Whirlpool 60 CM", 689999.00m },
                    { new Guid("6a3cc33f-f1a9-43b6-8861-3f64e7fb64c0"), 3, "Rompeviento", 30, "https://carrefourar.vtexassets.com/arquivos/ids/496975-800-auto?v=638476855667000000&width=800&height=auto&aspect=true", "Rompeviento Everlast con reflex", 44990.00m },
                    { new Guid("6ac5e62d-4fdb-4ca8-8aad-2d67e23afe73"), 4, "ÉCCOLE es un adhesivo para zapatillas de consistencia tipo gel, incoloro y fácil de usar. Adhiere rápidamente sobre los materiales más utilizados en la fabricación de zapatillas tales como cuero, telas y ciertos materiales plásticos.Se utiliza para realizar arreglos en punteras, bordes, talones, suelas y capelladas.", 25, "https://ardiaprod.vtexassets.com/arquivos/ids/277406-800-auto?v=638322603927470000&width=800&height=auto&aspect=true", "Adhesivo para Zapatillas Éccole 9 Gr.", 3860.00m },
                    { new Guid("71b5a66a-54ef-4384-9aa3-e04cb2e56973"), 4, "El nuevo jabón líquido Skip para Diluir Bio-Enzimas, tiene una nueva tecnología que garantiza la superioridad en la limpieza y cuidado de las fibras, asegurando un impacto positivo en el planeta. El nuevo Skip líquido para diluir ofrece el mismo cuidado de siempre pero de una forma más conveniente para el consumidor: - MÁS ECONÓMICO: 20% de ahorro por lavado. - MÁS PRÁCTICO: No requiere cambios en la dosificación. Es más facil de transportar y almacenar. - MÁS ECOLÓGICO: Fórmula con Activo biodegradable. Menos uso de plástico Botella hecha con plástico reciclado y 100% reciclable. Skip está en constante evolución para ofrecer la mejor tecnología en el lavado y cuidado de la ropa. Además, colores más vivos y duraderos, previene pelotitas, elimina manchas y cuida texturas. Las nuevas tecnologías de los jabones líquidos Skip nos ayudan a consumir inteligentemente, optimizando el uso de energía, disminuyendo residuos e incluso siendo más económico. Y Skip siendo líder en innovación tecnológica tiene credenciales para este lanzamiento. ¿Cómo se utiliza? 1) Coloque agua corriente hasta la marca (2,5 litros) en una botella vacía de Skip 3L 2) Coloque todo el contenido (500 ml) del Jabón líquido Skip para diluir dentro de la botella de 3 L. 3) Cierre la botella y agite hasta lograr una apariencia uniforme (aproximadamente 5 veces). Deje reposar unos minutos hasta que baje la espuma. 4) Dosifique 100?ml para una carga de ropa completa o 150 ml para ropa muy sucia. 500 ml rinde 3L (30 lavados). El lavado perfecto de tu ropa es muy simple.", 20, "https://ardiaprod.vtexassets.com/arquivos/ids/266069-800-auto?v=638322446075400000&width=800&height=auto&aspect=true", "Jabón Líquido para Diluir Skip Bio-Enzimas Tecnologia superior en limpieza y cuidado 500 Ml.", 6525.00m },
                    { new Guid("7a7ad2ff-49c1-4207-ab03-5d54458e4b70"), 2, "Cargador | Data Cable | Guia de Inicio Rapido | Eject Pin", 20, "https://carrefourar.vtexassets.com/arquivos/ids/266137-1600-auto?v=638050042967430000&width=1600&height=auto&aspect=true", "Celular libre Samsung Galaxy A04 128GB negro", 314000.00m },
                    { new Guid("8ee7ab5c-eb3f-420c-83f2-e6a9dcc3f864"), 7, "Camioneta de juguete", 15, "https://carrefourar.vtexassets.com/arquivos/ids/363556-800-auto?v=638260818267430000&width=800&height=auto&aspect=true", "Camioneta a fricción spiderman chico", 2990.00m },
                    { new Guid("904e2103-8ea3-4853-90ec-c40d6621834d"), 1, "Certificado de Seguridad Eléctrica: DC-E-A39-043.3 - IRAM - Instituto Argentino de Normalizacion y Certificación. Ariston dedica el mayor cuidado al diseño de todos sus anafes con detalles de terminacion ergonomicos y durables. El anafe mixto, cuenta con un diseño unico. Sus cuatro hornallas a gas, una con triple corona, y dos zonas de cocción radiante vitroceramica, lo hacen práctico y elegante.", 15, "https://ardiaprod.vtexassets.com/arquivos/ids/195825-800-auto?v=637541836659970000&width=800&height=auto&aspect=true", "Anafe Mixto Empotrable con diseño italiano", 850000.00m },
                    { new Guid("99a7fc25-4309-4bf7-8e56-a398f22b914e"), 5, "Panuelos", 25, "https://carrefourar.vtexassets.com/arquivos/ids/416754-800-auto?v=638355808039530000&width=800&height=auto&aspect=true", "Pañuelos descartables Elite soft touch x6 10 uni", 2000.00m },
                    { new Guid("9feb263f-1c5e-47f4-93ca-5d6b12a6cbd8"), 1, "Margarina 100 % vegetal con 30 % menos grasa. Es ideal para untar por su perfil delicado y textura aireada.", 15, "https://ardiaprod.vtexassets.com/arquivos/ids/285404-800-auto?v=638355650539730000&width=800&height=auto&aspect=true", "Margarina Dánica Soft Light en pote 200 Gr.", 1350.00m },
                    { new Guid("a2d5c629-2a3a-4d9e-8932-f55564638fdf"), 1, "Certificado de Seguridad Eléctrica: DC-E-W2-347.1 IRAM - Instituto Argentino de Normalizacion y Certificación. Heladera Whirlpool No Frost Inverter 443 litros", 30, "https://ardiaprod.vtexassets.com/arquivos/ids/196892-800-auto?v=637553146106530000&width=800&height=auto&aspect=true", "Heladera Whirlpool No Frost Inverter 443 litros", 3079999.00m },
                    { new Guid("a3c49207-b84a-46e4-abd5-f40ba3c61ea4"), 2, "Control Inalámbrico DualSense™, Almacenamiento 825GB SSD, Base, Cable HDMI®, Cable AC, Cable USB, Manuales, ASTRO’s PLAYROOM (Juego pre-instalado. La consola puede necesitar actualizarse a la última versión de software disponible. Se requiere una conexión a Internet.)", 45, "https://carrefourar.vtexassets.com/arquivos/ids/411702-1600-auto?v=638348759090700000&width=1600&height=auto&aspect=true", "Consola PS5 HW digital God Of War Bundle", 999999.00m },
                    { new Guid("a775ffc7-9f42-4650-b364-9afb7c6f74f5"), 1, "Tecnología Principal: Inverter Dimensiones del producto 84,6 x 59,5 x 64,4 cm Dimensiones con embalaje 87,7 x 67,6 x 69,8 cm Capacidad bruta 64 L / 9,5 KG Color Blanco Tipo (abertura de puerta) Frontal Puerta Vidrio/Plástico Ciclos (listar) 24 Ciclos: Rápido 45 Quita Manchas PRO Refrescar con Vapor Lana Edredón Eco EEE Enjuagar y Centrifugar Centrifugar Diario Color Blanca Rápido 15 Delicada Sanitizar Sábanas y toallas + Ciclos adicionales Filtro (sí/no) Si Sexto Sentido Si Origen Argentina Sistema de lavado Frontal Revoluciones por minuto 1400 RPM Peso 79,7 KG Pies Niveladores Si Ruedas No Display Si Control de temperatura Si Alarma de puerta Si Traba de seguridad Si Función Antiarrugas Si Tambor Acero inoxidable Garantía 12 meses + 10 años garantía especial limitada en el motor Tipo de adaptador Argentino Tipo de cable Estándard con enchufe Nivel de ruido N/A Consumo de agua 64 L Media carga Incluye sensado de carga Eficacia de Lavado A Eficacia del Centrifugado B Eficiencia Energética / Clase Climática A++ Bomba de desagote Sí Lavado a Mano Incluye ciclo de lavado delicado Exclusión de Centrifugado Si Agua fría / caliente Incluye calentador interno", 20, "https://ardiaprod.vtexassets.com/arquivos/ids/261242-800-auto?v=638313511734830000&width=800&height=auto&aspect=true", "Lavarropas Whirlpool 9,5kg - 1400rpm Blanco Inverter", 1549999.00m },
                    { new Guid("a91f5709-234d-40c5-b465-524d11814a9e"), 8, "Los Nachos Doritos son productos de copetín a base de maíz y con un intenso sabor a queso. Estos snacks crujientes son perfectos para acompañarlos con cheddar, Gr.uacamole o cualquier otro tipo de salsa que tengas a mano. Ideales para compartir en cualquier ocasión, como snacks o aperitivos en tus fiestas. Probá los Doritos como más te Gr.uste y sorprendete con su delicioso sabor.", 10, "https://ardiaprod.vtexassets.com/arquivos/ids/290257-800-auto?v=638428255891200000&width=800&height=auto&aspect=true", "Nachos Sabor A Queso Doritos X 77 Gr.", 2090.00m },
                    { new Guid("b9a96f4d-62c6-4df8-b013-c5c58f3121fc"), 9, "Descubre la magia de la Granja de Zenón con esta encantadora colección de libros para pintar en formato de bloc. Con adorables ilustraciones, juegos y actividades, estos libros invitan a los niños a sumergirse en un mundo colorido y estimulante. Ideales para fomentar la creatividad y desarrollar habilidades mientras se divierten con los entrañables personajes.", 5, "https://carrefourar.vtexassets.com/arquivos/ids/473084-800-auto?v=638429152831970000&width=800&height=auto&aspect=true", "Libro reino infantil-maxi color naranja", 4999.00m },
                    { new Guid("bd97d891-c50a-4e62-881a-5c1f7ae9652d"), 3, "Pantalon", 15, "https://carrefourar.vtexassets.com/arquivos/ids/496200-800-auto?v=638476842709700000&width=800&height=auto&aspect=true", "Pantalon trekking Tex", 54990.00m },
                    { new Guid("bddc8c69-5007-4f45-84fa-d2a1f40a889d"), 9, "Actividades para hacer jugando, edición trazos.", 10, "https://carrefourar.vtexassets.com/arquivos/ids/461153-800-auto?v=638415413922430000&width=800&height=auto&aspect=true", "Libro Jugamos Con Numeros", 1800.00m },
                    { new Guid("bed31879-cfd3-458d-9c58-810177036b76"), 8, "LA SERENÍSIMA CLÁSICO, yogur bebible, parcialmente descremado, sabor frutilla.?De la mejor leche salen los mejores yogures, disfrutá un vaso de yogur todos los días. SACHET 900g.?Yogur con probióticos endulzado parcialmente descremado fortificado con zinc y vitaminas A y D sabor frutilla libre de gluten – licuado. Sin TACC.", 25, "https://ardiaprod.vtexassets.com/arquivos/ids/287581-800-auto?v=638383484383700000&width=800&height=auto&aspect=true", "Yogur Bebible Frutilla La Serenísima Clásico 900 Gr.", 2095.00m },
                    { new Guid("c3368b7d-63ca-494c-a675-4242c8ef5324"), 6, "Tubo de pelotas", 10, "https://carrefourar.vtexassets.com/arquivos/ids/254419-800-auto?v=637973765357800000&width=800&height=auto&aspect=true", "Tubo pelotas de tenis Top life x 4", 8990.00m },
                    { new Guid("c4b70b72-9664-49b0-88c2-74689f8c6491"), 7, "Globos para agua", 10, "https://carrefourar.vtexassets.com/arquivos/ids/161262-800-auto?v=637467656311630000&width=800&height=auto&aspect=true", "Globos para agua Bombuchas x 100 uni", 749.00m },
                    { new Guid("c501710a-0bb3-4747-85ae-35da53e90f76"), 4, "El módulo de un cuerpo LE076 es un producto de la línea industrial, logrado por su acabado rústico y la combinación con lo natural de la materia prima. El diseño está compuesto por un cuerpo principal de melamina y patas de caño redondo curvado. Este mueble posee seis divisiones internas, dos cerradas con puertas y cuatro libres. Para la apertura de estas puertas nos encontramos con unos tiradores de color negro los cuales acompañan con la estetica discreta del diseño. El módulo está pensado en la multifuncionalidad, ya que puede ejercer varios usos dependiendo del ambiente en el que se lo utilice, en la cocina como despensero, en el living como contenedor, en el comedor como vajillero, en el estudio como biblioteca, en la habitación de los niños como porta juguetes, antebaño y baño como toallero y en el lavadero como organizador de elementos de limpieza o simplemente para objetos de decoración en el ambiente que más se desee. Este mueble viene desarmado y preparado para ensamblar de manera rápida y simple, por lo que dentro de la caja tenemos los correspondientes instructivos. Lo podes encontrar en las combinaciones de color atakama en su totalidad y las patas en color negras.", 60, "https://carrefourar.vtexassets.com/arquivos/ids/315618-1600-auto?v=638175094875270000&width=1600&height=auto&aspect=true", "Modulo 2 cuerpos línea industrial", 94399.00m },
                    { new Guid("ce747f98-67b0-4d61-a98e-a90ae035a5cb"), 3, "Pantalon frisa", 35, "https://carrefourar.vtexassets.com/arquivos/ids/496568-800-auto?v=638476848881900000&width=800&height=auto&aspect=true", "Pantalón frisa Everlast", 44990.00m },
                    { new Guid("d10c1000-dee6-49db-87f6-f772028282e2"), 2, "Celular libre", 30, "https://carrefourar.vtexassets.com/arquivos/ids/367471-1600-auto?v=638283212666130000&width=1600&height=auto&aspect=true", "Celular libre Motorola g23 4gb 128gb blanco", 399999.00m },
                    { new Guid("d5a09807-317d-4391-ade4-074bdfdb3fec"), 4, "Sofá cama Criqueto negro con patas frontales de plásticos. Patas de Metal negro y Espuma cubierto de PU.", 25, "https://carrefourar.vtexassets.com/arquivos/ids/164655-1600-auto?v=637467714147330000&width=1600&height=auto&aspect=true", "Sofá cama Criqueto negro", 199900.00m },
                    { new Guid("e2a9ef75-b810-4bfc-948c-24b681a86e53"), 1, "Certificado de Seguridad Eléctrica: Cocina : DC-E-M24-012.1 IRAM - Instituto Argentino de Normalizacion y Certificación / Campana : DC-E-S23-047.19 IRAM - Instituto Argentino de Normalizacion y Certificación. Combo Whirlpool Cocina y Campana", 40, "https://ardiaprod.vtexassets.com/arquivos/ids/205373-800-auto?v=637613438701100000&width=800&height=auto&aspect=true", "Combo Whirlpool Cocina y Campana", 1629998.00m },
                    { new Guid("e6a56ed5-0c75-4294-b084-b30d1ee42bf2"), 9, "Aventuras para colorear de los personajes de Pokemon.", 15, "https://carrefourar.vtexassets.com/arquivos/ids/379376-800-auto?v=638313642448730000&width=800&height=auto&aspect=true", "Libro Pokemon, aventuras para colorear", 3999.00m },
                    { new Guid("f1c633a7-de91-4f01-8dea-f7be8e3be863"), 10, "Manguera de plastico", 20, "https://carrefourar.vtexassets.com/arquivos/ids/253554-800-auto?v=637957476573730000&width=800&height=auto&aspect=true", "Manguera premiun 1/2 x 15 mts", 18699.00m },
                    { new Guid("fb4882dd-7532-41b6-989a-86270019c04b"), 6, "Colchoneta", 25, "https://carrefourar.vtexassets.com/arquivos/ids/262732-800-auto?v=638040329498330000&width=800&height=auto&aspect=true", "Colchoneta plegable Quuz 1 x 0.50 negra", 13990.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Product",
                table: "SaleProduct",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Sale",
                table: "SaleProduct",
                column: "Sale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
