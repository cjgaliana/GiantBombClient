using GiantBombClient.DTO;

namespace GiantBombClient.Games
{
    public class GiantBombGameDTO
    {
        public string Error { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Number_of_page_results { get; set; }
        public int Number_of_total_results { get; set; }
        public int Status_code { get; set; }
        public Game Game { get; set; }
        public string Version { get; set; }
    }

    public class Game
    {
        public string Aliases { get; set; }
        public string Api_detail_url { get; set; }
        public string Date_added { get; set; }
        public string Date_last_updated { get; set; }
        public string Deck { get; set; }
        public string Description { get; set; }
        public object Expected_release_day { get; set; }
        public object Expected_release_month { get; set; }
        public object Expected_release_quarter { get; set; }
        public object Expected_release_year { get; set; }
        public int Id { get; set; }
        public Image Image { get; set; }
        public string Name { get; set; }
        public int Number_of_user_reviews { get; set; }
        public Original_Game_Rating[] Original_game_rating { get; set; }
        public string Original_release_date { get; set; }
        public Platform[] Platforms { get; set; }
        public string Site_detail_url { get; set; }
        public GBImage[] Images { get; set; }

        //TO DO
        public object[] Videos { get; set; }

        public Character[] Characters { get; set; }
        public Concept[] Concepts { get; set; }
        public Developer[] Developers { get; set; }
        public First_Appearance_Characters[] First_appearance_characters { get; set; }
        public First_Appearance_Concepts[] First_appearance_concepts { get; set; }
        public First_Appearance_Locations[] First_appearance_locations { get; set; }
        public First_Appearance_Objects[] First_appearance_objects { get; set; }
        public First_Appearance_People[] First_appearance_people { get; set; }
        public Franchise[] Franchises { get; set; }
        public Genre[] Genres { get; set; }
        public object Killed_characters { get; set; }
        public Location[] Locations { get; set; }
        public Object[] Objects { get; set; }
        public Person[] People { get; set; }
        public Publisher[] Publishers { get; set; }
        public Release[] Releases { get; set; }
        public Similar_Games[] Similar_games { get; set; }
        public Theme[] Themes { get; set; }
    }
}