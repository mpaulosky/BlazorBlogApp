﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorBlog.Server.Migrations
{
    /// <inheritdoc />
    public partial class Attempt_To_Seed_Blog_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Content", "Created", "Description", "ImageFileName", "IsDeleted", "IsPublished", "Title", "Updated", "Url" },
                values: new object[,]
                {
                    { 1, "Carroll Herman", "Facilis corporis laboriosam ut molestiae alias ut quo id. Voluptatum laboriosam reprehenderit quaerat. Eveniet et dicta quo sed fugit. Quo fugit dolor perferendis ut quidem quo eaque voluptates hic. Ea voluptatem sit.\n\nEst provident aut dignissimos velit ullam ipsam autem facere nostrum. Non illo atque. Quos facere qui deserunt modi. Velit laudantium sit. Cumque nostrum non.\n\nUt laudantium ea. Commodi sit sit tempore porro velit quibusdam. Voluptatem dolore fuga voluptates maiores nihil. Iste est exercitationem molestiae ipsam voluptas enim quasi.\n\nEt aut temporibus vitae quisquam illo. Similique molestias quia quia rem vitae perferendis. Molestiae porro voluptatem numquam. Sunt porro et aut id nihil earum aperiam. Omnis ab fugit. Tempora numquam in consequatur voluptatem.\n\nArchitecto nisi voluptatum corporis. Vitae non minima magnam necessitatibus quae neque. Veritatis aliquid repellendus ratione voluptates ut exercitationem aut sint. Minus architecto consequatur modi at quibusdam omnis. In id sit quidem placeat et.\n\nEt eveniet distinctio repellendus nesciunt. Rerum quaerat consectetur debitis et aliquam aspernatur aut. Vitae iste qui quod incidunt. Eos cum deleniti rem totam est natus. Molestiae id perspiciatis qui iste optio in ducimus minus.\n\nAmet placeat aperiam. Consequatur cupiditate quia molestiae ex recusandae beatae non et sit. Temporibus modi dolor enim est vitae voluptas nihil voluptas. Necessitatibus tempore ut ad at.\n\nBlanditiis quod ipsa assumenda eum cumque fugit hic ratione. Quia ut ut tempore. Magnam porro et. Ut quam cum et. Voluptas ut nihil voluptatum pariatur dolor voluptatem et ullam.\n\nPossimus nostrum quasi sapiente cupiditate et. Ut eos sed occaecati esse. Nulla quam dolorem quis cum commodi voluptate. Qui dolor odio natus repellat quidem aspernatur consequatur quasi.\n\nExplicabo velit quis a est rerum et. Illo dolores inventore maxime. At aut harum molestiae a dolor dolorem recusandae nulla. Itaque fugit et in cupiditate molestiae voluptatem ipsum. Esse sint quia ea natus laudantium quia nihil voluptatem.", new DateTime(2022, 11, 9, 23, 23, 6, 208, DateTimeKind.Local).AddTicks(7958), "Labore et consectetur qui. Numquam et dolores nesciunt dicta dolores nam occaecati deleniti. Distinctio incidunt libero quia debitis autem sequi provident quasi veniam. Et autem porro qui unde dolores dolorem atque sunt sit.", null, false, true, "Dicta aut quas quaerat soluta dignissimos alias dolorum molestiae aut.", null, "Gregorio-McGlynn" },
                    { 2, "Dion Kunze", "Cumque impedit laudantium perspiciatis quo. Et voluptate illum culpa facere ut. Qui doloribus ab unde nesciunt delectus dignissimos et et illo. Nemo repellat et blanditiis libero explicabo asperiores est. Aut cumque laboriosam. Earum occaecati sit excepturi eum autem occaecati eum nostrum.\n\nQui ea sed nihil architecto suscipit sint omnis et. Ut quo iste qui quod quisquam officia veritatis sit. Rerum et ut. Rerum dolor recusandae quae perspiciatis sed quaerat. Dolorem architecto est. Natus similique et porro delectus.\n\nAsperiores nihil soluta fuga inventore rerum expedita recusandae. Odit temporibus et architecto dolorem. Repellendus nostrum ea accusamus incidunt sed similique eius tempore atque. Deleniti neque voluptatem ducimus totam architecto a ut. Et sapiente sequi officiis. Necessitatibus animi itaque voluptates autem dolorem.\n\nHarum repellendus quia. Explicabo eligendi similique molestiae atque. Qui suscipit neque. Voluptates officiis rerum porro rerum odit. Sit qui eos non totam laboriosam sint et enim exercitationem.\n\nIure provident ut. Voluptatem reiciendis ut in. Nihil tenetur aut ut et qui est veritatis ut. Modi unde dolorem laborum sapiente amet repellendus et.\n\nQuibusdam ipsum quo. Quaerat est sapiente tempore placeat quos id soluta nihil. Mollitia accusamus consequuntur. Tempora rerum dolorem similique ipsa quidem explicabo non eius sint.\n\nCommodi aliquid repudiandae aliquid voluptatem magnam et sit minima totam. Perferendis ipsam omnis et ut voluptas. Perferendis sunt inventore. Ea velit tempora incidunt magni architecto id minus iste.\n\nAut consequuntur eum assumenda ex dicta. Et earum impedit possimus excepturi. Magnam ut quo omnis nobis nesciunt ut sit aut.\n\nQuas quia autem quia dolorem ducimus perspiciatis repudiandae iure et. Est ut assumenda corrupti aut libero laudantium. Sunt est eveniet. Reiciendis eos commodi sit ab qui. Numquam molestiae natus iusto.\n\nExercitationem tempora laudantium dolores. Voluptas quia consectetur quod. Quia repellendus adipisci sit ut porro voluptas. Corporis id impedit vel quaerat et.", new DateTime(2022, 12, 25, 16, 18, 46, 239, DateTimeKind.Local).AddTicks(2862), "Tempora in quae minima atque ex est esse autem. Aut dolores cupiditate possimus. Quisquam blanditiis dicta qui ipsa.", null, false, true, "Fugit nesciunt omnis fugiat facere labore quia quia dolor in.", null, "Rylan-Fahey" },
                    { 3, "Esta Barton", "Omnis doloremque vel nisi a quas porro sed. Et autem suscipit blanditiis ratione. Velit porro dolorum corrupti. Debitis dolorem id vero. Fuga eius saepe eveniet dicta quo ipsum facilis. Eius repellat deleniti et quisquam consequatur aut qui porro.\n\nConsectetur voluptatum ut voluptas tempore totam fugiat consequatur autem voluptas. Exercitationem cupiditate nam sit quis qui modi amet quasi fuga. Et molestiae modi non et ut cum explicabo.\n\nEst tenetur quos. Cum similique tempora et. Ea pariatur veritatis.\n\nA doloribus iure cupiditate minima molestias provident inventore. Dolores nulla laborum aut quod. Recusandae magni cumque et eum nobis. Quia sit est magnam repellat similique veritatis.\n\nSimilique facilis sint ut beatae excepturi sequi vel rerum. Omnis tempore asperiores corporis et laudantium atque. Quasi incidunt voluptatem ducimus. Sit iure illum sed repudiandae doloremque.\n\nAsperiores sit et minima delectus officia est quia quam aut. Aut aliquam magni eveniet dolor aut perspiciatis repellendus excepturi aliquid. Aperiam eligendi quia adipisci dolores culpa voluptatem enim et repellendus. Laborum natus expedita laboriosam. Aspernatur debitis quo.\n\nAliquam voluptatem voluptatum adipisci necessitatibus quos quidem voluptatem. Et asperiores laborum alias voluptatibus. Nesciunt est sunt consectetur veritatis aut minus aut voluptas facilis. Et quo eos ducimus et et praesentium. Omnis molestiae est repellat est. Fuga doloribus officiis.\n\nAlias iste tempore vel. Quia repellendus occaecati eum ut cupiditate neque harum omnis. Magnam et praesentium et laboriosam. Voluptatem distinctio quia sed. Est atque aut odio sed eos error.\n\nPerferendis similique praesentium asperiores quia quia veniam harum. Aliquam voluptatem perferendis dignissimos exercitationem voluptas qui provident hic. Rerum at eveniet totam. Ex omnis corporis quam reprehenderit nihil nam animi recusandae. Ullam soluta nisi totam et eius voluptates occaecati eos hic.\n\nVoluptas amet voluptatem et officia voluptates. Possimus temporibus sed aut laborum. Sunt illum et labore autem deserunt nam vitae. Asperiores nesciunt deleniti veritatis voluptatem maiores eaque.", new DateTime(2022, 12, 25, 23, 33, 24, 573, DateTimeKind.Local).AddTicks(481), "Doloremque eos asperiores cum ipsam illum pariatur doloribus aperiam cumque. Recusandae est unde vitae amet qui exercitationem.", null, false, true, "Iste quia natus et dignissimos reiciendis ad nostrum totam harum.", null, "Reanna-Runte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 73);
        }
    }
}