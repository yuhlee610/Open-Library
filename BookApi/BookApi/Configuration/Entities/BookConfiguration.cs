using BookApi.Data;
using BookApi.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Configuration.Entities
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Name = "The Fault In Our Stars",
                    Picture = ReadFile.ImageToByte("Images/9780141345659-2-390x510.jpg"),
                    Author = "John Green",
                    Description = "Despite the tumor-shrinking medical miracle that has bought her a few years, Hazel has never been anything but terminal, her final chapter inscribed upon diagnosis. But when a gorgeous plot twist named Augustus Waters suddenly appears at Cancer Kid Support Group, Hazel's story is about to be completely rewritten.",
                    Year = 2013,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "The Sun Is Also A Star",
                    Picture = ReadFile.ImageToByte("Images/the_sun_is_also_a_star_1_2018_05_21_15_04_22.jpg"),
                    Author = "Nicola Yoon",
                    Description = "The New York Times and internationally bestselling love story from Nicola Yoon, author of Everything, Everything - now a film starring Amandla Stenberg and Nick Robinson, in cinemas this summer Natasha: I’m a girl who believes in science and facts. Not fate. Not destiny. Or dreams that will never come true. I’m definitely not the kind of girl who meets a cute boy on a crowded New York City street and falls in love with him. Not when my family is twelve hours away from being deported to Jamaica. Falling in love with him won’t be my story. Daniel: I’ve always been the good son, the good student, living up to my parents’ high expectations. Never the poet. Or the dreamer. But when I see her, I forget about all that. Something about Natasha makes me think that fate has something much more extraordinary in store―for both of us. The Universe: Every moment in our lives has brought us to this single moment. A million futures lie before us. Which one will come true?",
                    Year = 2016,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 3,
                    Name = "Everything, Everything",
                    Picture = ReadFile.ImageToByte("Images/9780552574235_1.jpg"),
                    Author = "Nicola Yoon",
                    Description = "Madeline Whittier is allergic to the outside world. So allergic, in fact, that she has never left the house in all of her seventeen years. But when Olly moves in next door, and wants to talk to Maddie, tiny holes start to appear in the protective bubble her mother has built around her. Olly writes his IM address on a piece of paper, shows it at her window, and suddenly, a door opens. But does Maddie dare to step outside her comfort zone? \"Everything, Everything\" is about the thrill and heartbreak that happens when we break out of our shell to do crazy, sometimes death-defying things for love.",
                    Year = 2015,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 4,
                    Name = "Ticket To Childhood",
                    Picture = ReadFile.ImageToByte("Images/image_180164_1_43_1_57_1_4_1_2_1_210_1_29_1_98_1_25_1_21_1_5_1_3_1_18_1_18_1_45_1_26_1_32_1_14_1_2198.jpg"),
                    Author = "Nguyễn Nhật Ánh",
                    Description = "The story of a man looking back on his life, Ticket to Childhood captures the texture of childhood in all of its richness. As we learn of the small miracles and tragedies that made up the narrator’s life―the misadventures and the misdeeds―we meet his long-lost friends, none of whom can forget how rich their lives once were. And even if Nguyen Nhat Anh can’t take us back to our own childhoods, he captures those innocent times with a great deftness. A fable that will charm adults and move children, Ticket to Childhood is sure to capture the hearts of American readers.",
                    Year = 2018,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 5,
                    Name = "After You",
                    Picture = ReadFile.ImageToByte("Images/9781405926751.png"),
                    Author = "Jojo Moyes",
                    Description = "A tender, funny and hopeful look at love, grief and life. Bumper box of tissues required (Stylist)",
                    Year = 2016,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 6,
                    Name = "Tweet Cute",
                    Picture = ReadFile.ImageToByte("Images/image_234988.jpg"),
                    Author = "Emma Lord",
                    Description = "\"A witty rom - com reinvention... with deeply relatable insights on family pressure and growing up.\" - Emily Wibberley and Austin Siegemund-Broka, authors of Always Never Yours and If I'm Being Honest \"An adorable debut that updates a classic romantic trope with a buzzy twist.\" - Jenn Bennett, author of Alex, Approximately and Serious Moonlight",
                    Year = 2020,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 7,
                    Name = "The Silent Patient",
                    Picture = ReadFile.ImageToByte("Images/image_195509_1_35664.jpg"),
                    Author = "Alex Michaelides",
                    Description = "The Silent Patient is a shocking psychological thriller of a woman’s act of violence against her husband―and of the therapist obsessed with uncovering her motive. Alicia Berenson’s life is seemingly perfect. A famous painter married to an in-demand fashion photographer, she lives in a grand house with big windows overlooking a park in one of London’s most desirable areas. One evening her husband Gabriel returns home late from a fashion shoot, and Alicia shoots him five times in the face, and then never speaks another word. Alicia’s refusal to talk, or give any kind of explanation, turns a domestic tragedy into something far grander, a mystery that captures the public imagination and casts Alicia into notoriety. The price of her art skyrockets, and she, the silent patient, is hidden away from the tabloids and spotlight at the Grove, a secure forensic unit in North London. Theo Faber is a criminal psychotherapist who has waited a long time for the opportunity to work with Alicia. His determination to get her to talk and unravel the mystery of why she shot her husband takes him down a twisting path into his own motivations―a search for the truth that threatens to consume him.... ",
                    Year = 2020,
                    CategoryId = 2
                }, 
                new Book
                {
                    Id = 8,
                    Name = "The Fountainhead",
                    Picture = ReadFile.ImageToByte("Images/9780451191151.jpg"),
                    Author = "Ayn Rand, Leonard Peikoff",
                    Description = "When \"The Fountainhead\" was first published, Ayn Rand's daringly original literary vision and her groundbreaking philosphy, Objectivism, won immediate worldwide interest and acclaim. This instant classic is the story of an intransigent young architect, his violent battle against conventional standards, and his explosive love affair with a beautiful woman who struggles to defeat him. This edition contains a special Afterword by Rand's literary executor, Leonard Peikoff, which includes excerpts from Ayn Rands' own notes on the making of \"The Fountainhead.\" As fresh today as it was then, here is a novel about a hero - and about those who try to destroy him. ",
                    Year = 2001,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 9,
                    Name = "The Cousins",
                    Picture = ReadFile.ImageToByte("Images/image_240967.jpg"),
                    Author = "Karen M. McManus",
                    Description = "Milly, Aubrey, and Jonah Story are cousins, but they barely know each another, and they've never even met their grandmother. Rich and reclusive, she disinherited their parents before they were born. So when they each receive a letter inviting them to work at her island resort for the summer, they're surprised . . . and curious. Their parents are all clear on one point--not going is not an option. This could be the opportunity to get back into Grandmother's good graces. But when the cousins arrive on the island, it's immediately clear that she has different plans for them. And the longer they stay, the more they realize how mysterious--and dark--their family's past is. The entire Story family has secrets. Whatever pulled them apart years ago isn't over--and this summer, the cousins will learn everything.",
                    Year = 2020,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 10,
                    Name = "Jar Of Hearts",
                    Picture = ReadFile.ImageToByte("Images/image_234083.jpg"),
                    Author = "Jennifer Hillier",
                    Description = "An explosive, edge-of-your-seat read about three friends, one murder, and a whole world of secrets... Angela was one of the most popular girls in her high school before she disappeared without a trace. Nobody ever knew what became of her--not Georgina, her best friend, nor Kaiser, who was close with both girls. Then, fourteen years later, Angela's remains were discovered in the woods near Geo's childhood home and Kaiser--who became a detective with the Seattle police department--finally learned the truth: Angela was a victim of Calvin James. To the authorities, Calvin was a notorious serial killer. But back in the day, Calvin was Geo's first love. Their relationship bordered on obsession from the moment they met, right up until the night Angela was killed. Geo carried the secret of Calvin's dark deeds until the evidence landed her in prison. But now, just as Geo is about to be released, new bodies start turning up--killed in the exact same manner as Angela. . . and soon Geo, Kaiser, and local law enforcement officials realize that what happened that fateful night is more complex and chilling than anyone could have imagined. \"Thrilling...terrifying, Jar of Hearts is definitely not something you've read before.\"--Cleveland Plain Dealer ",
                    Year = 2020,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 11,
                    Name = "Jar Of Hearts",
                    Picture = ReadFile.ImageToByte("Images/image_195509_1_19758.jpg"),
                    Author = "C. J. Tudor",
                    Description = "It was only meant to be a game . . . None of us ever agreed on the exact beginning. Was it when we started drawing the chalk figures, or when they started to appear on their own? Was it the terrible accident? Or when they found the first body? ",
                    Year = 2018,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 12,
                    Name = "Elevation",
                    Picture = ReadFile.ImageToByte("Images/image_195509_1_44073.jpg"),
                    Author = "Stephen King",
                    Description = "In the small town of Castle Rock word gets around quickly. That's why Scott Carey only confides in his friend Doctor Bob Ellis about his strange condition. Every day he's losing weight - but without looking any different. Meanwhile a new couple, Deirdre and Missy, owners of a 'fine dining experience' in town, have moved in next door. Scott is not happy that their dogs keep fouling on his lawn. But as the town prepares for its annual Thanksgiving 12K run, Scott starts to understand the prejudices his neighbours face. Soon, they forge a friendship which may just help him through his mysterious affliction...",
                    Year = 2019,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 13,
                    Name = "Hunting Prince Dracula",
                    Picture = ReadFile.ImageToByte("Images/image_242147.jpg"),
                    Author = "Stephen King",
                    Description = "Following the grief and horror of her discovery of Jack the Ripper's true identity, Audrey Rose Wadsworth has no choice but to flee London and its memories. Together with the arrogant yet charming Thomas Cresswell, she journeys to the dark heart of Romania, home to one of Europe's best schools of forensic medicine...and to another notorious killer, Vlad the Impaler, whose thirst for blood became legend. But her life's dream is soon tainted by blood-soaked discoveries in the halls of the school's forbidding castle, and Audrey Rose is compelled to investigate the strangely familiar murders. What she finds brings all her terrifying fears to life once again. ",
                    Year = 2018,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 14,
                    Name = "Horrid",
                    Picture = ReadFile.ImageToByte("Images/image_243087.jpg"),
                    Author = "Katrina Leno",
                    Description = "Following her father's death, Jane North-Robinson and her mom move from sunny California to the dreary, dilapidated old house in Maine where her mother grew up. All they want is a fresh start, but behind North Manor's doors lurks a history that leaves them feeling more alone . . . and more tormented. As the cold New England autumn arrives, and Jane settles in to her new home, she finds solace in old books and memories of her dad. She steadily begins making new friends, but also faces bullying from the resident \"bad seed,\" struggling to tamp down her own worst nature in response. Jane's mom also seems to be spiraling with the return of her childhood home, but she won't reveal why. Then Jane discovers that the \"storage room\" her mom has kept locked isn't for storage at all -- it's a little girl's bedroom, left untouched for years and not quite as empty of inhabitants as it appears . . . Is it grief? Mental illness? Or something more . . . horrid? ",
                    Year = 2020,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 15,
                    Name = "Percy Jackson And The Olympians 1: Lightning Thief",
                    Picture = ReadFile.ImageToByte("Images/9780786838653_2.jpg"),
                    Author = "Rick Riordan",
                    Description = "Percy Jackson is a good kid, but he can’t seem to focus on his schoolwork or control his temper. And lately, being away at boarding school is only getting worse—Percy could have sworn his pre-algebra teacher turned into a monster and tried to kill him. When Percy’s mom finds out, she knows it’s time that he knew the truth about where he came from, and that he go to the one place he’ll be safe. She sends Percy to Camp Half-Blood, a summer camp for demigods (on Long Island), where he learns that the father he never knew is Poseidon, God of the Sea. Soon a mystery unfolds and together with his friends—one a satyr and the other the demigod daughter of Athena—Percy sets out on a quest across the United States to reach the gates of the Underworld (located in a recording studio in Hollywood) and prevent a catastrophic war between the gods.",
                    Year = 2006,
                    CategoryId = 4
                },
                new Book
                {
                    Id = 16,
                    Name = "Bridge to Terabithia",
                    Picture = ReadFile.ImageToByte("Images/bridge_to_terabithia_1_2018_08_21_17_37_53.jpg"),
                    Author = "Katherine Paterson,Donna Diamond",
                    Description = "This Newbery Medal-winning novel by bestselling author Katherine Paterson is a modern classic of friendship and loss.Jess Aarons has been practicing all summer so he can be the fastest runner in the fifth grade. And he almost is, until the new girl in school, Leslie Burke, outpaces him. The two become fast friends and spend most days in the woods behind Leslie's house, where they invent an enchanted land called Terabithia. One morning, Leslie goes to Terabithia without Jess and a tragedy occurs. It will take the love of his family and the strength that Leslie has given him for Jess to be able to deal with his grief. In addition to being a Newbery Medal winner, Bridge to Terabithia was also named an ALA Notable Children's Book and has become a touchstone of children's literature, as have many of Katherine Paterson's other novels, including The Great Gilly Hopkins and Jacob Have I Loved.Supports the Common Core State Standards",
                    Year = 2009,
                    CategoryId = 4
                },
                new Book
                {
                    Id = 17,
                    Name = "The Lion, the Witch, and the Wardrobe",
                    Picture = ReadFile.ImageToByte("Images/image_55553.jpg"),
                    Author = "C S Lewis,Pauline Baynes",
                    Description = "NARNIA...the land beyond the wardrobe, the secret country known only to Peter, Susan, Edmund, and Lucy...the place where the adventure begins.",
                    Year = 2008,
                    CategoryId = 4
                },
                new Book
                {
                    Id = 18,
                    Name = "Percy Jackson And The Olympians 2: The Sea Of Monsters",
                    Picture = ReadFile.ImageToByte("Images/9781423103349_2.jpg"),
                    Author = "Rick Riordan",
                    Year = 2008,
                    CategoryId = 4
                },
                new Book
                {
                    Id = 19,
                    Name = "The Waning Age",
                    Picture = ReadFile.ImageToByte("Images/image_195509_1_31184.jpg"),
                    Author = "S. E. Grove",
                    Description = "From the New York Times bestselling author of The Glass Sentence, a lightly speculative, relevant puzzle box with undertones of Never Let Me Go. The time is now. The place is San Francisco. The world is filled with adults devoid of emotion and children on the cusp of losing their feelings--of \"waning\"--when they reach their teens. Natalia Peña has already waned. So why does she love her little brother with such ferocity that, when he's kidnapped by a Big Brother-esque corporation, she'll do anything to get him back? From the New York Times bestselling author of The Glass Sentence comes this haunting story of one determined girl who will use her razor-sharp wits, her martial arts skills, and, ultimately, her heart to fight killers, predators, and the world's biggest company to rescue her brother--and to uncover the shocking truth about waning.",
                    Year = 2019,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 20,
                    Name = "The Book Thief",
                    Picture = ReadFile.ImageToByte("Images/image_140810.jpg"),
                    Author = "Markus Zusak",
                    Description = "1939. Nazi Germany. The country is holding its breath. Death has never been busier. Liesel, a nine-year-old girl, is living with a foster family on Himmel Street. Her parents have been taken away to a concentration camp. Liesel steals books. This is her story and the story of the inhabitants of her street when the bombs begin to fall.",
                    Year = 2014,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 21,
                    Name = "Girl In A Bad Place",
                    Picture = ReadFile.ImageToByte("Images/image_195509_1_39212.jpg"),
                    Author = "Kaitlin Ward",
                    Description = "Mailee and Cara take care of each other. Mailee is the star of the high school plays; Cara is the stage manager. Mailee can't keep her life together; Cara has enough organizational skills for the both of them.So when the girls are invited to visit the Haven, a commune in the mountains near their suburban Montana homes, it seems like an adventure. Until Cara starts spending every waking minute there... and Mailee thinks it's creepy, almost like a cult. When Cara decides she's going to move to the Haven permanently, Mailee knows it's a bad idea. But how far will she go to save her best friend... from herself?",
                    Year = 2018,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 22,
                    Name = "For Whom the Bell Tolls",
                    Picture = ReadFile.ImageToByte("Images/image_105432.jpg"),
                    Author = "Ernest Hemingway",
                    Description = "High in the pine forests of the Spanish Sierra, a guerrilla band prepares to blow up a vital bridge. Robert Jordan, a young American volunteer, has been sent to handle the dynamiting. There, in the mountains, he finds the dangers and the intense comradeship of war. And there he discovers Maria, a young woman who has escaped from Franco's rebels...",
                    Year = 1999,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 23,
                    Name = "Odysseus: The Return : Book Two",
                    Picture = ReadFile.ImageToByte("Images/image_93572.jpg"),
                    Author = "Valerio Massimo Manfredi",
                    Description = "The extraordinary story of a legendary hero continues ...After ten years of uninterrupted war, blood and agony, the Trojans have finally been defeated. Odysseus and his men begin the epic journey of returning to Ithaca. Along the way, terrifying enemies await them: the cyclops Polyphemus, the lotus eaters who feast on narcotic flowers that give only oblivion, the sorceress who turns men into swine, and the deadly, enthralling sirens. Odysseus is determined to make his way home to Ithaca, where his beloved family have awaited him for many long years. But his journey will present him with new, terrible perils - ones that he could not have dreamed of even in his wildest nightmares. In this stunning new novel, Valerio Massimo Manfredi gives a new voice to one of the most adventurous and fascinating heroes of all time.",
                    Year = 2015,
                    CategoryId = 5
                });
        }
    }
}
