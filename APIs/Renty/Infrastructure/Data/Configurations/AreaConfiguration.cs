using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data{
public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        var areas = new List<Area>
        {
/* Start Cairo Id:1 */
new Area{Id=1,CityId=1,Name="15 May"},
new Area{Id=2,CityId=1,Name="El-Azbakeya"},
new Area{Id=3,CityId=1,Name="El-Bostan"},
new Area{Id=4,CityId=1,Name="El-Tebbin"},
new Area{Id=5,CityId=1,Name="El-Khalifa"},
new Area{Id=6,CityId=1,Name="El-Darasa"},
new Area{Id=7,CityId=1,Name="El-Darb El-Ahmar"},
new Area{Id=8,CityId=1,Name="El-Zawya El-Hamra"},
new Area{Id=9,CityId=1,Name="El-Zeitoun"},
new Area{Id=10,CityId=1,Name="El-Sahel"},
new Area{Id=11,CityId=1,Name="Peace"},
new Area{Id=12,CityId=1,Name="SayyIda Zeinab"},
new Area{Id=13,CityId=1,Name="Sharabia"},
new Area{Id=14,CityId=1,Name="Shorouk City"},
new Area{Id=15,CityId=1,Name="Al-Zahir"},
new Area{Id=16,CityId=1,Name="Al-Attaba"},
new Area{Id=17,CityId=1,Name="new Cairo"},
new Area{Id=18,CityId=1,Name="Al-Marg"},
new Area{Id=19,CityId=1,Name="Ezbet El-Nakhl"},
new Area{Id=20,CityId=1,Name="Al-Matariya"},
new Area{Id=21,CityId=1,Name="Maadi"},
new Area{Id=22,CityId=1,Name="Maasara"},
new Area{Id=23,CityId=1,Name="Mokattam"},
new Area{Id=24,CityId=1,Name="El Manial"},
new Area{Id=25,CityId=1,Name="El Mosky"},
new Area{Id=26,CityId=1,Name="El Nozha"},
new Area{Id=27,CityId=1,Name="El Waili"},
new Area{Id=28,CityId=1,Name="Bab El Shaaria"},
new Area{Id=29,CityId=1,Name="Boulaq"},
new Area{Id=30,CityId=1,Name="Garden City"},
new Area{Id=31,CityId=1,Name="Gardens Dome"},
new Area{Id=32,CityId=1,Name="Helwan"},
new Area{Id=33,CityId=1,Name="Dar El Salam"},
new Area{Id=34,CityId=1,Name="Shubra"},
new Area{Id=35,CityId=1,Name="Tora"},
new Area{Id=36,CityId=1,Name="Abdeen"},
new Area{Id=37,CityId=1,Name="Abbasiya"},
new Area{Id=38,CityId=1,Name="Ain Shams"},
new Area{Id=39,CityId=1,Name="Nasr City"},
new Area{Id=40,CityId=1,Name="new Cairo"},
new Area{Id=41,CityId=1,Name="Old Cairo"},
new Area{Id=42,CityId=1,Name="Manshiyat Nasser"},
new Area{Id=43,CityId=1,Name="Badr City"},
new Area{Id=44,CityId=1,Name="Obour City"},
new Area{Id=45,CityId=1,Name="Downtown"},
new Area{Id=46,CityId=1,Name="Zamalek"},
new Area{Id=47,CityId=1,Name="Qasr El Nil"},
new Area{Id=48,CityId=1,Name="El Rehab"},
new Area{Id=49,CityId=1,Name="Katameya"},
new Area{Id=50,CityId=1,Name="Madinaty"},
new Area{Id=51,CityId=1,Name="Rawd El Farag"},
new Area{Id=52,CityId=1,Name="Sheraton"},
new Area{Id=53,CityId=1,Name="Gamaleya"},
new Area{Id=54,CityId=1,Name="10th of Ramadan"},
new Area{Id=55,CityId=1,Name="El-Helmeya"},
new Area{Id=56,CityId=1,Name="new Nozha"},
new Area{Id=57,CityId=1,Name="Administrative Capital"},
/* End Cairo Id:1 */

/* Start Giza Id:2 */
new Area{Id=58,CityId=2,Name="Giza"},
new Area{Id=59,CityId=2,Name="6th of October"},
new Area{Id=60,CityId=2,Name="Sheikh Zayed"},
new Area{Id=61,CityId=2,Name="Al-Hawamdiya"},
new Area{Id=62,CityId=2,Name="Al-Badrashin"},
new Area{Id=63,CityId=2,Name="Al-Saff"},
new Area{Id=64,CityId=2,Name="Atfih"},
new Area{Id=65,CityId=2,Name="Al-Ayat"},
new Area{Id=66,CityId=2,Name="Al-Bawiti"},
new Area{Id=67,CityId=2,Name="Mansha'at Al-Qanater"},
new Area{Id=68,CityId=2,Name="Oseem"},
new Area{Id=69,CityId=2,Name="Kerdasa"},
new Area{Id=70,CityId=2,Name="Abu Al-Numrus"},
new Area{Id=71,CityId=2,Name="Kafr Ghatati"},
new Area{Id=72,CityId=2,Name="Manshaet El Bakary"},
new Area{Id=73,CityId=2,Name="Dokki"},
new Area{Id=74,CityId=2,Name="El Agouza"},
new Area{Id=75,CityId=2,Name="El Haram"},
new Area{Id=76,CityId=2,Name="El Warraq"},
new Area{Id=77,CityId=2,Name="Imbaba"},
new Area{Id=78,CityId=2,Name="Boulaq El Dakrour"},
new Area{Id=79,CityId=2,Name="El Wahat El Bahariya"},
new Area{Id=80,CityId=2,Name="El Omrania"},
new Area{Id=81,CityId=2,Name="El-Monib"},
new Area{Id=82,CityId=2,Name="Bayn El-Sarayat"},
new Area{Id=83,CityId=2,Name="Kit Kat"},
new Area{Id=84,CityId=2,Name="El-Mohandeseen"},
new Area{Id=85,CityId=2,Name="Faisal"},
new Area{Id=86,CityId=2,Name="Abu Rawash"},
new Area{Id=87,CityId=2,Name="Ahram Gardens"},
new Area{Id=88,CityId=2,Name="El-Haraniya"},
new Area{Id=89,CityId=2,Name="October Gardens"},
new Area{Id=90,CityId=2,Name="Saft El-Laban"},
new Area{Id=91,CityId=2,Name="Smart Village"},
new Area{Id=92,CityId=2,Name="Lion Land"},
/* End Giza Id:2 */

/* Start Alexandria Id:3 */
new Area{Id=93,CityId=3,Name="Abu Qir"},
new Area{Id=94,CityId=3,Name="Ibrahimiya"},
new Area{Id=95,CityId=3,Name="Azareeta"},
new Area{Id=96,CityId=3,Name="Anfoushi"},
new Area{Id=97,CityId=3,Name="Dakhila"},
new Area{Id=98,CityId=3,Name="Syouf"},
new Area{Id=99,CityId=3,Name="Al-Ameriya"},
new Area{Id=100,CityId=3,Name="Al-Luban"},
new Area{Id=101,CityId=3,Name="Al-Mafroza"},
new Area{Id=102,CityId=3,Name="El Montazah"},
new Area{Id=103,CityId=3,Name="El Mansheya"},
new Area{Id=104,CityId=3,Name="El Nasserya"},
new Area{Id=105,CityId=3,Name="Ambroso"},
new Area{Id=106,CityId=3,Name="Bab Sharq"},
new Area{Id=107,CityId=3,Name="Burj El Arab"},
new Area{Id=108,CityId=3,Name="Stanley"},
new Area{Id=109,CityId=3,Name="Smouha"},
new Area{Id=110,CityId=3,Name="SIdi Bishr"},
new Area{Id=111,CityId=3,Name="Shades"},
new Area{Id=112,CityId=3,Name="Gheit El Enab"},
new Area{Id=113,CityId=3,Name="Fleming"},
new Area{Id=114,CityId=3,Name="Victoria"},
new Area{Id=115,CityId=3,Name="Camp Caesar"},
new Area{Id=116,CityId=3,Name="Karmouz"},
new Area{Id=117,CityId=3,Name="Raml Station"},
new Area{Id=118,CityId=3,Name="Mina El Basal"},
new Area{Id=119,CityId=3,Name="El Asafir"},
new Area{Id=120,CityId=3,Name="El Ajami"},
new Area{Id=121,CityId=3,Name="Bakous"},
new Area{Id=122,CityId=3,Name="Bolkely"},
new Area{Id=123,CityId=3,Name="Cleopatra"},
new Area{Id=124,CityId=3,Name="Gleem"},
new Area{Id=125,CityId=3,Name="Al-Maamoura"},
new Area{Id=126,CityId=3,Name="Al-Mandara"},
new Area{Id=127,CityId=3,Name="Moharram Bek"},
new Area{Id=128,CityId=3,Name="Al-Shatby"},
new Area{Id=129,CityId=3,Name="SIdi Gaber"},
new Area{Id=130,CityId=3,Name="North Coast"},
new Area{Id=131,CityId=3,Name="Al-Hadra"},
new Area{Id=132,CityId=3,Name="Al Attarin"},
new Area{Id=133,CityId=3,Name="SIdi Krir"},
new Area{Id=134,CityId=3,Name="Al Customs"},
new Area{Id=135,CityId=3,Name="Al Maks"},
new Area{Id=136,CityId=3,Name="Marina"},
/* End Alexandria Id:3 */

/* Start Dakahlia Id:4 */
new Area{Id=137,CityId=4,Name="Al Mansoura"},
new Area{Id=138,CityId=4,Name="Talkha"},
new Area{Id=139,CityId=4,Name="Mit Ghamr"},
new Area{Id=140,CityId=4,Name="Dakernes"},
new Area{Id=141,CityId=4,Name="Aja"},
new Area{Id=142,CityId=4,Name="Minya Al-Nasr"},
new Area{Id=143,CityId=4,Name="Senbalawin"},
new Area{Id=144,CityId=4,Name="Al-Kurdi"},
new Area{Id=145,CityId=4,Name="Bani UbaId"},
new Area{Id=146,CityId=4,Name="Al-Manzala"},
new Area{Id=147,CityId=4,Name="Tami Al-Amdeed"},
new Area{Id=148,CityId=4,Name="Al-Gamaleya"},
new Area{Id=149,CityId=4,Name="Sherbin"},
new Area{Id=150,CityId=4,Name="Al-Matariya"},
new Area{Id=151,CityId=4,Name="Belqas"},
new Area{Id=152,CityId=4,Name="Mit Salsil"},
new Area{Id=153,CityId=4,Name="Gamasa"},
new Area{Id=154,CityId=4,Name="Mahalla Demna"},
new Area{Id=155,CityId=4,Name="Nabroh"},
/* End Dakahlia Id:4 */

/* Start Red Sea Id:5 */
new Area{Id=156,CityId=5,Name="Hurghada"},
new Area{Id=157,CityId=5,Name="Ras Ghareb"},
new Area{Id=158,CityId=5,Name="Safaga"},
new Area{Id=159,CityId=5,Name="Quseir"},
new Area{Id=160,CityId=5,Name="Marsa Alam"},
new Area{Id=161,CityId=5,Name="Shalateen"},
new Area{Id=162,CityId=5,Name="Halaib"},
new Area{Id=163,CityId=5,Name="Dahar"},
/* End Red Sea Id:5 */

/* Start Beheira Id:6 */
new Area{Id=164,CityId=6,Name="Damanhour"},
new Area{Id=165,CityId=6,Name="Kafr El Dawar"},
new Area{Id=166,CityId=6,Name="RashId"},
new Area{Id=167,CityId=6,Name="Edko"},
new Area{Id=168,CityId=6,Name="Abu El Matamir"},
new Area{Id=169,CityId=6,Name="Abu Homs"},
new Area{Id=170,CityId=6,Name="Dalingat"},
new Area{Id=171,CityId=6,Name="Mahmoudia"},
new Area{Id=172,CityId=6,Name="Al-Rahmaniya"},
new Area{Id=173,CityId=6,Name="Itay Al-Baroud"},
new Area{Id=174,CityId=6,Name="Hosh Issa"},
new Area{Id=175,CityId=6,Name="Shibrakhit"},
new Area{Id=176,CityId=6,Name="Kom Hamada"},
new Area{Id=177,CityId=6,Name="Badr"},
new Area{Id=178,CityId=6,Name="Wadi Al-Natrun"},
new Area{Id=179,CityId=6,Name="new Nubaria"},
new Area{Id=180,CityId=6,Name="new Nubaria"},
/* End Beheira Id:6 */

/* Start Fayoum Id:7 */
new Area{Id=181,CityId=7,Name="Fayoum"},
new Area{Id=182,CityId=7,Name="new Fayoum"},
new Area{Id=183,CityId=7,Name="Tamia"},
new Area{Id=184,CityId=7,Name="Snouris"},
new Area{Id=185,CityId=7,Name="Etsa"},
new Area{Id=186,CityId=7,Name="Ebshway"},
new Area{Id=187,CityId=7,Name="Youssef El-SIddiq"},
new Area{Id=188,CityId=7,Name="El-Hadiqa"},
new Area{Id=189,CityId=7,Name="Etsa"},
new Area{Id=190,CityId=7,Name="El-Gamia"},
new Area{Id=191,CityId=7,Name="El-Sayala"},
/* End Fayoum Id:7 */

/* Start Gharbia Id:8 */
new Area{Id=192,CityId=8,Name="Tanta"},
new Area{Id=193,CityId=8,Name="El Mahalla El Kubra"},
new Area{Id=194,CityId=8,Name="Kafr El Zayat"},
new Area{Id=195,CityId=8,Name="Zifta"},
new Area{Id=196,CityId=8,Name="El Santa"},
new Area{Id=197,CityId=8,Name="Qatour"},
new Area{Id=198,CityId=8,Name="Basion"},
new Area{Id=199,CityId=8,Name="Samanoud"},
/* End Gharbia Id:8 */

/* Start Ismailia Id:9 */
new Area{Id=200,CityId=9,Name="Ismailia"},
new Area{Id=201,CityId=9,Name="Fayed"},
new Area{Id=202,CityId=9,Name="Qantara East"},
new Area{Id=203,CityId=9,Name="Qantara West"},
new Area{Id=204,CityId=9,Name="Tall El-Kebir"},
new Area{Id=205,CityId=9,Name="Abu Suweir"},
new Area{Id=206,CityId=9,Name="new Qassasin"},
new Area{Id=207,CityId=9,Name="Nafisha"},
new Area{Id=208,CityId=9,Name="Sheikh Zayed"},
/* End Ismailia Id:9 */

/* Start Monufya Id:10 */
new Area{Id=209,CityId=10,Name="Shibin El Kom"},
new Area{Id=210,CityId=10,Name="Sadat City"},
new Area{Id=211,CityId=10,Name="Menouf"},
new Area{Id=212,CityId=10,Name="Sers El Layyan"},
new Area{Id=213,CityId=10,Name="Ashmoun"},
new Area{Id=214,CityId=10,Name="El Bagour"},
new Area{Id=215,CityId=10,Name="Quweisna"},
new Area{Id=216,CityId=10,Name="Birket El Sabaa"},
new Area{Id=217,CityId=10,Name="Tala"},
new Area{Id=218,CityId=10,Name="Martyrs"},
/* Start Monufya Id:10 */

/* Start Minya Id:11 */
new Area{Id=219,CityId=11,Name="Minya"},
new Area{Id=220,CityId=11,Name="new Minya"},
new Area{Id=221,CityId=11,Name="Al-Adwa"},
new Area{Id=222,CityId=11,Name="Maghagha"},
new Area{Id=223,CityId=11,Name="Beni Mazar"},
new Area{Id=224,CityId=11,Name="Matai"},
new Area{Id=225,CityId=11,Name="Samalout"},
new Area{Id=226,CityId=11,Name="Intellectual City"},
new Area{Id=227,CityId=11,Name="Malawy"},
new Area{Id=228,CityId=11,Name="Deir Mawas"},
new Area{Id=229,CityId=11,Name="Abu Qurqas"},
new Area{Id=230,CityId=11,Name="Sultan Land"},
/* End Minya Id:11 */

/* Start Qalubia Id:12 */
new Area{Id=231,CityId=12,Name="Benha"},
new Area{Id=232,CityId=12,Name="Qalyub"},
new Area{Id=233,CityId=12,Name="Shubra El-Kheima"},
new Area{Id=234,CityId=12,Name="El-Qanater El-Khairiya"},
new Area{Id=235,CityId=12,Name="Al-Khanka"},
new Area{Id=236,CityId=12,Name="Kafr Shukr"},
new Area{Id=237,CityId=12,Name="Toukh"},
new Area{Id=238,CityId=12,Name="Qaha"},
new Area{Id=239,CityId=12,Name="Al-Obour"},
new Area{Id=240,CityId=12,Name="Al-Khosoos"},
new Area{Id=241,CityId=12,Name="Shibin Al-Qanater"},
new Area{Id=242,CityId=12,Name="Mostorod"},
/* End Qalubia Id:12 */

/* Start new Valley Id:13 */
new Area{Id=243,CityId=13,Name="Al Kharga"},
new Area{Id=244,CityId=13,Name="Paris"},
new Area{Id=245,CityId=13,Name="Mot"},
new Area{Id=246,CityId=13,Name="Farafra"},
new Area{Id=247,CityId=13,Name="Balat"},
new Area{Id=248,CityId=13,Name="Dakhla"},
/* End new Valley Id:13 */

/* Start South Sinai Id:14 */
new Area{Id=249,CityId=14,Name="Suez"},
new Area{Id=250,CityId=14,Name="Al Ganain"},
new Area{Id=251,CityId=14,Name="Ataka"},
new Area{Id=252,CityId=14,Name="Ain Sokhna"},
new Area{Id=253,CityId=14,Name="Faisal"},
/* End South Sinai Id:14 */

/* Start Aswan Id:15 */
new Area{Id=254,CityId=15,Name="Aswan"},
new Area{Id=255,CityId=15,Name="new Aswan"},
new Area{Id=256,CityId=15,Name="Draw"},
new Area{Id=257,CityId=15,Name="Kom Ombo"},
new Area{Id=258,CityId=15,Name="Nasr El-Nuba"},
new Area{Id=259,CityId=15,Name="Klabsha"},
new Area{Id=260,CityId=15,Name="Edfu"},
new Area{Id=261,CityId=15,Name="Al-Radisiya"},
new Area{Id=262,CityId=15,Name="Al-Basilia"},
new Area{Id=263,CityId=15,Name="Al-Sabaia"},
new Area{Id=264,CityId=15,Name="Abu Simbel Tourist"},
new Area{Id=265,CityId=15,Name="Marsa Alam"},
/* End Aswan Id:15 */

/* Start Assiut Id:16 */
new Area{Id=266,CityId=16,Name="Assiut"},
new Area{Id=267,CityId=16,Name="new Assiut"},
new Area{Id=268,CityId=16,Name="Dayrut"},
new Area{Id=269,CityId=16,Name="Manfalut"},
new Area{Id=270,CityId=16,Name="Qousiya"},
new Area{Id=271,CityId=16,Name="Abnub"},
new Area{Id=272,CityId=16,Name="Abu Tig"},
new Area{Id=273,CityId=16,Name="Al-Ghanayem"},
new Area{Id=274,CityId=16,Name="Sahel Selim"},
new Area{Id=275,CityId=16,Name="Al-Badari"},
new Area{Id=276,CityId=16,Name="Sadfa"},
/* End Assiut Id:16 */

/* Start Bani Sweif Id:17 */
new Area{Id=277,CityId=17,Name="Beni Suef"},
new Area{Id=278,CityId=17,Name="new Beni Suef"},
new Area{Id=279,CityId=17,Name="Al-Wasti"},
new Area{Id=280,CityId=17,Name="Nasser"},
new Area{Id=281,CityId=17,Name="Ihnesya"},
new Area{Id=282,CityId=17,Name="Baba"},
new Area{Id=283,CityId=17,Name="Al-Fashn"},
new Area{Id=284,CityId=17,Name="Semsta"},
new Area{Id=285,CityId=17,Name="Al-Abasiry"},
new Area{Id=286,CityId=17,Name="Muqbil"},
/* End Bani Sweif Id:17 */

/* Start PorSaId Id:18 */
new Area{Id=287,CityId=18,Name="Port SaId"},
new Area{Id=288,CityId=18,Name="Port Fouad"},
new Area{Id=289,CityId=18,Name="Al-Arab"},
new Area{Id=290,CityId=18,Name="Al-Zohour District"},
new Area{Id=291,CityId=18,Name="District East"},
new Area{Id=292,CityId=18,Name="Al-Dawahi District"},
new Area{Id=293,CityId=18,Name="Al-Manakh District"},
new Area{Id=294,CityId=18,Name="Mubarak District"},
/* End PorSaId Id:18 */

/* Start Damietta Id:19 */
new Area{Id=295,CityId=19,Name="Damietta"},
new Area{Id=296,CityId=19,Name="new Damietta"},
new Area{Id=297,CityId=19,Name="Ras El-Bar"},
new Area{Id=298,CityId=19,Name="Farskur"},
new Area{Id=299,CityId=19,Name="Al-Zarqa"},
new Area{Id=300,CityId=19,Name="Sarw"},
new Area{Id=301,CityId=19,Name="Al Rawda"},
new Area{Id=302,CityId=19,Name="Kafr El Battikh"},
new Area{Id=303,CityId=19,Name="Ezbet El Borg"},
new Area{Id=304,CityId=19,Name="Mit Abu Ghaleb"},
new Area{Id=305,CityId=19,Name="Kafr Saad"},
/* End Damietta Id:19 */

/* Start Sharqia Id:20 */
new Area{Id=306,CityId=20,Name="Zagazig"},
new Area{Id=307,CityId=20,Name="10th of Ramadan"},
new Area{Id=308,CityId=20,Name="Minya Al Qamh"},
new Area{Id=309,CityId=20,Name="Belbeis"},
new Area{Id=310,CityId=20,Name="Mashtoul Al Souq"},
new Area{Id=311,CityId=20,Name="Al Qanayat"},
new Area{Id=312,CityId=20,Name="Abu Hammad"},
new Area{Id=313,CityId=20,Name="Al Qurain"},
new Area{Id=314,CityId=20,Name="Hehia"},
new Area{Id=315,CityId=20,Name="Abu Kabir"},
new Area{Id=316,CityId=20,Name="Faqous"},
new Area{Id=317,CityId=20,Name="Al Salihiya new"},
new Area{Id=318,CityId=20,Name="Ibrahimiya"},
new Area{Id=319,CityId=20,Name="Deirb Najm"},
new Area{Id=320,CityId=20,Name="Kafr Saqr"},
new Area{Id=321,CityId=20,Name="Awlad Saqr"},
new Area{Id=322,CityId=20,Name="Al-Husseiniya"},
new Area{Id=323,CityId=20,Name="San Al-Hajar Al-Qibliya"},
new Area{Id=324,CityId=20,Name="Mansha'at Abu Omar"},
/* End Sharqia Id:20 */

/* Start South Sinai Id:21 */
new Area{Id=325,CityId=21,Name="Al-Tur"},
new Area{Id=326,CityId=21,Name="Sharm El Sheikh"},
new Area{Id=327,CityId=21,Name="Dahab"},
new Area{Id=328,CityId=21,Name="Nuweiba"},
new Area{Id=329,CityId=21,Name="Taba"},
new Area{Id=330,CityId=21,Name="Saint Catherine"},
new Area{Id=331,CityId=21,Name="Abu Redis"},
new Area{Id=332,CityId=21,Name="Abu Zenima"},
new Area{Id=333,CityId=21,Name="Ras Sudr"},
/* End South Sinai Id:21 */

/* Start Kafr El Sheikh Id:22 */
new Area{Id=334,CityId=22,Name="Kafr El Sheikh"},
new Area{Id=335,CityId=22,Name="Downtown Kafr El Sheikh"},
new Area{Id=336,CityId=22,Name="Desouk"},
new Area{Id=337,CityId=22,Name="Foh"},
new Area{Id=338,CityId=22,Name="Matoubas"},
new Area{Id=339,CityId=22,Name="Burj El Burullus"},
new Area{Id=340,CityId=22,Name="Baltim"},
new Area{Id=341,CityId=22,Name="Baltim Summer Resort"},
new Area{Id=342,CityId=22,Name="El Hamoul"},
new Area{Id=343,CityId=22,Name="Bella"},
new Area {Id=344,CityId=22,Name="Riyadh"},
new Area {Id=345,CityId=22,Name="SIdi Salem"},
new Area {Id=346,CityId=22,Name="Qaleen"},
new Area {Id=347,CityId=22,Name="SIdi Ghazi"},
/* End Kafr El Sheikh Id:22 */

/* Start Matrouh Id:23 */
new Area {Id=348,CityId=23,Name="Marsa Matrouh"},
new Area {Id=349,CityId=23,Name="Hammam"},
new Area{Id=350,CityId=23,Name="El Alamein"},
new Area{Id=351,CityId=23,Name="El Dabaa"},
new Area{Id=352,CityId=23,Name="El Nagila"},
new Area{Id=353,CityId=23,Name="SIdi Barani"},
new Area{Id=354,CityId=23,Name="El Salloum"},
new Area{Id=355,CityId=23,Name="Siwa"},
new Area{Id=356,CityId=23,Name="Marina"},
new Area{Id=357,CityId=23,Name="North Coast"},
/* End Matrouh Id:23 */

/* Start Luxor Id:24 */
new Area{Id=358,CityId=24,Name="El Luxor"},
new Area{Id=359,CityId=24,Name="new Luxor"},
new Area{Id=360,CityId=24,Name="Esna"},
new Area{Id=361,CityId=24,Name="new Thebes"},
new Area{Id=362,CityId=24,Name="Al-Zainiya"},
new Area{Id=363,CityId=24,Name="Al-Bayadiya"},
new Area{Id=364,CityId=24,Name="Al-Qurna"},
new Area{Id=365,CityId=24,Name="Arment"},
new Area{Id=366,CityId=24,Name="Al-Tod"},
/* End Luxor Id:24 */

/* Start Qena Id:25 */
new Area{Id=367,CityId=25,Name="Qena"},
new Area{Id=368,CityId=25,Name="new Qena"},
new Area{Id=369,CityId=25,Name="Abu Tasht"},
new Area{Id=370,CityId=25,Name="Nag Hammadi"},
new Area{Id=371,CityId=25,Name="Dishna"},
new Area{Id=372,CityId=25,Name="Al-Waqf"},
new Area{Id=373,CityId=25,Name="Qift"},
new Area{Id=374,CityId=25,Name="Naqada"},
new Area{Id=375,CityId=25,Name="Farshout"},
new Area{Id=376,CityId=25,Name="Qous"},
/* End Qena Id:25 */

/* Start North Sinai Id:26 */
new Area{Id=377,CityId=26,Name="Arish"},
new Area{Id=378,CityId=26,Name="Sheikh ZuweId"},
new Area{Id=379,CityId=26,Name="Nakhl"},
new Area{Id=380,CityId=26,Name="Rafah"},
new Area{Id=381,CityId=26,Name="Bir al-Abd"},
new Area{Id=382,CityId=26,Name="al-Hasanah"},
/* End North Sinai Id:26 */

/* Start Sohag Id:27 */
new Area{Id=383,CityId=27,Name="Sohag"},
new Area{Id=384,CityId=27,Name="Sohag new"},
new Area{Id=385,CityId=27,Name="Akhmeem"},
new Area{Id=386,CityId=27,Name="new Akhmim"},
new Area{Id=387,CityId=27,Name="Belina"},
new Area{Id=388,CityId=27,Name="Maragha"},
new Area{Id=389,CityId=27,Name="Al-Mansha"},
new Area{Id=390,CityId=27,Name="Dar Al-Salam"},
new Area{Id=391,CityId=27,Name="Girga"},
new Area{Id=392,CityId=27,Name="Gharbia Jehena"},
new Area{Id=393,CityId=27,Name="Saqalta"},
new Area{Id=394,CityId=27,Name="Tama"},
new Area{Id=395,CityId=27,Name="Tahta"},
new Area{Id=396,CityId=27,Name="Al-Kawthar"}
/* End Sharqia Id:27 */
        
    };
        builder.HasData(areas);
    }
}
}