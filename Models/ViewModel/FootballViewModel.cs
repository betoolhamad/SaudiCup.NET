namespace Cup.Models
{
    public class FootballViewModel
    {
        public int Id { get; set; } // Id من جدول FootballTabels
        public string NameStadium { get; set; } // اسم الملعب من جدول Stadiums
        public string Team1 { get; set; } // الفريق الأول
        public string Team2 { get; set; } // الفريق الثاني
        public DateTime MatchTime { get; set; } // وقت المباراة
    }
}
