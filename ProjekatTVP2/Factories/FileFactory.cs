using ProjekatTVP2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace ProjekatTVP2.Factories
{
    class FileFactory
    {
        private StorageFolder _appInstalledPath;

        public FileFactory()
        {
            _appInstalledPath = ApplicationData.Current.LocalFolder;
            InitiateData();
        }

        private async void InitiateData()
        {
            #region vesti array
            News[] vesti =
            {
            new News
            {
                Id = 0,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 14, 7, 0),
                Headline = "Uhapšeno dvoje u Sarajevu zbog ometanja suđenja Naseru Keljmendiju",
                Article = @"Agencija za istrage i bezbednost BiH saopštila je da su u Sarajevu jutros uhapšene dve osobe zbog sumnje da su ometali istragu u slučaju procesa koji se u Prištini vodi protiv narko dilera Nasera Keljmendija, a mediji navode da je reč o članovime Stranke za bolju budućnost (SBB) Fahrudina Radončića.
                                Reč je, kako se navodi, o B.D. i B.Š, a uhapšeni su zbog sumnje da su ometali rad pravosuđa.
                                Oni se sumnjiče da su tokom decembra 2015. godine zastrašivanjem i nuđenjem mita navodili svedoka A.S. da da lažni iskaz u krivičnom postupku koje Tužilaštvo BiH i Osnovni sud u Prištini vode protiv narkodilera sa Kosova Nasera Keljmendija.",
                NewsType = TipVesti.Hronika,
                ImagePath = "/Assets/SlikeVesti/hronika-1.jpg"
            },
            new News
            {
                Id = 1,
                Author = "V.Z.C.",
                PublishDate = new DateTime(2016, 1, 11, 14, 6, 0),
                Headline = "SUĐENJE ZA OTMICU MALE MAŠE Svedočio policajac koji je uhapsio otmičare",
                Article = @"Na suđenju  optuženim Francuzima za otmicu Maše Prenković (3) svedočio je saobraćajni policajac, iz patrole koja ih je privela.
                                Osim njega danas u Specijalnom sudu svedočilo je još troje očevidaca otmice male Maše u beogradskom naselju braće Jerkovića 13. marta 2015.
                                Saobraćajni policajac Ivan Lapčević je detaljno ispričao kako je njegova patrola oko 13 sati dobila informaciju o otmici, a nešto kasnije videla BMW na autoputu kod isključenja za Sremsku Mitrovicu  i muškarca koji je nosio dete u rukama idući ka zaštitnoj ogradi.",
                NewsType = TipVesti.Hronika,
                ImagePath = "/Assets/SlikeVesti/hronika-2.jpg"
            },
            new News
            {
                Id = 2,
                Author = "Branko Janackovic",
                PublishDate = new DateTime(2016, 1, 11, 19, 48, 0),
                Headline = "HLADNOKRVNO UBISTVO \"Rambo nožem\" 17 puta ubo oca u leđa",
                Article = @"Aleksandar Marinković (20) iz Aleksinca uhapšen je zbog sumnje da je sa 17 uboda nožem u leđa brutalno ubio oca Srđana Marinkovića (43) u kući u Glogovici. 
                                Pošto je masakrirao oca „rambo“ nožem, Aleksandar je juče oko ponoći zamotao cigaretu i izašao napolje!
                                Saša Marinković, brat ubijenog Srđana, širi ruke kao da još ne može da poveruje šta se desilo...",
                NewsType = TipVesti.Hronika,
                ImagePath = "/Assets/SlikeVesti/hronika-3.jpg"
            },
            new News
            {
                Id = 3,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 17, 10, 0),
                Headline = "Podignuta optužnica protiv bivšeg direktora Privredne komore Beograd Milana Jankovića",
                Article = @"Više javno tužilaštvo u Beogradu podiglo je optužnicu protiv bivšeg direktora Privredne komore Beograd Milana Jankovića zbog sumnje da je zloupotrebama oštetio tu komoru, rečeno je danas Tanjugu u tom tužilaštvu.
                                Optuženi pored Jankovića su njegova saradnica Ivana Zeljković, Veselin Sjekloće, Milivoj Armuš i Predrag Ćurčić, rekla je Tanjugu portparol tužilaštva Tatjana Sekulić.
                                Na teret im se stavlja krivično delo zloupotreba položaja odgovornog lica, navela je Sekulić.
                                Ona je precizirala da je optužnica podignuta krajem decembra i da se čeka njeno potvrđivanje.",
                NewsType = TipVesti.Hronika,
                ImagePath = "/Assets/SlikeVesti/hronika-4.jpg"
            },
            new News
            {
                Id = 4,
                Author = "J. Medic",
                PublishDate = new DateTime(2016, 1, 10, 19, 50, 0),
                Headline = "KAKAV TRIJUMF DELFINA Srbija deklasirala Hrvatsku na startu prvenstva Evrope!",
                Article = "Možda je ovo samo početak takmičenja, ali - kakav je to samo početak! U prvom kolu šampionata Evrope u vaterpolu, koje je počelo u Beogradu, reprezentacija Srbije je olimpijskog prvaka, Hrvatsku, deklasirala u Kombank areni sa 13:6 (3:1, 4:2, 5:1, 1:2), povevši najpre sa devet golova razlike, pre nego što je u finišu dozvolila gostima dva pogotka.",
                NewsType = TipVesti.Sport,
                ImagePath = "/Assets/SlikeVesti/sport-1.jpg"
            },
            new News
            {
                Id = 5,
                Author = "Jelena Medic",
                PublishDate = new DateTime(2016, 1, 9, 21, 27, 0),
                Headline = "EMOTIVNO Novak posvetio trofej pokojnom dedi: On me je zvao \"sokole\"",
                Article = "Uz ovacije. Tako je Novak Đoković bio dočekan u pres centru posle prvog osvojenog turnira u sezoni. Zadovoljno je ušetao sa peharom u ruci. Imao je sve razloge ovoga sveta da bude presrećan.",
                NewsType = TipVesti.Sport,
                ImagePath = "/Assets/SlikeVesti/sport-2.jpg"
            },
            new News
            {
                Id = 6,
                Author = "B.O.",
                PublishDate = new DateTime(2016, 1, 10, 21, 4, 0),
                Headline = "Nikolić, Vučić i Mali izviždani na otvaranju Evropskog prvenstva u vaterpolu",
                Article = @"Publika u beogradskoj Kombank areni izviždala je državni vrh Srbije tokom svečane ceremonije otvaranja Evropskog prvenstva u vaterpolu.
                                Uoči utakmice Srbija - Hrvatska gledaoci su najpre negodovali prilikom pojave predsednika Tomislava Nikolića.
                                Kada je reč uzeo ministar omladine i sporta u Vladi Republike Srbije, Vanja Udovičić, njega su najpre dočekali aplauzi, no kada je on spomenuo u pozitivnom kontekstu doprinose premijera Aleksandra Vučića i gradonačelnika Beograda, Siniše Malog, zviždanje je ponovljeno.",
                NewsType = TipVesti.Sport,
                ImagePath = "/Assets/SlikeVesti/sport-3.jpg"
            },
            new News
            {
                Id = 7,
                Author = "B.O.",
                PublishDate = new DateTime(2016, 1, 10, 22, 19, 0),
                Headline = "Hrvatski mediji o debaklu njihovih vaterpolista u Beogradu: Iživljavanje! Jedva smo čekali da se meč završi!",
                Article = @"Nisu štedeli hrvatski mediji svoje vaterpoliste koji su u prvom kolu Evropskog prvenstva u Beogradu deklasirani od Srbije sa 13:6.
                                'Večernji list' je tako izveštaj naslovio rečima 'Bledo izdanje Hrvatske na otvaranju Eura, Srbija uverljivo slavila', a u samom tekstu se ističe i sledeće:
                                'Jedva smo čekali da se utakmica završi i to najbolje govori o današnjem izdanju Hrvatske. Srbija jeste kvalitetnija, no bilo je ovo vrlo bledo izdanje naših vaterpolista. Iako ovaj poraz neće puno značiti za prolazak grupe, nije ugodno ovako izgubiti...",
                NewsType = TipVesti.Sport,
                ImagePath = "/Assets/SlikeVesti/sport-4.jpg"
            },
            new News
            {
                Id = 8,
                Author = "V.J.",
                PublishDate = new DateTime(2016, 1, 11, 16, 1, 0),
                Headline = "O OVOME SVI PRIČAJU Kako se Dikaprio narugao Lejdi Gagi",
                Article = @"U Los Anđelesu je sinoć održana 73. dodela Zlatnih globusa, prestižnih filmskih nagrada. Detalj po kojem će se pamtiti ovo veče svakako je reakcija glumca Leonarda Dikapria kada je čuo da je Lejdi Gaga dobila jedan od globusa.",
                NewsType = TipVesti.Zabava,
                ImagePath = "/Assets/SlikeVesti/zabava-1.jpg"
            },
            new News
            {
                Id = 9,
                Author = "T.S.",
                PublishDate = new DateTime(2016, 1, 11, 18, 30, 0),
                Headline = "Najveća podrška: Silvester Stalone na dodeli Zlatnog globusa sa ćerkama",
                Article = @"Sofija (19), Sistin (16) i Skarlet (13) sa majkom Dženifer Flavin došle su na dodelu nagrada kako bi podržale slavnog glumca.
                                Stalone je bio ponosan zbog nagrade, ali i na svoje lepše polovine, koje su izgledom privukle pažnju mnogih.
                                Najstarija Sofija nosila je dugu, crnu haljinu, dok je Sistin zablistala u dugoj plavoj haljini. Najmlađa Skatlet nosila je belu haljinu, koja je bila nalik venčanici, te je u istoj delovala mnogo starije.",
                NewsType = TipVesti.Zabava,
                ImagePath = "/Assets/SlikeVesti/zabava-2.jpg"
            },
            new News
            {
                Id = 10,
                Author = "Promo",
                PublishDate = new DateTime(2016, 1, 11, 14, 11, 0),
                Headline = "Još samo tri dana do kraja velike EXIT praznične akcije",
                Article = @"Ulaznice se mogu kupiti onlajn putem sajta exitfest.org, kao i direktno u mreži Gigs Tix na preko 50 prodajnih mesta u 25 gradova širom Srbije, među kojima su i knjižare Vulkan, te lanac prodavnica Corner Shop. U prodaji su i turistički paketi koji sadrže i ulaznicu i smeštaj već od 65 evra za Exit festival ili samo 79 evra za celu Exit Avanturu i mogu se naručiti putem sajta exittrip.org. Paketi se prodaju po najpovoljnijim cenama takođe samo do četvrtka u ponoć i sadrže ulaznicu za oba festivala, smeštaj u festivalskim kampovima na peščanim plažama na Dunavu i Jadranu, a na sajtu Exit Tripa, zvanične turističke agencije Exit Avanture, moguće je odabrati i drugi smeštaj, u hostelu ili apartmanima.",
                NewsType = TipVesti.Zabava,
                ImagePath = "/Assets/SlikeVesti/zabava-3.jpg"
            },
            new News
            {
                Id = 11,
                Author = "D.I.",
                PublishDate = new DateTime(2016, 11, 1, 13, 42, 0),
                Headline = "Željko za srpsku Novu godinu u Kosovskoj Mitrovici: Čast mi je što ću biti uz srpski narod!",
                Article = @"Biće to prvi put da Joksimović nastupa u našoj južnoj pokrajini.
                                - Radujem se susretu sa našim ljudima koji žive na Kosovu i Metohiji. Nadam se da će se okupiti u velikom broju, ne samo iz Kosovske Mitrovice, već i iz drugih srpskih mesta. Želimo da priredimo jedno lepo veče, gde ćemo u dobrom raspoloženju dočekati Novu godinu.",
                NewsType = TipVesti.Zabava,
                ImagePath = "/Assets/SlikeVesti/zabava-4.jpg"
            },
            new News
            {
                Id = 12,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 11, 1, 17, 27, 0),
                Headline = "Sipa uhapsila u Velikoj Kladuši tri osobe sa zastavama IS",
                Article = @"To je nastavak akcije 'Damask' koja ima za cilj otkrivanje osoba za koje se sumnja da su u vezi s radikalnim islamskim terorizmom.
                                Sipa je navela da su u akciji pronađene i ručne bombe, tomblonska mina, protivpešadijske nagazne mine, veća količina municije, mačeta, zastava Islamske države, kao i plastični šablon za oslikavanje obeležja Islamske države.",
                NewsType = TipVesti.Svet,
                ImagePath = "/Assets/SlikeVesti/svet-1.jpg"
            },
            new News
            {
                Id = 13,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 18, 40, 0),
                Headline = "SPAS Prva humanitarna pomoć stigla u Madaju gde deca umiru od gladi",
                Article = @"Kamioni Crvenog krsta i Crvenog polumeseca s hranom i lekovima uli su u pratnji vozila UN-a u Madaju kod libanske granice, kako je i dogovoreno između zaraćenih strana - snaga predsednika Baara al-Asada koje drže grad u opsadi i boraca sirijske opozicije.",
                NewsType = TipVesti.Svet,
                ImagePath = "/Assets/SlikeVesti/svet-2.jpg"
            },
            new News
            {
                Id = 14,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 16, 58, 0),
                Headline = "BRANILI KURDE Turska TV emisija pod istragom zbog \"terorističke propagande\"",
                Article = @"Turski tužioci pokrenuli su danas istragu protiv popularne TV emisije zbog širenja kurdske propagande, nakon što je sagovornik u televizijskom šouu kritikovao vojne operacije protiv kurdskih pobunjenika.",
                NewsType = TipVesti.Svet,
                ImagePath = "/Assets/SlikeVesti/svet-3.jpg"
            },
            new News
            {
                Id = 15,
                Author = "Beta - AP",
                PublishDate = new DateTime(2016, 1, 11, 16, 20, 0),
                Headline = "Rusija, SAD i UN traže rešenje za Siriju",
                Article = @"Rusiju će predstavljati zamenik ministra spoljnih poslova Genadij Gatilov, SAD pomoćnica državnog sekretara za bliskoistočna pitanja En Paterson, a UN specijalni izaslank generalnog sekretara UN za Siriju Štafan de Mistura.",
                NewsType = TipVesti.Svet,
                ImagePath = "/Assets/SlikeVesti/svet-4.jpg"
            },
            new News
            {
                Id = 16,
                Author = "N.C.",
                PublishDate = new DateTime(2016, 1, 11, 12, 13, 0),
                Headline = "RUSKI POLITIČAR NE MIRUJE Rogozin se dohvatio PIŠTOLJA i u Beogradu",
                Article = @"Potpredsednik Vlade Rusije Dmitrij Rogozin nalazi se u zvaničnoj poseti Srbiji gde će razgovarati sa srpskim vlastima o prodaji naoružanja, ali i o isporuci gasa. A da je ovaj ruski visoki zvaničnik bukvalno opsednut oružjem dokazuju i postovi sa njegovog Fejsbuk profila.",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-1.jpg"
            },
            new News
            {
                Id = 17,
                Author = "Bojana Jelovac",
                PublishDate = new DateTime(2016, 1, 11, 21, 52, 0),
                Headline = "SUKOBI NA VRHU VLASTI Mir trajao pet dana",
                Article = @"Ružić je, takođe preko medija, prozvao lidera PS i ministra Aleksandra Vulina. Komentarišući ulazak Zorice Brunclik u Predsedništvo PS, Ružić je naveo da je moguće da ta folk pevačica na mestu ministra kulture zameni Ivana Tasovca.",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-2.jpg"
            },
            new News
            {
                Id = 18,
                Author = "Bojana Jelovac",
                PublishDate = new DateTime(2016, 1, 11, 19, 42, 0),
                Headline = "ZAHLAĐENJE Pogoršani odnosi Srbije sa susedima",
                Article = @"Najnovije su kritike iz Sarajeva na račun premijera Aleksandra Vučića zbog odlaska na proslavu Dana Republike Srpske, kao i diplomatski okršaj Zagreba i Beograda oko nabavke naoružanja. Neposredno pre toga, Tomislav Nikolić je razmenio optužbe sa vlastima Crne Gore, a i sa Makedonijom je počela kriza nakon što je ta zemlja podržala Kosovo u Unesku.",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-3.jpg"
            },
            new News
            {
                Id = 19,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 15, 18, 0),
                Headline = "SKRNAVLJENJE HRAMA NA KOSOVU Dačić: Ćutanje međunarodne zajedice kao znak odobravanja",
                Article = @"Prvi potpredsednik Vlade Srbije i ministar spoljnih poslova Ivica Dačić izjavio je danas da je skrnavljenje hrama Hrista spasa u Prištini, u prisustvu kosovske policije u vreme Božića, još jedan žalostan dokaz da je Srbija bila u pravu kada se protivila ulasku Kosova u Unesko.",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-4.jpg"
            },
            new News
            {
                Id = 20,
                Author = "Tanjug",
                PublishDate = new DateTime(2016, 1, 11, 14, 21, 0),
                Headline = "Nikolić Rogozinu: Nećemo tražiti ustupke od Rusije, niti ćemo ratovati sa Hrvatskom ili NATO",
                Article = @"Predsednik Srbije je, kako je saopšteno sa Andrićevog venca, u razgovoru sa Rogozinom istakao da su izvanredna politička i ekonomska saradnja doprinele unapređenju vojno-tehničke saradnje.
                                Osvrnuvši se na situaciju na Kosovu i Metohiji i evrointegracije, predsednik Nikolić je rekao da je Srbija posvećena dijalogu, ali da Priština sa jedne strane razgovara, a sa druge radi na sprovođenju nezavisnosti.",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-5.jpg"
            },
            new News
            {
                Id = 21,
                Author = "B.Jelovac",
                PublishDate = new DateTime(2016, 1, 11, 6, 6, 0),
                Headline = "OTKRIVAMO Rogozin došao da nam proda oružje",
                Article = @"Rogozin će danas i sutra u Beogradu prisustvovati zasedanju srpsko-ruskog Međuvladinog komiteta za trgovinu, ekonomsku i naučno-tehničku saradnju, čiji je kopredsednik zajedno sa šefom srpske diplomatije Ivicom Dačićem.
                                - Oružje će svakako biti tema Međuvladinog komiteta. Srbija planira da nabavi naoružanje za zaštitu zemlje i uglavnom je reč o nastavku razgovora koje je premijer Aleksandar Vučić započeo prilikom posete Moskvi u oktobru. Neke stvari koje su tada dogovorene sada će biti realizovane",
                NewsType = TipVesti.Vesti,
                ImagePath = "/Assets/SlikeVesti/vesti-6.jpg"
            }
        };
            #endregion
            #region komentari array
            Comment[] komentari =
            {
            new Comment
            {
                Id = 0,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 1),
                Name = "Korisnik 1",
                Content = "Ovo je neki komentar",
                NewsId = 0,
            },
            new Comment
            {
                Id = 1,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 2),
                Name = "Korisnik 2",
                Content = "Ovo je drugi komentar",
                NewsId = 0,
            },
            new Comment
            {
                Id = 2,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 3),
                Name = "Korisnik 3",
                Content = "Ovaj clanak je ocajan",
                NewsId = 0,
            },
            new Comment
            {
                Id = 3,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 1),
                Name = "Korisnik 4",
                Content = "Okie dokie",
                NewsId = 0,
            },
            new Comment
            {
                Id = 4,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 2),
                Name = "Korisnik 5",
                Content = "Lorem ipsum dolem pule",
                NewsId = 1,
            },
            new Comment
            {
                Id = 5,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 1),
                Name = "Dusko",
                Content = "Bla bla bla, nista pametno",
                NewsId = 2,
            },
            new Comment
            {
                Id = 6,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 1),
                Name = "Nemanja",
                Content = "Smorio sam se",
                NewsId = 3,
            },
            new Comment
            {
                Id = 7,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 1),
                Name = "Nadja",
                Content = "Vec sam previse kucao sve ovo -.-",
                NewsId = 4,
            },
            new Comment
            {
                Id = 8,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 2),
                Name = "User",
                Content = "O MAJ GAD KAD CE KRAJ?!",
                NewsId = 4,
            },
            new Comment
            {
                Id = 9,
                PublishDate = new DateTime(2016, 1, 11, 22, 30, 3),
                Name = "Poslednji",
                Content = "POSLEDNJA INFORMACIJA, FAK JEA!",
                NewsId = 4,
            },
        };
            #endregion
            if (await _appInstalledPath.TryGetItemAsync("Comment-9.xml") == null)
            {
                foreach (News v in vesti)
                {
                    await Write(v);
                }
                foreach (Comment k in komentari)
                {
                    await Write(k);
                }
            }
        }

        public async Task Write<T>(T obj) where T : IModel
        {
            int i = 0;
            var Serializer = new XmlSerializer(typeof(T));
            string fileName = typeof(T).Name + "-" + i + ".xml";
            while (await _appInstalledPath.TryGetItemAsync(fileName) != null)
            {
                i++;
                fileName = typeof(T).Name + "-" + i + ".xml";
            }
            StorageFile file = await _appInstalledPath.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();
            using (stream)
            {
                Serializer.Serialize(stream, obj);
            }
        }

        public async Task<T> Read<T>(string fileName)
        {
            T obj = default(T);
            var Serializer = new XmlSerializer(typeof(T));
            if (await _appInstalledPath.TryGetItemAsync(fileName) != null)
            {
                StorageFile file = await _appInstalledPath.GetFileAsync(fileName);
                Stream stream = await file.OpenStreamForReadAsync();
                obj = (T)Serializer.Deserialize(stream);
                stream.Dispose();
            }
            return obj;
        }
    }
}
