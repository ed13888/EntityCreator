// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.Properties.Resources
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace 实体类生成工具.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) 实体类生成工具.Properties.Resources.resourceMan, (object) null))
          实体类生成工具.Properties.Resources.resourceMan = new ResourceManager("实体类生成工具.Properties.Resources", typeof (实体类生成工具.Properties.Resources).Assembly);
        return 实体类生成工具.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return 实体类生成工具.Properties.Resources.resourceCulture;
      }
      set
      {
        实体类生成工具.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
