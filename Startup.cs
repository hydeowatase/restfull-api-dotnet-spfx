﻿using Owin;

namespace BootCamp.ApiSpfx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
