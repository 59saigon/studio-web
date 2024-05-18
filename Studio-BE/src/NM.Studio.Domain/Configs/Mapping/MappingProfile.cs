namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile
    {
        public MappingProfile()
        {
            WeddingMapping();
            LocationMapping();
            EventMapping();
            UserMapping();
            ServiceMapping();
            PhotoMapping();
            EventXPhotoMapping();
            EventXServiceMapping();
        }
        
    }
}
