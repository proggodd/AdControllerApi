namespace AdControllerApi.Dtos
{
    public class AdSettingUpdateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoinsRequired { get; set; }
        
    }
}
