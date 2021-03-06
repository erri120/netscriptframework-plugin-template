﻿using NetScriptFramework.SkyrimSE;
using NetScriptFramework.Tools;

namespace PluginTemplate
{
    public class Plugin : NetScriptFramework.Plugin
    {
        public override string Key => "plugin.template";
        public static string PluginName => "Plugin Template";
        public override string Name => PluginName;
        public override int Version => 2;

        public override string Author => "erri120";
        public override string Website => "https://github.com/erri120/";

        public override int RequiredFrameworkVersion => 9;
        public override int RequiredLibraryVersion => 13;

        private bool _inMainMenu;
        private Timer _timer;
        private readonly object _lockObject = new object();
        private long _lastTime;

        protected override bool Initialize(bool loadedAny)
        {
            var utilityLibrary = NetScriptFramework.PluginManager.GetPlugin("utility.library");
            if (utilityLibrary == null) return false;
            if (!utilityLibrary.IsInitialized) return false;
            if (!loadedAny) return false;

            _timer = new Timer();

            Events.OnMainMenu.Register(e =>
            {
                _inMainMenu = e.Entering;
                if(e.Entering && _timer.IsRunning)
                    _timer.Stop();
                else if(!e.Entering && !_timer.IsRunning)
                    _timer.Start();
            });

            Events.OnFrame.Register(e =>
            {
                if (!UtilityLibrary.UtilityLibrary.IsInGame || _inMainMenu)
                    return;

                var now = _timer.Time;
                if (now - _lastTime < 1000)
                    return;

                _lastTime = now;

                var player = PlayerCharacter.Instance;
                if (player == null)
                    return;

                lock (_lockObject)
                {
                    //do something
                }
            });

            return true;
        }
    }
}
