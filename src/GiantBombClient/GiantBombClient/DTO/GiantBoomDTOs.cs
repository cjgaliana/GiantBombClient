namespace GiantBombClient.DTO
{
    public class BaseGiantBombDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Api_detail_url { get; set; }
        public string Site_detail_url { get; set; }
    }

    public class Image
    {
        public string Icon_url { get; set; }
        public string Medium_url { get; set; }
        public string Screen_url { get; set; }
        public string Small_url { get; set; }
        public string Super_url { get; set; }
        public string Thumb_url { get; set; }
        public string Tiny_url { get; set; }
    }

    public class Original_Game_Rating
    {
        public string Api_detail_url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Platform : BaseGiantBombDTO
    {
        public string Abbreviation { get; set; }
    }

    public class GBImage
    {
        public string Icon_url { get; set; }
        public string Medium_url { get; set; }
        public string Screen_url { get; set; }
        public string Small_url { get; set; }
        public string Super_url { get; set; }
        public string Thumb_url { get; set; }
        public string Tiny_url { get; set; }
        public string Tags { get; set; }
    }

    public class Character : BaseGiantBombDTO
    {
    }

    public class Concept : BaseGiantBombDTO
    {
    }

    public class Developer : BaseGiantBombDTO
    {
    }

    public class First_Appearance_Characters : BaseGiantBombDTO
    {
    }

    public class First_Appearance_Concepts : BaseGiantBombDTO
    {
    }

    public class First_Appearance_Locations : BaseGiantBombDTO
    {
    }

    public class First_Appearance_Objects : BaseGiantBombDTO
    {
    }

    public class First_Appearance_People : BaseGiantBombDTO
    {
    }

    public class Franchise : BaseGiantBombDTO
    {
    }

    public class Genre : BaseGiantBombDTO
    {
    }

    public class Location : BaseGiantBombDTO
    {
    }

    public class Object : BaseGiantBombDTO
    {
    }

    public class Person : BaseGiantBombDTO
    {
    }

    public class Publisher : BaseGiantBombDTO
    {
    }

    public class Release : BaseGiantBombDTO
    {
    }

    public class Similar_Games : BaseGiantBombDTO
    {
    }

    public class Theme : BaseGiantBombDTO
    {
    }
}