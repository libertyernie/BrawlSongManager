using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BrawlSongManager {
	public class SongsByStage {

		public class SongInfo {
			public SongInfo(FileInfo f) {
				File = f;
			}
			public SongInfo(string s) {
				File = new FileInfo(s + ".brstm");
			}

			public FileInfo File { get; private set; }

			public override string ToString() {
				string s = File.Name;
				if (File.Exists) {
					s = "* " + s;
				} else {
					s = "  " + s;
				}
				return s;
			}
		}

		public static object[] FromCurrentDir {
			get {
				object[] oa = {
					"BATTLEFIELD",
					new SongInfo("X04"),
					new SongInfo("T02"),
					new SongInfo("X25"),
					new SongInfo("W21"),
					new SongInfo("W23"),
					"FINAL DESTINATION",
					new SongInfo("X05"),
					new SongInfo("T01"),
					new SongInfo("T03"),
					new SongInfo("W25"),
					new SongInfo("W31"),
					"DELFINO PLAZA",
					new SongInfo("A13"),
					new SongInfo("A07"),
					new SongInfo("A08"),
					new SongInfo("A14"),
					new SongInfo("A15"),
					"LUIGI'S MANSION",
					new SongInfo("A09"),
					new SongInfo("A06"),
					new SongInfo("A05"),
					new SongInfo("Q10"),
					new SongInfo("Q11"),
					"MUSHROOMY KINGDOM 1-1",
					new SongInfo("A01"),
					new SongInfo("A16"),
					new SongInfo("A10"),
					"MUSHROOMY KINGDOM 1-2",
					new SongInfo("A02"),
					new SongInfo("A03"),
					new SongInfo("A04"),
					"MARIO CIRCUIT",
					new SongInfo("A20"),
					new SongInfo("A21"),
					new SongInfo("A22"),
					new SongInfo("A23"),
					new SongInfo("R05"),
					new SongInfo("R14"),
					new SongInfo("Q09"),
					"RUMBLE FALLS",
					new SongInfo("B01"),
					new SongInfo("B08"),
					new SongInfo("B05"),
					new SongInfo("B06"),
					new SongInfo("B07"),
					new SongInfo("B10"),
					new SongInfo("B02"),
					"BRIDGE OF ELDIN",
					new SongInfo("C02"),
					new SongInfo("C09"),
					new SongInfo("C01"),
					new SongInfo("C04"),
					new SongInfo("C05"),
					new SongInfo("C08"),
					new SongInfo("C17"),
					new SongInfo("C18"),
					new SongInfo("C19"),
					"PIRATE SHIP",
					new SongInfo("C15"),
					new SongInfo("C16"),
					new SongInfo("C07"),
					new SongInfo("C10"),
					new SongInfo("C13"),
					new SongInfo("C11"),
					new SongInfo("C12"),
					new SongInfo("C14"),
					"NORFAIR",
					new SongInfo("D01"),
					new SongInfo("D03"),
					new SongInfo("D02"),
					new SongInfo("D05"),
					new SongInfo("R12"),
					new SongInfo("R07"),
					"FRIGATE ORPHEON",
					new SongInfo("D04"),
					new SongInfo("D08"),
					new SongInfo("D07"),
					new SongInfo("D06"),
					new SongInfo("D09"),
					new SongInfo("D10"),
					"YOSHI'S ISLAND (BRAWL)",
					new SongInfo("E02"),
					new SongInfo("E07"),
					new SongInfo("E01"),
					new SongInfo("E03"),
					new SongInfo("E05"),
					new SongInfo("E06"),
					"HALBERD",
					new SongInfo("F06"),
					new SongInfo("F01"),
					new SongInfo("F05"),
					new SongInfo("F04"),
					new SongInfo("F02"),
					new SongInfo("F12"),
					new SongInfo("F07"),
					new SongInfo("F08"),
					new SongInfo("F03"),
					new SongInfo("F10"),
					new SongInfo("F09"),
					new SongInfo("F11"),
					"LYLAT CRUISE",
					new SongInfo("G10"),
					new SongInfo("G02"),
					new SongInfo("G01"),
					new SongInfo("G03"),
					new SongInfo("G04"),
					new SongInfo("G11"),
					new SongInfo("G05"),
					new SongInfo("G09"),
					new SongInfo("G07"),
					new SongInfo("G08"),
					new SongInfo("Q12"),
					"POKEMON STADIUM 2",
					new SongInfo("H01"),
					new SongInfo("H03"),
					new SongInfo("H02"),
					new SongInfo("H04"),
					new SongInfo("H05"),
					"SPEAR PILLAR",
					new SongInfo("H06"),
					new SongInfo("H08"),
					new SongInfo("H07"),
					new SongInfo("H09"),
					new SongInfo("H10"),
					"PORT TOWN: AERO DIVE",
					new SongInfo("I01"),
					new SongInfo("I03"),
					new SongInfo("I02"),
					new SongInfo("I04"),
					new SongInfo("I05"),
					new SongInfo("I06"),
					new SongInfo("I07"),
					new SongInfo("I08"),
					new SongInfo("I09"),
					new SongInfo("I10"),
					new SongInfo("R09"),
					new SongInfo("W18"),
					"CASTLE SIEGE",
					new SongInfo("J02"),
					new SongInfo("J04"),
					new SongInfo("J08"),
					new SongInfo("J06"),
					new SongInfo("J07"),
					new SongInfo("J03"),
					new SongInfo("J13"),
					new SongInfo("J09"),
					new SongInfo("J10"),
					new SongInfo("J11"),
					new SongInfo("J12"),
					new SongInfo("W17"),
					"WARIOWARE, INC.",
					new SongInfo("M01"),
					new SongInfo("M02"),
					new SongInfo("M08"),
					new SongInfo("M07"),
					new SongInfo("M06"),
					new SongInfo("M05"),
					new SongInfo("M04"),
					new SongInfo("M03"),
					new SongInfo("M09"),
					new SongInfo("M10"),
					new SongInfo("M11"),
					new SongInfo("M12"),
					new SongInfo("M13"),
					new SongInfo("M15"),
					new SongInfo("M16"),
					new SongInfo("M17"),
					new SongInfo("M18"),
					"DISTANT PLANET",
					new SongInfo("L06"),
					new SongInfo("L01"),
					new SongInfo("L07"),
					new SongInfo("L02"),
					new SongInfo("L04"),
					new SongInfo("L08"),
					new SongInfo("L05"),
					new SongInfo("L03"),
					new SongInfo("R08"),
					"SMASHVILLE",
					new SongInfo("N01"),
					new SongInfo("N02"),
					new SongInfo("N03"),
					new SongInfo("N06"),
					new SongInfo("N05"),
					new SongInfo("N07"),
					new SongInfo("N08"),
					new SongInfo("N09"),
					new SongInfo("N10"),
					new SongInfo("N11"),
					new SongInfo("N12"),
					"NEW PORK CITY",
					new SongInfo("K07"),
					new SongInfo("K09"),
					new SongInfo("K08"),
					new SongInfo("K10"),
					new SongInfo("K05"),
					new SongInfo("K01"),
					"SUMMIT",
					new SongInfo("Q07"),
					new SongInfo("Q06"),
					new SongInfo("Q08"),
					new SongInfo("Q05"),
					new SongInfo("W13"),
					"SKYWORLD",
					new SongInfo("P01"),
					new SongInfo("P03"),
					new SongInfo("P02"),
					new SongInfo("P04"),
					"75M",
					new SongInfo("B04"),
					new SongInfo("B03"),
					new SongInfo("B09"),
					"MARIO BROS.",
					new SongInfo("A17"),
					new SongInfo("Q02"),
					new SongInfo("Q01"),
					new SongInfo("Q13"),
					new SongInfo("Q14"),
					"FLAT ZONE 2",
					new SongInfo("R04"),
					new SongInfo("Q04"),
					new SongInfo("W14"),
					"PICTOCHAT",
					new SongInfo("R02"),
					new SongInfo("R10"),
					new SongInfo("R11"),
					new SongInfo("R15"),
					new SongInfo("R16"),
					new SongInfo("R17"),
					new SongInfo("R13"),
					new SongInfo("R06"),
					new SongInfo("W20"),
					"HANENBOW",
					new SongInfo("R03"),
					"SHADOW MOSES ISLAND",
					new SongInfo("S06"),
					new SongInfo("S02"),
					new SongInfo("S03"),
					new SongInfo("S08"),
					new SongInfo("S04"),
					new SongInfo("S07"),
					new SongInfo("S05"),
					new SongInfo("S10"),
					new SongInfo("S11"),
					"GREEN HILL ZONE",
					new SongInfo("U01"),
					new SongInfo("U04"),
					new SongInfo("U02"),
					new SongInfo("U03"),
					new SongInfo("U06"),
					new SongInfo("U07"),
					new SongInfo("U08"),
					new SongInfo("U09"),
					new SongInfo("U10"),
					new SongInfo("U11"),
					new SongInfo("U12"),
					new SongInfo("U13"),
					"TEMPLE",
					new SongInfo("C03"),
					new SongInfo("W24"),
					"YOSHI'S ISLAND (MELEE)",
					new SongInfo("W05"),
					new SongInfo("W15"),
					"JUNGLE JAPES",
					new SongInfo("W03"),
					new SongInfo("W26"),
					"ONETT",
					new SongInfo("W12"),
					new SongInfo("W19"),
					"CORNERIA",
					new SongInfo("W08"),
					new SongInfo("W28"),
					"RAINBOW CRUISE",
					new SongInfo("W02"),
					new SongInfo("W01"),
					"GREEN GREENS",
					new SongInfo("W07"),
					new SongInfo("W06"),
					"BIG BLUE",
					new SongInfo("W11"),
					new SongInfo("W29"),
					"BRINSTAR",
					new SongInfo("W27"),
					new SongInfo("W04"),
					"POKEMON STADIUM",
					new SongInfo("W09"),
					new SongInfo("W16"),
					new SongInfo("W10"),
					"MENU",
					new SongInfo("X02"),
					new SongInfo("X03"),
					new SongInfo("W30"),
					new SongInfo("X01"),
					"SUBSPACE EMISSARY",
					new SongInfo("Y01"),
					new SongInfo("Y02"),
					new SongInfo("Y03"),
					new SongInfo("Y04"),
					new SongInfo("Y09"),
					new SongInfo("Y10"),
					new SongInfo("Y11"),
					new SongInfo("Y13"),
					new SongInfo("Y14"),
					new SongInfo("Y15"),
					new SongInfo("Y05"),
					new SongInfo("Y07"),
					new SongInfo("Y08"),
					new SongInfo("Y16"),
					new SongInfo("Y17"),
					"VICTORY THEMES",
					new SongInfo("Z01"),
					new SongInfo("Z02"),
					new SongInfo("Z03"),
					new SongInfo("Z04"),
					new SongInfo("Z05"),
					new SongInfo("Z06"),
					new SongInfo("Z07"),
					new SongInfo("Z08"),
					new SongInfo("Z10"),
					new SongInfo("Z11"),
					new SongInfo("Z16"),
					new SongInfo("Z17"),
					new SongInfo("Z18"),
					new SongInfo("Z21"),
					new SongInfo("Z22"),
					new SongInfo("Z23"),
					new SongInfo("Z25"),
					new SongInfo("Z35"),
					new SongInfo("Z46"),
					new SongInfo("Z47"),
					"OTHER",
					new SongInfo("X07"),
					new SongInfo("X08"),
					new SongInfo("X09"),
					new SongInfo("X10"),
					new SongInfo("X11"),
					new SongInfo("X13"),
					new SongInfo("X15"),
					new SongInfo("X16"),
					new SongInfo("X17"),
					new SongInfo("X18"),
					new SongInfo("X19"),
					new SongInfo("X20"),
					new SongInfo("X21"),
					new SongInfo("X23"),
					new SongInfo("X26"),
					new SongInfo("X27"),
					new SongInfo("T05"),
					new SongInfo("X22"),
					new SongInfo("X06"),
					new SongInfo("X24"),
					new SongInfo("Z50"),
					new SongInfo("Z51"),
					new SongInfo("Z54"),
					new SongInfo("Z55"),
					new SongInfo("Z56"),
					new SongInfo("Z57"),
					new SongInfo("Z58"),
				};
				return oa;
			}
		}

		public const string DEFAULTS = "Tracklist:\n" +
"BATTLEFIELD\n" +
"X04 - Battlefield\n" +
"T02 - Menu (Super Smash Bros. Melee)\n" +
"X25 - Battlefield Ver. 2\n" +
"W21 - Battlefield (Melee)\n" +
"W23 - Multi-Man Melee 1 (Melee)\n" +
"\n" +
"FINAL DESTINATION\n" +
"X05 - Final Destination\n" +
"T01 - Credits (Super Smash Bros.)\n" +
"T03 - Opening (Super Smash Bros. Melee)\n" +
"W25 - Final Destination (Melee)\n" +
"W31 - Giga Bowser (Melee)\n" +
"\n" +
"DELFINO PLAZA\n" +
"A13 - Delfino Plaza\n" +
"A07 - Title / Ending (Super Mario World)\n" +
"A08 - Main Theme (New Super Mario Bros.)\n" +
"A14 - Ricco Harbor\n" +
"A15 - Main Theme (Super Mario 64)\n" +
"\n" +
"LUIGI'S MANSION\n" +
"A09 - Luigi's Mansion Theme\n" +
"A06 - Castle / Boss Fortress (Super Mario World / SMB3)\n" +
"A05 - Airship Theme (Super Mario Bros. 3)\n" +
"Q10 - Tetris: Type A\n" +
"Q11 - Tetris: Type B\n" +
"\n" +
"MUSHROOMY KINGDOM\n" +
"1-1\n" +
"A01 - Ground Theme (Super Mario Bros.)\n" +
"A16 - Ground Theme 2 (Super Mario Bros.)\n" +
"A10 - Gritzy Desert\n" +
"1-2\n" +
"A02 - Underground Theme (Super Mario Bros.)\n" +
"A03 - Underwater Theme (Super Mario Bros.)\n" +
"A04 - Underground Theme (Super Mario Land)\n" +
"\n" +
"MARIO CIRCUIT\n" +
"A20 - Mario Circuit\n" +
"A21 - Luigi Circuit\n" +
"A22 - Waluigi Pinball\n" +
"A23 - Rainbow Road\n" +
"R05 - Mario Tennis/Mario Golf\n" +
"R14 - Excite Truck\n" +
"Q09 - Title (3D Hot Rally)\n" +
"\n" +
"RUMBLE FALLS\n" +
"B01 - Jungle Level Ver.2\n" +
"B08 - Jungle Level\n" +
"B05 - King K. Rool / Ship Deck 2\n" +
"B06 - Bramble Blast\n" +
"B07 - Battle for Storm Hill\n" +
"B10 - DK Jungle 1 Theme (Barrel Blast)\n" +
"B02 - The Map Page / Bonus Level\n" +
"\n" +
"BRIDGE OF ELDIN\n" +
"C02 - Main Theme (The Legend of Zelda)\n" +
"C09 - Ocarina of Time Medley\n" +
"C01 - Title (The Legend of Zelda)\n" +
"C04 - The Dark World\n" +
"C05 - Hidden Mountain & Forest\n" +
"C08 - Hyrule Field Theme\n" +
"C17 - Main Theme (Twilight Princess)\n" +
"C18 - The Hidden Village\n" +
"C19 - Midna's Lament\n" +
"\n" +
"PIRATE SHIP\n" +
"C15 - Dragon Roost Island\n" +
"C16 - The Great Sea\n" +
"C07 - Tal Tal Heights\n" +
"C10 - Song of Storms\n" +
"C13 - Gerudo Valley\n" +
"C11 - Molgera Battle\n" +
"C12 - Village of the Blue Maiden\n" +
"C14 - Termina Field\n" +
"\n" +
"NORFAIR\n" +
"D01 - Main Theme (Metroid)\n" +
"D03 - Ending (Metroid)\n" +
"D02 - Norfair\n" +
"D05 - Theme of Samus Aran, Space Warrior\n" +
"R12 - Battle Scene / Final Boss (Golden Sun)\n" +
"R07 - Marionation Gear\n" +
"\n" +
"FRIGATE ORPHEON\n" +
"D04 - Vs. Ridley\n" +
"D08 - Vs. Parasite Queen\n" +
"D07 - Opening / Menu (Metroid Prime)\n" +
"D06 - Sector 1\n" +
"D09 - Vs. Meta Ridley\n" +
"D10 - Multiplayer (Metroid Prime 2)\n" +
"\n" +
"YOSHI'S ISLAND (BRAWL)\n" +
"E02 - Obstacle Course\n" +
"E07 - Obstacle Course (Winter)\n" +
"E01 - Ending (Yoshi's Story)\n" +
"E03 - Yoshi's Island\n" +
"E05 - Flower Field\n" +
"E06 - Wildlands\n" +
"\n" +
"HALBERD\n" +
"F06 - Meta Knight's Revenge\n" +
"F01 - The Legendary Air Ride Machine\n" +
"F05 - Gourmet Race\n" +
"F04 - Butter Building\n" +
"F02 - King Dedede's Theme\n" +
"F12 - Squeak Squad Theme\n" +
"F07 - Vs. Marx\n" +
"F08 - 0² Battle\n" +
"F03 - Boss Theme Medley\n" +
"F10 - Checker Knights\n" +
"F09 - Forest / Nature Area\n" +
"F11 - Frozen Hillside\n" +
"\n" +
"LYLAT CRUISE\n" +
"G10 - Space Armada\n" +
"G02 - Corneria\n" +
"G01 - Main Theme (Star Fox)\n" +
"G03 - Main Theme (Star Fox 64)\n" +
"G04 - Area 6\n" +
"G11 - Area 6 Ver. 2\n" +
"G05 - Star Wolf\n" +
"G09 - Star Wolf (Star Fox: Assault)\n" +
"G07 - Space Battleground\n" +
"G08 - Break Through the Ice\n" +
"Q12 - Tunnel Scene (X)\n" +
"\n" +
"POKEMON STADIUM 2\n" +
"H01 - Pokemon Main Theme\n" +
"H03 - Road to Viridian City (From Pallet Town / Pewter City)\n" +
"H02 - Pokemon Center\n" +
"H04 - Pokemon Gym / Evolution\n" +
"H05 - Wild Pokemon Battle! (Ruby / Sapphire)\n" +
"\n" +
"SPEAR PILLAR\n" +
"H06 - Victory Road\n" +
"H08 - Dialga / Palkia Battle at Spear Pillar!\n" +
"H07 - Wild Pokemon Battle! (Diamond / Pearl)\n" +
"H09 - Team Galactic Battle!\n" +
"H10 - Route 209\n" +
"\n" +
"PORT TOWN: AERO DIVE\n" +
"I01 - Mute City\n" +
"I03 - Fire Field\n" +
"I02 - White Land\n" +
"I04 - Car Select\n" +
"I05 - Dream Chaser\n" +
"I06 - Devil's Call in Your Heart\n" +
"I07 - Climb Up! And Get The Last Chance!\n" +
"I08 - Brain Cleaner\n" +
"I09 - Shotgun Kiss\n" +
"I10 - Planet Colors\n" +
"R09 - Golden Forest (1080° Snowboarding)\n" +
"W18 - Mach Rider (Melee)\n" +
"\n" +
"CASTLE SIEGE\n" +
"J02 - Fire Emblem Theme\n" +
"J04 - With Mila's Divine Protection (Celica Map 1)\n" +
"J08 - Attack\n" +
"J06 - Preparing to Advance\n" +
"J07 - Winning Road - Roy's Hope\n" +
"J03 - Shadow Dragon Medley\n" +
"J13 - Ike's Theme\n" +
"J09 - Against the Dark Knight\n" +
"J10 - Crimean Army Sortie\n" +
"J11 - Power-Hungry Fool\n" +
"J12 - Victory is Near\n" +
"W17 - Fire Emblem (Melee)\n" +
"\n" +
"WARIOWARE, INC.\n" +
"M01 - WarioWare, Inc.\n" +
"M02 - WarioWare, Inc. Medley\n" +
"M08 - Ashley's Song\n" +
"M07 - Ashley's Song (JP)\n" +
"M06 - Mike's Song\n" +
"M05 - Mike's Song (JP)\n" +
"M04 - Mona Pizza's Song\n" +
"M03 - Mona Pizza's Song (JP)\n" +
"M09 - MicroGame$ Theme 01\n" +
"M10 - MicroGame$ Theme 02\n" +
"M11 - MicroGame$ Theme 03\n" +
"M12 - MicroGame$ Theme 04\n" +
"M13 - MicroGame$ Theme 05\n" +
"M15 - MicroGame$ Theme 06\n" +
"M16 - MicroGame$ Theme 07\n" +
"M17 - MicroGame$ Theme 08\n" +
"M18 - MicroGame$ Theme 09\n" +
"\n" +
"DISTANT PLANET\n" +
"L06 - Main Theme (Pikmin)\n" +
"L01 - World Map (Pikmin 2)\n" +
"L07 - Stage Clear / Title (Pikmin)\n" +
"L02 - Forest of Hope\n" +
"L04 - Ai no Uta\n" +
"L08 - Ai no Uta (French Version)\n" +
"L05 - Tane no Uta\n" +
"L03 - Environmental Noises\n" +
"R08 - Title (Big Brain Academy)\n" +
"\n" +
"SMASHVILLE\n" +
"N01 - Title (Animal Crossing)\n" +
"N02 - Go K.K. Rider!\n" +
"N03 - 2:00 a.m.\n" +
"N06 - Town Hall and Tom Nook's Store\n" +
"N05 - The Roost\n" +
"N07 - K.K. Cruisin'\n" +
"N08 - K.K. Western\n" +
"N09 - K.K. Gumbo\n" +
"N10 - Rockin' K.K\n" +
"N11 - DJ K.K\n" +
"N12 - K.K. Condor\n" +
"\n" +
"NEW PORK CITY\n" +
"K07 - Porky's Theme\n" +
"K09 - Unfounded Revenge / Smashing Song of Praise\n" +
"K08 - Mother 3 Love Theme\n" +
"K10 - You Call This a Utopia?!\n" +
"K05 - Humoresque of a Little Dog\n" +
"K01 - Snowman\n" +
"\n" +
"SUMMIT\n" +
"Q07 - Ice Climber\n" +
"Q06 - Balloon Trip\n" +
"Q08 - Shin Onigashima\n" +
"Q05 - Clu Clu Land\n" +
"W13 - Icicle Mountain (Melee)\n" +
"\n" +
"SKYWORLD\n" +
"P01 - Underworld\n" +
"P03 - Skyworld\n" +
"P02 - Title (Kid Icarus)\n" +
"P04 - Kid Icarus Original Medley\n" +
"\n" +
"75M\n" +
"B04 - Donkey Kong\n" +
"B03 - Opening (Donkey Kong)\n" +
"B09 - 25m BGM\n" +
"\n" +
"MARIO BROS.\n" +
"A17 - Mario Bros.\n" +
"Q02 - Gyromite\n" +
"Q01 - Famicom Medley\n" +
"Q13 - Power-Up Music\n" +
"Q14 - Douchuumen (Nazo no Murasamejo)\n" +
"\n" +
"FLAT ZONE 2\n" +
"R04 - Flat Zone 2\n" +
"Q04 - Chill (Dr. Mario)\n" +
"W14 - Flat Zone (Melee)\n" +
"\n" +
"PICTOCHAT\n" +
"R02 - PictoChat\n" +
"R10 - Mii Channel\n" +
"R11 - Wii Shop Channel\n" +
"R15 - Brain Age: Train Your Brain in Minutes a Day\n" +
"R16 - Opening Theme (Wii Sports)\n" +
"R17 - Charge! (Wii Play)\n" +
"R13 - Shaberu! DS Cooking Navi\n" +
"R06 - Lip's Theme (Panel de Pon)\n" +
"W20 - Dr. Mario (Melee)\n" +
"\n" +
"HANENBOW\n" +
"R03 - Hanenbow Intro Chimes\n" +
"\n" +
"SHADOW MOSES ISLAND\n" +
"S06 - MGS4 ~Theme of Love~ Smash Bros. Brawl Version\n" +
"S02 - Encounter\n" +
"S03 - Theme of Tara\n" +
"S08 - Battle in the Base\n" +
"S04 - Yell \"Dead Cell\"\n" +
"S07 - Cavern\n" +
"S05 - Snake Eater (Instrumental)\n" +
"S10 - Theme of Solid Snake\n" +
"S11 - Calling to the Night\n" +
"\n" +
"GREEN HILL ZONE\n" +
"U01 - Green Hill Zone\n" +
"U04 - Angel Island Zone\n" +
"U02 - Scrap Brain Zone\n" +
"U03 - Emerald Hill Zone\n" +
"U06 - Sonic Boom\n" +
"U07 - Super Sonic Racing\n" +
"U08 - Open Your Heart\n" +
"U09 - Live & Learn\n" +
"U10 - Sonic Heroes\n" +
"U11 - Right There, Ride On\n" +
"U12 - HIS WORLD (Instrumental)\n" +
"U13 - Seven Rings In Hand\n" +
"\n" +
"TEMPLE\n" +
"C03 - Great Temple / Temple\n" +
"W24 - Temple (Melee)\n" +
"\n" +
"YOSHI'S ISLAND (MELEE)\n" +
"W05 - Yoshi's Island (Melee)\n" +
"W15 - Super Mario Bros. 3 (Melee)\n" +
"\n" +
"JUNGLE JAPES\n" +
"W03 - Jungle Japes (Melee)\n" +
"W26 - Kong Jungle (Melee)\n" +
"\n" +
"ONETT\n" +
"W12 - Mother (Melee)\n" +
"W19 - Mother 2 (Melee)\n" +
"\n" +
"CORNERIA\n" +
"W08 - Corneria (Melee)\n" +
"W28 - Venom (Melee)\n" +
"\n" +
"RAINBOW CRUISE\n" +
"W02 - Rainbow Cruise (Melee)\n" +
"W01 - Princess Peach's Castle (Melee)\n" +
"\n" +
"GREEN GREENS\n" +
"W07 - Green Greens (Melee)\n" +
"W06 - Fountain of Dreams (Melee)\n" +
"\n" +
"BIG BLUE\n" +
"W11 - Big Blue (Melee)\n" +
"W29 - Mute City (Melee)\n" +
"\n" +
"BRINSTAR\n" +
"W27 - Brinstar (Melee)\n" +
"W04 - Brinstar Depths (Melee)\n" +
"\n" +
"POKEMON STADIUM\n" +
"W09 - Pokemon Stadium (Melee)\n" +
"W16 - Battle Theme (Melee)\n" +
"W10 - Poke Floats (Melee)\n" +
"\n" +
"MENU\n" +
"X02 - Menu 1\n" +
"X03 - Menu 2\n" +
"W30 - Menu (Melee)\n" +
"X01 - Super Smash Bros. Brawl Main Theme\n" +
"\n" +
"SUBSPACE EMISSARY\n" +
"Y01 - Adventure Map\n" +
"Y02 - Step: The Plain\n" +
"Y03 - Step: The Cave\n" +
"Y04 - Step: Subspace\n" +
"Y09 - Jungle Theme (Donkey Kong Country)\n" +
"Y10 - Airship Theme (Super Mario Bros. 3)\n" +
"Y11 - Menu (Metroid Prime)\n" +
"Y13 - Brinstar (Metroid)\n" +
"Y14 - Step: Subspace Ver.2\n" +
"Y15 - Step: Subspace Ver.3\n" +
"Y05 - Boss Battle Song 1\n" +
"Y07 - Boss Battle Song 2\n" +
"Y08 - Save Point\n" +
"Y16 - Ambient\n" +
"Y17 - Clear\n" +
"\n" +
"VICTORY THEMES\n" +
"Z01 - Mario Series\n" +
"Z02 - Donkey Kong Series\n" +
"Z03 - Legend of Zelda Series\n" +
"Z04 - Metroid Series\n" +
"Z05 - Yoshi\n" +
"Z06 - Kirby Series\n" +
"Z07 - Star Fox Series\n" +
"Z08 - Pokémon Series\n" +
"Z10 - Captain Falcon\n" +
"Z11 - Mother Series\n" +
"Z16 - Ice Climbers\n" +
"Z17 - Fire Emblem Series\n" +
"Z18 - Mr. Game & Watch\n" +
"Z21 - Wario\n" +
"Z22 - Meta Knight\n" +
"Z23 - Pit\n" +
"Z25 - Olimar\n" +
"Z35 - R.O.B.\n" +
"Z46 - Solid Snake\n" +
"Z47 - Sonic The Hedgehog\n" +
"\n" +
"OTHER\n" +
"X07 - Online Practice Stage\n" +
"X08 - Results Display Screen\n" +
"X09 - Tournament Registration\n" +
"X10 - Tournament Grid\n" +
"X11 - Tournament Match End\n" +
"X13 - Classic: Results Screen\n" +
"X15 - All-Star Rest Area\n" +
"X16 - Home-Run Contest\n" +
"X17 - Cruel Brawl\n" +
"X18 - Boss Battle\n" +
"X19 - Trophy Gallery\n" +
"X20 - Sticker Album / Album / Chronicle\n" +
"X21 - Coin Launcher\n" +
"X23 - Stage Builder\n" +
"X26 - Target Smash!!\n" +
"X27 - Credits\n" +
"T05 - Master Hand\n" +
"X22 - Classic Mode Trophy Castle\n" +
"X06 - Solo Game Clear\n" +
"X24 - Nothing?\n" +
"Z50 - Continue\n" +
"Z51 - Game Over\n" +
"Z54 - New Feature 01\n" +
"Z55 - New Feature 02\n" +
"Z56 - New Feature 03\n" +
"Z57 - New Feature 04\n" +
"Z58 - New Feature 05\n" +
"\n" +
"Credit goes to Jose Gallardo for the list. Fixes to the list are credited to Vyse. Added titles and organization are credited to omni destroyer.\n" +
"A few fixes and reorganisation of 2 songs by Linkshot\n" +
"K12, W26 titles fixed by libertyernie\n";

	}
}
