// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.DataBaeUsingInfo
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

namespace 实体类生成工具
{
  internal class DataBaeUsingInfo
  {
    private string loginUid;
    private string loginPwd;
    private string database;
    private string table;

    public DataBaeUsingInfo()
    {
    }

    public DataBaeUsingInfo(string loginUid, string loginPwd, string database, string table)
    {
      this.loginUid = loginUid;
      this.loginPwd = loginPwd;
      this.database = database;
      this.table = table;
    }

    public string LoginUid
    {
      get
      {
        return this.loginUid;
      }
      set
      {
        this.loginUid = value;
      }
    }

    public string LoginPwd
    {
      get
      {
        return this.loginPwd;
      }
      set
      {
        this.loginPwd = value;
      }
    }

    public string Database
    {
      get
      {
        return this.database;
      }
      set
      {
        this.database = value;
      }
    }

    public string Table
    {
      get
      {
        return this.table;
      }
      set
      {
        this.table = value;
      }
    }
  }
}
