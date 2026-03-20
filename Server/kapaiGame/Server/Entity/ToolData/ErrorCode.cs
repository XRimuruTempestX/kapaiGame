namespace Fantasy.ToolData;

public  class ErrorCode
{

    public const uint Success = 0;
    
    //---------注册
    //注册账号有误
    public const uint RegisterAccountOrPasswordErrorCode = 1001;

    //已经存在该账号
    public const uint ExitAccount = 1002;
    
    //--------END
}