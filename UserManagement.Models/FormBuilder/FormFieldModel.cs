using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.FormBuilder
{
    public  class FormFieldModel
    {
       
            public int Id { get; set; }
            public int FormId { get; set; }
            public string type { get; set; }
            public string label { get; set; }
            /*  public string HelpText { get; set; }
              public string Placeholder { get; set; }*/
            public bool? requireValidOption { get; set; }

            public bool? required { get; set; }
            public bool? toggle { get; set; }
            public bool? other { get; set; }
            public bool? inline { get; set; }
            public string subtype { get; set; }
            public string style { get; set; }
            public string className { get; set; }
            public string name { get; set; }
            public double? value { get; set; }
            public double? Maxlength { get; set; }
            public double? Rows { get; set; }
            public bool? access { get; set; }
            public List<AddFieldOptionsModel> values { get; set; }
        
    }
}
