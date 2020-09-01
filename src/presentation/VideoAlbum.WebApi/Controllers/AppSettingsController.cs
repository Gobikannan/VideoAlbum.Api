using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VideoAlbum.Common.Config;

namespace VideoAlbum.WebApi.Controllers
{
    /// <summary>
    /// Controller to fetch all app settings metadata
    /// </summary>
    public class AppSettingsController : ApiController
    {
        private readonly AppSettings appSettings;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="appSettings"></param>
        public AppSettingsController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        /// <summary>
        /// Get Application Settings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AppSettings GetAppSettings()
        {
            return this.appSettings;
        }
    }
}
