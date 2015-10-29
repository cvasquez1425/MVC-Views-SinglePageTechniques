using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePagePTC.Common
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();
        }

        public string EventCommand   { get; set; }
        public bool IsValid          { get; set; }
        public string Mode           { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        // Primary Key holder
        public string EventArgument     { get; set; }

        // Control Visibility
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible   { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        protected virtual void ListMode()    // changed from privagte to protected virtual. protected so that we can inherit from it, and  virtual to override it. in case we have additional property
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;

            ValidationErrors = new List<KeyValuePair<string, string>>();

            ListMode();
        }

        protected virtual void Get()
        {
                
        }

    }
}
