using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlSongManager {
	public class SongListIndices {
		private static Dictionary<string, int> map;

		static SongListIndices() {
			map = new Dictionary<string, int>();
			map.Add("F08", 37);
			map.Add("N03", 119);
			map.Add("B09", 256);
			map.Add("Y01", 123);
			map.Add("J09", 90);
			map.Add("L04", 113);
			map.Add("L08", 114);
			map.Add("A05", 240);
			map.Add("X15", 34);
			map.Add("U04", 165);
			map.Add("G04", 47);
			map.Add("G11", 48);
			map.Add("M08", 101);
			map.Add("M07", 102);
			map.Add("J08", 84);
			map.Add("Q06", 124);
			map.Add("B07", 250);
			map.Add("S08", 158);
			map.Add("R12", 152);
			map.Add("W16", 215);
			map.Add("X04", 199);
			map.Add("W21", 220);
			map.Add("X25", 210);
			map.Add("W11", 209);
			map.Add("X18", 56);
			map.Add("Y05", 185);
			map.Add("Y07", 186);
			map.Add("F03", 38);
			map.Add("R15", 139);
			map.Add("I08", 72);
			map.Add("B06", 249);
			map.Add("G08", 52);
			map.Add("W27", 198);
			map.Add("W04", 200);
			map.Add("F04", 32);
			map.Add("S11", 163);
			map.Add("I04", 68);
			map.Add("A06", 239);
			map.Add("S07", 160);
			map.Add("R17", 141);
			map.Add("F10", 39);
			map.Add("Q04", 133);
			map.Add("X13", 23);
			map.Add("I07", 71);
			map.Add("Q05", 126);
			map.Add("X21", 89);
			map.Add("G02", 43);
			map.Add("W08", 204);
			map.Add("X27", 189);
			map.Add("T01", 191);
			map.Add("J10", 91);
			map.Add("X17", 184);
			map.Add("A13", 226);
			map.Add("I06", 70);
			map.Add("H08", 60);
			map.Add("N11", 182);
			map.Add("B10", 251);
			map.Add("B04", 253);
			map.Add("Q14", 131);
			map.Add("W20", 219);
			map.Add("C15", 4);
			map.Add("I05", 69);
			map.Add("U03", 168);
			map.Add("S02", 155);
			map.Add("D03", 14);
			map.Add("E01", 25);
			map.Add("L03", 116);
			map.Add("R14", 153);
			map.Add("Q01", 129);
			map.Add("X05", 221);
			map.Add("W25", 224);
			map.Add("W17", 216);
			map.Add("J02", 82);
			map.Add("I03", 65);
			map.Add("W14", 213);
			map.Add("R04", 132);
			map.Add("E05", 27);
			map.Add("F09", 40);
			map.Add("L02", 110);
			map.Add("W06", 202);
			map.Add("F11", 41);
			map.Add("C13", 8);
			map.Add("W31", 225);
			map.Add("N02", 118);
			map.Add("R09", 151);
			map.Add("F05", 31);
			map.Add("C03", 3);
			map.Add("W07", 203);
			map.Add("U01", 164);
			map.Add("A10", 234);
			map.Add("A01", 231);
			map.Add("A16", 233);
			map.Add("Q02", 128);
			map.Add("C05", 261);
			map.Add("U12", 175);
			map.Add("X16", 45);
			map.Add("K05", 80);
			map.Add("C08", 262);
			map.Add("Q07", 122);
			map.Add("W13", 212);
			map.Add("J13", 88);
			map.Add("W03", 196);
			map.Add("B08", 247);
			map.Add("B01", 246);
			map.Add("N12", 183);
			map.Add("N07", 177);
			map.Add("N09", 180);
			map.Add("N08", 179);
			map.Add("P04", 97);
			map.Add("F02", 33);
			map.Add("B05", 248);
			map.Add("W26", 195);
			map.Add("R06", 142);
			map.Add("U09", 172);
			map.Add("A21", 242);
			map.Add("A09", 238);
			map.Add("W18", 217);
			map.Add("D01", 13);
			map.Add("A08", 228);
			map.Add("L06", 107);
			map.Add("G03", 46);
			map.Add("G01", 44);
			map.Add("A15", 230);
			map.Add("C02", 257);
			map.Add("C17", 263);
			map.Add("A17", 127);
			map.Add("A20", 241);
			map.Add("R05", 148);
			map.Add("R07", 149);
			map.Add("W30", 222);
			map.Add("T02", 190);
			map.Add("X02", 111);
			map.Add("X03", 188);
			map.Add("F06", 29);
			map.Add("S06", 154);
			map.Add("C19", 2);
			map.Add("R10", 136);
			map.Add("M06", 103);
			map.Add("M05", 104);
			map.Add("C11", 9);
			map.Add("M04", 105);
			map.Add("M03", 106);
			map.Add("W12", 211);
			map.Add("W19", 218);
			map.Add("K08", 77);
			map.Add("W23", 223);
			map.Add("D10", 22);
			map.Add("I01", 64);
			map.Add("W29", 208);
			map.Add("D02", 15);
			map.Add("E02", 24);
			map.Add("C09", 258);
			map.Add("X07", 232);
			map.Add("U08", 171);
			map.Add("B03", 255);
			map.Add("T03", 192);
			map.Add("D07", 19);
			map.Add("R16", 140);
			map.Add("R02", 135);
			map.Add("I10", 74);
			map.Add("W10", 207);
			map.Add("H02", 55);
			map.Add("H04", 57);
			map.Add("H01", 53);
			map.Add("W09", 206);
			map.Add("K07", 75);
			map.Add("J11", 92);
			map.Add("Q13", 130);
			map.Add("J06", 85);
			map.Add("W01", 193);
			map.Add("W02", 194);
			map.Add("A23", 245);
			map.Add("X08", 243);
			map.Add("A14", 229);
			map.Add("U11", 174);
			map.Add("H03", 54);
			map.Add("N10", 181);
			map.Add("H10", 63);
			map.Add("Y08", 187);
			map.Add("U02", 166);
			map.Add("D06", 20);
			map.Add("U13", 176);
			map.Add("R13", 138);
			map.Add("J03", 87);
			map.Add("Q08", 125);
			map.Add("I09", 73);
			map.Add("P03", 95);
			map.Add("S05", 161);
			map.Add("K01", 81);
			map.Add("C10", 7);
			map.Add("U06", 169);
			map.Add("U10", 173);
			map.Add("G10", 42);
			map.Add("G07", 51);
			map.Add("F12", 35);
			map.Add("X23", 100);
			map.Add("L07", 109);
			map.Add("G05", 49);
			map.Add("G09", 50);
			map.Add("Y04", 156);
			map.Add("Y14", 167);
			map.Add("Y15", 178);
			map.Add("Y03", 145);
			map.Add("Y02", 134);
			map.Add("X20", 78);
			map.Add("W15", 214);
			map.Add("X01", 0);
			map.Add("U07", 170);
			map.Add("C07", 6);
			map.Add("L05", 115);
			map.Add("X26", 112);
			map.Add("H09", 62);
			map.Add("W24", 197);
			map.Add("C14", 11);
			map.Add("Q10", 143);
			map.Add("Q11", 144);
			map.Add("C04", 260);
			map.Add("C16", 5);
			map.Add("C18", 264);
			map.Add("F01", 30);
			map.Add("B02", 252);
			map.Add("N05", 121);
			map.Add("D05", 16);
			map.Add("S10", 162);
			map.Add("S03", 157);
			map.Add("Q09", 146);
			map.Add("N01", 117);
			map.Add("R08", 150);
			map.Add("P02", 96);
			map.Add("C01", 259);
			map.Add("A07", 227);
			map.Add("X10", 1);
			map.Add("X11", 12);
			map.Add("X09", 254);
			map.Add("N06", 120);
			map.Add("X19", 67);
			map.Add("Q12", 147);
			map.Add("A02", 235);
			map.Add("A04", 237);
			map.Add("A03", 236);
			map.Add("P01", 94);
			map.Add("K09", 76);
			map.Add("W28", 205);
			map.Add("J12", 93);
			map.Add("H06", 59);
			map.Add("C12", 10);
			map.Add("F07", 36);
			map.Add("D09", 21);
			map.Add("D08", 18);
			map.Add("D04", 17);
			map.Add("A22", 244);
			map.Add("M01", 98);
			map.Add("M02", 99);
			map.Add("I02", 66);
			map.Add("R11", 137);
			map.Add("H07", 61);
			map.Add("H05", 58);
			map.Add("E06", 28);
			map.Add("J07", 86);
			map.Add("J04", 83);
			map.Add("L01", 108);
			map.Add("S04", 159);
			map.Add("E03", 26);
			map.Add("W05", 201);
			map.Add("K10", 79);
		}

		private static string[] defaultNames = {
			"Super Smash Bros. Brawl Main Theme",
			"Tournament Grid",
			"Midna's Lament",
			"Great Temple / Temple",
			"Dragon Roost Island",
			"The Great Sea",
			"Tal Tal Heights",
			"Song of Storms",
			"Gerudo Valley",
			"Molgera Battle",
			"Village of the Blue Maiden",
			"Termina Field",
			"Tournament Match End",
			"Main Theme (Metroid)",
			"Ending (Metroid)",
			"Norfair",
			"Theme of Samus Aran, Space Warrior",
			"Vs. Ridley",
			"Vs. Parasite Queen",
			"Opening / Menu (Metroid Prime)",
			"Sector 1",
			"Vs. Meta Ridley",
			"Multiplayer (Metroid Prime 2)",
			"Classic: Results Screen",
			"Obstacle Course",
			"Ending (Yoshi's Story)",
			"Yoshi's Island",
			"Flower Field",
			"Wildlands",
			"Meta Knight's Revenge",
			"The Legendary Air Ride Machine",
			"Gourmet Race",
			"Butter Building",
			"King Dedede's Theme",
			"All-Star Rest Area",
			"Squeak Squad Theme",
			"Vs. Marx",
			"0Â² Battle",
			"Boss Theme Medley",
			"Checker Knights",
			"Forest / Nature Area",
			"Frozen Hillside",
			"Space Armada",
			"Corneria",
			"Main Theme (Star Fox)",
			"Home-Run Contest",
			"Main Theme (Star Fox 64)",
			"Area 6",
			"Area 6 Ver. 2",
			"Star Wolf",
			"Star Wolf (Star Fox: Assault)",
			"Space Battleground",
			"Break Through the Ice",
			"PokÃ©mon Main Theme",
			"Road to Viridian City (From Pallet Town / Pewter City)",
			"PokÃ©mon Center",
			"Boss Battle",
			"PokÃ©mon Gym / Evolution",
			"Wild PokÃ©mon Battle! (Ruby / Sapphire)",
			"Victory Road",
			"Dialga / Palkia Battle at Spear Pillar!",
			"Wild PokÃ©mon Battle! (Diamond / Pearl)",
			"Team Galactic Battle!",
			"Route 209",
			"Mute City",
			"Fire Field",
			"White Land ",
			"Trophy Gallery",
			"Car Select",
			"Dream Chaser",
			"Devil's Call in Your Heart",
			"Climb Up! And Get The Last Chance!",
			"Brain Cleaner",
			"Shotgun Kiss",
			"Planet Colors",
			"Porky's Theme",
			"Unfounded Revenge / Smashing Song of Praise",
			"Mother 3 Love Theme",
			"Sticker Album / Album / Chronicle",
			"You Call This a Utopia?!",
			"Humoresque of a Little Dog",
			"Snowman",
			"Fire Emblem Theme",
			"With Mila's Divine Protection (Celica Map 1)",
			"Attack",
			"Preparing to Advance",
			"Winning Road - Roy's Hope",
			"Shadow Dragon Medley",
			"Ike's Theme",
			"Coin Launcher",
			"Against the Dark Knight",
			"Crimean Army Sortie",
			"Power-Hungry Fool",
			"Victory Is Near",
			"Underworld",
			"Skyworld",
			"Title (Kid Icarus)",
			"Kid Icarus Original Medley",
			"WarioWare, Inc.",
			"WarioWare, Inc. Medley",
			"Stage Builder",
			"Ashley's Song",
			"Ashley's Song (JP)",
			"Mike's Song",
			"Mike's Song (JP)",
			"Mona Pizza's Song",
			"Mona Pizza's Song (JP)",
			"Main Theme (Pikmin)",
			"World Map (Pikmin 2)",
			"Stage Clear / Title (Pikmin)",
			"Forest of Hope",
			"Menu 1",
			"Target Smash!!",
			"Ai no Uta",
			"Ai no Uta (French Version)",
			"Tane no Uta",
			"Environmental Noises",
			"Title (Animal Crossing)",
			"Go K.K. Rider!",
			"2:00 a.m.",
			"Town Hall and Tom Nook's Store",
			"The Roost",
			"Ice Climber",
			"Adventure Map",
			"Balloon Trip",
			"Shin Onigashima",
			"Clu Clu Land",
			"Mario Bros.",
			"Gyromite",
			"Famicom Medley",
			"Power-Up Music",
			"Douchuumen (Nazo no Murasamejo)",
			"Flat Zone 2",
			"Chill (Dr. Mario)",
			"Step: The Plain",
			"PictoChat",
			"Mii Channel",
			"Wii Shop Channel",
			"Shaberu! DS Cooking Navi",
			"Brain Age: Train Your Brain in Minutes a Day",
			"Opening Theme (Wii Sports)",
			"Charge! (Wii Play)",
			"Lip's Theme (Panel de Pon)",
			"Tetris: Type A",
			"Tetris: Type B",
			"Step: The Cave",
			"Title (3D Hot Rally)",
			"Tunnel Scene (X)",
			"Mario Tennis / Mario Golf",
			"Marionation Gear",
			"Title (Big Brain Academy)",
			"Golden Forest (1080Â°Snowboarding)",
			"Battle Scene / Final Boss (Golden Sun)",
			"Excite Truck",
			"MGS4 ï½žTheme of Loveï½ž Smash Bros. Brawl Version",
			"Encounter",
			"Step: Subspace",
			"Theme of Tara",
			"Battle in the Base",
			"Yell \"Dead Cell\"",
			"Cavern",
			"Snake Eater (Instrumental)",
			"Theme of Solid Snake",
			"Calling to the Night",
			"Green Hill Zone",
			"Angel Island Zone",
			"Scrap Brain Zone",
			"Step: Subspace Ver.2",
			"Emerald Hill Zone",
			"Sonic Boom",
			"Super Sonic Racing",
			"Open Your Heart",
			"Live & Learn",
			"Sonic Heroes",
			"Right There, Ride On",
			"HIS WORLD (Instrumental)",
			"Seven Rings In Hand",
			"K.K. Crusin'",
			"Step: Subspace Ver.3",
			"K.K. Western",
			"K.K. Gumbo",
			"Rockin' K.K.",
			"DJ K.K.",
			"K.K. Condor",
			"Cruel Brawl",
			"Boss Battle Song 1",
			"Boss Battle Song 2",
			"Save Point",
			"Menu 2",
			"Credits",
			"Menu (Super Smash Bros. Melee)",
			"Credits (Super Smash Bros.)",
			"Opening (Super Smash Bros. Melee)",
			"Princess Peach's Castle (Melee)",
			"Rainbow Cruise (Melee)",
			"Kong Jungle (Melee)",
			"Jungle Japes (Melee)",
			"Temple (Melee)",
			"Brinstar (Melee)",
			"Battlefield",
			"Brinstar Depths (Melee)",
			"Yoshi's Island (Melee)",
			"Fountain of Dreams (Melee)",
			"Green Greens (Melee)",
			"Corneria (Melee)",
			"Venom (Melee)",
			"PokÃ©mon Stadium (Melee)",
			"PokÃ© Floats (Melee)",
			"Mute City (Melee)",
			"Big Blue (Melee)",
			"Battlefield Ver. 2",
			"Mother (Melee)",
			"Icicle Mountain (Melee)",
			"Flat Zone (Melee)",
			"Super Mario Bros. 3 (Melee)",
			"Battle Theme (Melee)",
			"Fire Emblem (Melee)",
			"Mach Rider (Melee)",
			"Mother 2 (Melee)",
			"Dr. Mario (Melee)",
			"Battlefield (Melee)",
			"Final Destination",
			"Menu (Melee)",
			"Multi-Man Melee 1 (Melee)",
			"Final Destination (Melee)",
			"Giga Bowser (Melee)",
			"Delfino Plaza",
			"Title / Ending (Super Mario World)",
			"Main Theme (New Super Mario Bros.)",
			"Ricco Harbor",
			"Main Theme (Super Mario 64)",
			"Ground Theme (Super Mario Bros.)",
			"Online Practice Stage",
			"Ground Theme 2 (Super Mario Bros.)",
			"Gritzy Desert",
			"Underground Theme (Super Mario Bros.)",
			"Underwater Theme (Super Mario Bros.)",
			"Underground Theme (Super Mario Land)",
			"Luigi's Mansion Theme",
			"Castle / Boss Fortress (Super Mario World / SMB 3)",
			"Airship Theme (Super Mario Bros. 3)",
			"Mario Circuit",
			"Luigi Circuit",
			"Results Display Screen",
			"Waluigi Pinball",
			"Rainbow Road",
			"Jungle Level Ver.2",
			"Jungle Level  ",
			"King K.Rool / Ship Deck 2",
			"Bramble Blast",
			"Battle for Storm Hill",
			"DK Jungle 1 Theme (Barrel Blast)",
			"The Map Page / Bonus Level",
			"Donkey Kong",
			"Tournament Registration",
			"Opening (Donkey Kong)",
			"25m BGM",
			"Main Theme (The Legend of Zelda)",
			"Ocarina of Time Medley",
			"Title (The Legend of Zelda)",
			"The Dark World",
			"Hidden Mountain & Forest",
			"Hyrule Field Theme",
			"Main Theme (Twilight Princess)",
			"The Hidden Village",
		};

		public static string defaultNameFor(int index) {
			return defaultNames[index];
		}

		public static int indexFor(string filename) {
			int ret;
			if (map.TryGetValue(filename, out ret)) {
				return ret;
			} else {
				return -1;
			}
		}
	}
}
